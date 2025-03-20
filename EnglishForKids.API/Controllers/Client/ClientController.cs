using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using HuloToys_Service.Utilities.Lib;
using Utilities;
using Utilities.Contants;
using Models.Queue;
using HuloToys_Service.RabitMQ;
using Caching.Elasticsearch;
using HuloToys_Service.Models.Queue;
using HuloToys_Service.Utilities.constants;
using HuloToys_Service.Controllers.Order.Business;
using HuloToys_Service.Models.Client;
using HuloToys_Service.Models.APIRequest;
using HuloToys_Front_End.Models.Products;
using HuloToys_Service.MongoDb;
using HuloToys_Service.RedisWorker;
using Entities.Models;
using HuloToys_Service.Utilities.lib;
using HuloToys_Service.Controllers.Client.Business;
using Nest;
using HuloToys_Service.Data;
using HuloToys_Service.Models.Course;
using Telegram.Bot.Types;
using Microsoft.EntityFrameworkCore;
using EnglishForKids.API.Entities.Models;
using HuloToys_Service.Models.SQL;
using BioLife.API.Utilities.lib;
using SharpCompress.Common;

namespace HuloToys_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly WorkQueueClient workQueueClient;
        private readonly AccountClientESService accountClientESService;
        private readonly ClientESService clientESService;
        private readonly IdentiferService _identifierServiceRepository;
        private readonly ClientServices clientServices;
        private readonly RedisConn _redisService;
        private readonly EmailService _emailService;
        private readonly DefaultDbContext _dbContext;

        public ClientController(IConfiguration _configuration, RedisConn redisService, DefaultDbContext dbContext) {
            configuration= _configuration;
            workQueueClient=new WorkQueueClient(configuration);
            accountClientESService = new AccountClientESService(_configuration["DataBaseConfig:Elastic:Host"], _configuration);
            clientESService = new ClientESService(_configuration["DataBaseConfig:Elastic:Host"], _configuration);
            _identifierServiceRepository = new IdentiferService(_configuration);
            _redisService = new RedisConn(configuration);
            _redisService.Connect();
            clientServices = new ClientServices(configuration);
            _emailService = new EmailService(configuration);
            _dbContext = dbContext;

        }
        [HttpPost("login")]
        public async Task<ActionResult> ClientLogin([FromBody] APIRequestGenericModel input)
        {
            try
            {
                var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                JArray objParr = null;
                if (input != null && input.token != null && CommonHelper.GetParamWithKey(input.token, out objParr, configuration["KEY:private_key"]))
                {
                    var request = JsonConvert.DeserializeObject<ClientLoginRequestModel>(objParr[0].ToString());
                    if (request == null 
                        || request.user_name == null || request.user_name.Trim() == ""
                        || request.password == null || request.password.Trim() == ""
                        || request.type<0)
                    {

                        return Ok(new
                        {
                            status = (int)ResponseType.FAILED,
                            msg = "Tài khoản / Mật khẩu không chính xác, vui lòng thử lại"
                        });
                    }
                    switch (request.type)
                    {
                        case (int)AccountLoginType.Password:
                            {
                                //-- By Username 
                                var account_client = accountClientESService.GetByUsernameAndPassword(request.user_name, request.password);
                                if (account_client != null && account_client.id > 0 && account_client.clientid > 0)
                                {
                                    var client = clientESService.GetById((long)account_client.clientid);
                                    if (client != null && client.id > 0)
                                    {
                                        var token = await clientServices.GenerateToken(account_client.username, ipAddress);
                                        return Ok(new
                                        {
                                            status = (int)ResponseType.SUCCESS,
                                            msg = "Success",
                                            data = new ClientLoginResponseModel()
                                            {
                                                account_client_id = account_client.id,
                                                client_id = client.id,
                                                user_name = account_client.username,
                                                name = client.clientname,
                                                token= token,
                                                ip=ipAddress,
                                                time_expire= clientServices.GetExpiredTimeFromToken(token)
                                            }
                                        });

                                    }

                                }
                                //-- By Email 
                                var client_exitst = clientESService.GetByEmail(request.user_name.Split("@")[0]);
                                if(client_exitst!=null && client_exitst.Count > 0)
                                {
                                    client_exitst = client_exitst.Where(x => x.email.ToLower().Trim() == request.user_name.ToLower().Trim()).ToList();
                                    foreach(var client in client_exitst)
                                    {
                                        var account_client_exists = accountClientESService.GetByClientIdAndPassword(client.id, request.password);
                                        if (account_client_exists != null && account_client_exists.id > 0)
                                        {
                                            var token = await clientServices.GenerateToken(account_client_exists.username, ipAddress);
                                            return Ok(new
                                            {
                                                status = (int)ResponseType.SUCCESS,
                                                msg = "Success",
                                                data = new ClientLoginResponseModel()
                                                {
                                                    account_client_id = account_client_exists.id,
                                                    client_id = client.id,
                                                    user_name = account_client_exists.username,
                                                    name = client.clientname,
                                                    token = token,
                                                    ip = ipAddress,
                                                    time_expire = clientServices.GetExpiredTimeFromToken(token)
                                                }
                                            });
                                        }
                                    }
                                }
                                //-- By Phone 
                                client_exitst = clientESService.GetByPhone(request.user_name);
                                if (client_exitst != null && client_exitst.Count > 0)
                                {
                                    foreach (var client in client_exitst)
                                    {
                                        var account_client_exists = accountClientESService.GetByClientIdAndPassword(client.id, request.password);
                                        if (account_client_exists != null && account_client_exists.id > 0)
                                        {
                                            var token = await clientServices.GenerateToken(account_client_exists.username,  ipAddress);
                                            return Ok(new
                                            {
                                                status = (int)ResponseType.SUCCESS,
                                                msg = "Success",
                                                data = new ClientLoginResponseModel()
                                                {
                                                    account_client_id = account_client_exists.id,
                                                    client_id = client.id,
                                                    user_name = account_client_exists.username,
                                                    name = client.clientname,
                                                    token = token,
                                                    ip = ipAddress,
                                                    time_expire = clientServices.GetExpiredTimeFromToken(token)
                                                }
                                            });
                                        }
                                    }
                                }
                                //-- If nothing, Check SQL:
                                var account_sql = await _dbContext.AccountClients.FirstOrDefaultAsync(qr => qr.UserName.Trim() == request.user_name && qr.Password == request.password);
                                if (account_sql != null && account_sql.Id>0)
                                {
                                    var client_sql = await _dbContext.Clients.FirstOrDefaultAsync(qr => qr.Id==account_sql.ClientId);
                                    if(client_sql!=null && client_sql.Id > 0)
                                    {
                                        var token = await clientServices.GenerateToken(account_sql.UserName,  ipAddress);
                                        return Ok(new
                                        {
                                            status = (int)ResponseType.SUCCESS,
                                            msg = "Success",
                                            data = new ClientLoginResponseModel()
                                            {
                                                account_client_id = account_sql.Id,
                                                client_id = client_sql.Id,
                                                user_name = account_sql.UserName,
                                                name = client_sql.ClientName == null ? "" :StringHelper.RemoveSpecialCharacterExceptVietnameseCharacter(client_sql.ClientName),
                                                token = token,
                                                ip = ipAddress,
                                                time_expire = clientServices.GetExpiredTimeFromToken(token)
                                            }
                                        });
                                    }
                                }
                            }
                            break;
                        case (int)AccountLoginType.Google:
                            {
                                var account_client = accountClientESService.GetByUsernameAndGoogleToken(request.user_name, request.token);
                                if (account_client != null && account_client.id > 0 && account_client.clientid > 0)
                                {
                                    var client = clientESService.GetById((long)account_client.clientid);
                                    if (client != null && client.id > 0)
                                    {

                                        var token = await clientServices.GenerateToken(account_client.username, ipAddress);
                                        return Ok(new
                                        {
                                            status = (int)ResponseType.SUCCESS,
                                            msg = "Success",
                                            data = new ClientLoginResponseModel()
                                            {
                                                account_client_id = account_client.id,
                                                client_id=client.id,
                                                user_name = account_client.username,
                                                name = client.clientname,
                                                token = token,
                                                ip = ipAddress,
                                                time_expire = clientServices.GetExpiredTimeFromToken(token)
                                            }
                                        });
                                    }

                                }
                            }
                            break;
                        default:
                            {

                            }break;
                    }
                   
                   

                }

            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.ToString();
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
                return Ok(new
                {
                    status = (int)ResponseType.FAILED,
                    msg = ResponseMessages.FunctionExcutionFailed
                });
            }
            return Ok(new
            {
                status = (int)ResponseType.FAILED,
                msg = ResponseMessages.DataInvalid
            });

        }

        [HttpPost("register")]
        public async Task<ActionResult> ClientRegister([FromBody] APIRequestGenericModel input)
        {
            try
            {
                var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

                JArray objParr = null;
                if (input != null && input.token != null && CommonHelper.GetParamWithKey(input.token, out objParr, configuration["KEY:private_key"]))
                {
                    var request = JsonConvert.DeserializeObject<ClientRegisterRequestModel>(objParr[0].ToString());
                    if (request == null || request.user_name==null || request.user_name.Trim()==""
                        || request.phone == null || request.phone.Trim() == ""
                        || request.password == null || request.password.Trim() == ""
                        || request.confirm_password == null || request.confirm_password.Trim() == ""
                        || request.password.Trim() != request.confirm_password.Trim() ) {

                        return Ok(new
                        {
                            status = (int)ResponseType.FAILED,
                            msg = ResponseMessages.DataInvalid
                        });
                    }
                    if(request.email != null && request.email.Trim() != "")
                    {
                        var exists_client=clientESService.GetByEmail(request.email.Trim());
                        if (exists_client != null && exists_client.Count>0) {
                            return Ok(new
                            {
                                status = (int)ResponseType.FAILED,
                                msg = ResponseMessages.ClientEmailExists
                            });

                        }

                    }
                    string username_generate = "u" + DateTime.Now.ToString("yyMMddHHmmss");
                    for (int i = 1; i < 999; i++)
                    {
                        var value = username_generate + i.ToString().PadLeft(3, '0');
                        var exists = accountClientESService.GetByUsername(value);
                        if (exists != null) { continue; }
                        else
                        {
                            username_generate = value; 
                            break;
                        }
                    }

                    //AccountClientViewModel model = new AccountClientViewModel()
                    //{
                    //    ClientId = -1,
                    //    ClientType = 0,
                    //    Email = request.email == null || request.email.Trim() == "" ? "" : request.email.Trim(),
                    //    Id = -1,
                    //    isReceiverInfoEmail = request.is_receive_email == true ? (byte)1 : (byte)0,
                    //    Name = StringHelper.RemoveSpecialCharacterExceptVietnameseCharacter(request.user_name.Trim()),
                    //    ClientName = StringHelper.RemoveSpecialCharacterExceptVietnameseCharacter(request.user_name.Trim()),
                    //    Password = request.password,
                    //    Phone = request.phone,
                    //    Status = 0,
                    //    UserName = username_generate,
                    //    GoogleToken = request.token,
                    //    ClientCode =await _identifierServiceRepository.buildClientNo(0)
                    //};
                    //var queue_model = new ClientConsumerQueueModel()
                    //{
                    //    data_push = JsonConvert.SerializeObject(model),
                    //    type = QueueType.ADD_USER
                    //};
                    var client = new HuloToys_Service.Models.SQL.Client()
                    {
                        AgencyType=0,
                        Avartar="",
                        Birthday=DateTime.Now,
                        BusinessAddress="",
                        ClientCode="",
                        ClientMapId=0,
                        ClientName= StringHelper.RemoveSpecialCharacterExceptVietnameseCharacter(request.user_name.Trim()),
                        ClientType=1,
                        Email = request.email == null || request.email.Trim() == "" ? "" : request.email.Trim(),
                        ExportBillAddress="",
                        Gender=0,
                        IsReceiverInfoEmail=false,
                        IsRegisterAffiliate=false,
                        JoinDate=DateTime.Now,
                        Note="",
                        ParentId=0,
                        PermisionType=0,
                        Phone = request.phone,
                        ReferralId="",
                        SaleMapId= 0,
                        Status=0,
                        UpdateTime=DateTime.Now,
                        TaxNo=""
                    };
                    await _dbContext.Clients.AddAsync(client);
                    // Lưu thay đổi vào cơ sở dữ liệu
                    await _dbContext.SaveChangesAsync();

                    var account_client = new HuloToys_Service.Models.SQL.AccountClient()
                    {
                        ClientId= client.Id,
                        ClientType=1,
                        UserName = username_generate,
                        Status=0,
                        ForgotPasswordToken="",
                        GroupPermission=0,
                        Password= request.password,
                        PasswordBackup= request.password
                    };
                    await _dbContext.AccountClients.AddAsync(account_client);
                    // Lưu thay đổi vào cơ sở dữ liệu
                    await _dbContext.SaveChangesAsync();
                    //bool result= workQueueClient.InsertQueueSimple(JsonConvert.SerializeObject(queue_model),QueueName.queue_app_push);
                    //if (result)
                    //{

                    //    var token = await clientServices.GenerateToken(username_generate,  ipAddress);
                    //    return Ok(new
                    //    {
                    //        status = (int)ResponseType.SUCCESS,
                    //        msg = "Success",
                    //        data = new ClientLoginResponseModel()
                    //        {
                    //            //account_client_id = account_client_exists.id,
                    //            user_name = username_generate,
                    //            name = request.user_name.Trim(),
                    //            token = token,
                    //            ip = ipAddress,
                    //            time_expire = clientServices.GetExpiredTimeFromToken(token)
                    //        }
                    //    });
                    //}
                    var token = await clientServices.GenerateToken(username_generate, ipAddress);
                    return Ok(new
                    {
                        status = (int)ResponseType.SUCCESS,
                        msg = "Success",
                        data = new ClientLoginResponseModel()
                        {
                            account_client_id = account_client.Id,
                            client_id = client.Id,
                            user_name = username_generate,
                            name = request.user_name.Trim(),
                            token = token,
                            ip = ipAddress,
                            time_expire = clientServices.GetExpiredTimeFromToken(token)
                        }
                    });

                }

            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.ToString();
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
                return Ok(new
                {
                    status = (int)ResponseType.FAILED,
                    msg = ResponseMessages.FunctionExcutionFailed
                });
            }
            return Ok(new
            {
                status = (int)ResponseType.FAILED,
                msg = ResponseMessages.DataInvalid
            });

        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult> ForgotPassword([FromBody] APIRequestGenericModel input)
        {
            try
            {


                JArray objParr = null;
                if (input != null && input.token != null && CommonHelper.GetParamWithKey(input.token, out objParr, configuration["KEY:private_key"]))
                {
                    var request = JsonConvert.DeserializeObject<ClientForgotPasswordRequestModel>(objParr[0].ToString());
                    if (request == null || request.name == null || request.name.Trim() == "")
                    {

                        return Ok(new
                        {
                            status = (int)ResponseType.FAILED,
                            msg = ResponseMessages.DataInvalid
                        });
                    }
                    var client = clientESService.GetExactByEmail(request.name);
                    if (client != null&& client.id > 0) {
                        var account_client = accountClientESService.GetByClientID((long)client.id);
                        if (client != null && client.id > 0 && account_client != null && account_client.id > 0)
                        {
                            var forgot_password_object = new ClientForgotPasswordTokenModel()
                            {
                                account_client_id=account_client.id,
                                client_id=client.id,
                                email=client.email,
                                user_name=account_client.username,
                                created_time=DateTime.Now,
                                exprire_time=DateTime.Now.AddMinutes(30)
                            };
                            string forgot_password_token = CommonHelper.Encode(JsonConvert.SerializeObject(forgot_password_object), configuration["KEY:private_key"]);
                            if (forgot_password_token != null && forgot_password_token.Trim()!="") {
                                //Generate new Forgot password token:
                                AccountClientViewModel model = new AccountClientViewModel()
                                {
                                    ClientId = client.id,
                                    ClientType = 0,
                                    Email = null,
                                    Id = account_client.id,
                                    isReceiverInfoEmail = null,
                                    Name = null,
                                    Password = null,
                                    Phone = null,
                                    Status = 0,
                                    UserName = null,
                                    ForgotPasswordToken = forgot_password_token
                                };
                                var queue_model = new ClientConsumerQueueModel()
                                {
                                    data_push = JsonConvert.SerializeObject(model),
                                    type = QueueType.UPDATE_USER
                                };
                                bool result = workQueueClient.InsertQueueSimple(JsonConvert.SerializeObject(queue_model), QueueName.queue_app_push);
                                _emailService.SendEmailChangePassword(forgot_password_token,account_client, client);
                                if (result)
                                {
                                    return Ok(new
                                    {
                                        status = (int)ResponseType.SUCCESS,
                                        msg = "Success"
                                    });
                                }


                            }
                        }
                    }
                   

                }

            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.ToString();
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
                return Ok(new
                {
                    status = (int)ResponseType.FAILED,
                    msg = ResponseMessages.FunctionExcutionFailed
                });
            }
            return Ok(new
            {
                status = (int)ResponseType.FAILED,
                msg = ResponseMessages.DataInvalid
            });

        }
       
        [HttpPost("change-password")]
        public async Task<ActionResult> ChangePassword([FromBody] APIRequestGenericModel input)
        {
            try
            {


                JArray objParr = null;
                if (input != null && input.token != null && CommonHelper.GetParamWithKey(input.token, out objParr, configuration["KEY:private_key"]))
                {
                    var request = JsonConvert.DeserializeObject<ClientChangePasswordRequestModel>(objParr[0].ToString());
                    if (request == null || request.id<=0
                        || request.password == null || request.password.Trim() == ""
                        || request.confirm_password == null || request.confirm_password.Trim() == "")
                    {

                        return Ok(new
                        {
                            status = (int)ResponseType.FAILED,
                            msg = ResponseMessages.DataInvalid
                        });
                    }

                    var account_client = accountClientESService.GetById(request.id);
                    if (account_client != null && account_client.id > 0 && account_client.clientid > 0)
                    {
                        var client = clientESService.GetById((long)account_client.clientid);
                        if (client != null && client.id > 0)
                        {
                            string new_password = CommonHelper.MD5Hash(request.password);
                            //Generate new Forgot password token:


                            AccountClientViewModel model = new AccountClientViewModel()
                            {
                                ClientId = client.id,
                                ClientType = 0,
                                Email = null,
                                Id = account_client.id,
                                isReceiverInfoEmail = null,
                                Name = null,
                                Password = new_password,
                                Phone = null,
                                Status = 0,
                                UserName = null,
                                ForgotPasswordToken = ""
                            };
                            var queue_model = new ClientConsumerQueueModel()
                            {
                                data_push = JsonConvert.SerializeObject(model),
                                type = QueueType.UPDATE_USER
                            };
                            bool result = workQueueClient.InsertQueueSimple( JsonConvert.SerializeObject(queue_model), QueueName.queue_app_push);
                            if (result)
                            {
                                return Ok(new
                                {
                                    status = (int)ResponseType.SUCCESS,
                                    msg = "Success"
                                });
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.ToString();
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
            }
            return Ok(new
            {
                status = (int)ResponseType.FAILED,
                msg = ResponseMessages.DataInvalid
            });

        }
        [HttpPost("validate-forgot-password")]
        public async Task<ActionResult> ValidateForgotPassword([FromBody] APIRequestGenericModel input)
        {
            try
            {


                JArray objParr = null;
                if (input != null && input.token != null && CommonHelper.GetParamWithKey(input.token, out objParr, configuration["KEY:private_key"]))
                {
                    var request = JsonConvert.DeserializeObject<ClientForgotPasswordRequestModel>(objParr[0].ToString());
                    if (request == null || request.name == null || request.name.Trim() == "")
                    {

                        return Ok(new
                        {
                            status = (int)ResponseType.FAILED,
                            msg = ResponseMessages.DataInvalid
                        });
                    }
                    if (string.IsNullOrEmpty(request.name) || request.name.Trim() == "")
                    {
                        return Ok(new
                        {
                            status = (int)ResponseType.FAILED,
                            msg = ResponseMessages.DataInvalid
                        });
                    }
                    string forgot = CommonHelper.Decode(request.name.Replace("-", "+").Replace("_", "/"), configuration["KEY:private_key"]);
                    if (forgot == null || forgot.Trim() == "")
                    {
                        return Ok(new
                        {
                            status = (int)ResponseType.FAILED,
                            msg = ResponseMessages.DataInvalid
                        });
                    }
                    var model = JsonConvert.DeserializeObject<ClientForgotPasswordTokenModel>(forgot);
                    if (model == null || model.account_client_id <= 0 || model.exprire_time < DateTime.Now || model.created_time > DateTime.Now)
                    {
                        return Ok(new
                        {
                            status = (int)ResponseType.FAILED,
                            msg = ResponseMessages.DataInvalid
                        });
                    }
                    var account = accountClientESService.GetById(model.account_client_id);
                    if(account!=null &&request.name.Trim()== account.forgotpasswordtoken)
                    {
                        return Ok(new
                        {
                            status = (int)ResponseType.SUCCESS,
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.ToString();
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
                return Ok(new
                {
                    status = (int)ResponseType.FAILED,
                    msg = ResponseMessages.FunctionExcutionFailed
                });
            }
            return Ok(new
            {
                status = (int)ResponseType.FAILED,
                msg = ResponseMessages.DataInvalid
            });

        }
    }
}
