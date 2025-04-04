﻿using Elasticsearch.Net;
using HuloToys_Service.Elasticsearch;
using HuloToys_Service.Utilities.Lib;
using Nest;
using System.Reflection;
using HuloToys_Service.Models.Client;
using Newtonsoft.Json;

namespace Caching.Elasticsearch
{
    public class ClientESService : ESRepository<ClientESModel>
    {
        public string index = "client_englishforkid_store";
        private readonly IConfiguration configuration;
        private static string _ElasticHost;

        public ClientESService(string Host,IConfiguration _configuration) : base(Host, _configuration) {
            _ElasticHost = Host;
            configuration = _configuration;
            index = _configuration["DataBaseConfig:Elastic:Index:Client"];

        }
        public ClientESModel GetById(long id)
        {
            try
            {
                var nodes = new Uri[] { new Uri(_ElasticHost) };
                var connectionPool = new StaticConnectionPool(nodes);
                var connectionSettings = new ConnectionSettings(connectionPool).DisableDirectStreaming().DefaultIndex("people");
                var elasticClient = new ElasticClient(connectionSettings);

                var query = elasticClient.Search<ClientESModel>(sd => sd
                               .Index(index)
                               .Query(q => q
                                   .Match(m => m.Field("id").Query(id.ToString())
                               )));

                if (query.IsValid)
                {
                    var result = query.Documents as List<ClientESModel>;
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.Message;
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
            }
            return null;
        }
        public List<ClientESModel> GetByEmail(string email)
        {
            try
            {
                var nodes = new Uri[] { new Uri(_ElasticHost) };
                var connectionPool = new StaticConnectionPool(nodes);
                var connectionSettings = new ConnectionSettings(connectionPool).DisableDirectStreaming().DefaultIndex("people");
                var elasticClient = new ElasticClient(connectionSettings);

                var query = elasticClient.Search<ClientESModel>(sd => sd
                               .Index(index)
                               .Query(q => q
                                   .Term(m => m.email,email)
                               ));
               
                if (query.IsValid)
                {
                    var result = query.Documents as List<ClientESModel>;
                    return result;
                }
            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.Message;
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
            }
            return null;
        }
        public List<ClientESModel> GetByPhone(string phone)
        {
            try
            {
                var nodes = new Uri[] { new Uri(_ElasticHost) };
                var connectionPool = new StaticConnectionPool(nodes);
                var connectionSettings = new ConnectionSettings(connectionPool).DisableDirectStreaming().DefaultIndex("people");
                var elasticClient = new ElasticClient(connectionSettings);

                var query = elasticClient.Search<ClientESModel>(sd => sd
                               .Index(index)
                               .Query(q => q
                                   .Match(m => m.Field("phone").Query(phone)
                               )));

                if (query.IsValid)
                {
                    var result = query.Documents as List<ClientESModel>;
                    return result;
                }
            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.Message;
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
            }
            return null;
        }
        public long GetCountClientTypeUse(int client_type)
        {
            try
            {
                var nodes = new Uri[] { new Uri(_ElasticHost) };
                var connectionPool = new StaticConnectionPool(nodes);
                var connectionSettings = new ConnectionSettings(connectionPool).DisableDirectStreaming().DefaultIndex("people");
                var elasticClient = new ElasticClient(connectionSettings);

                var query = elasticClient.Search<ClientESModel>(sd => sd
                               .Index(index)
                               .Query(q => q
                                   .Match(m => m.Field("clienttype").Query(client_type.ToString())
                               )));

                if (query.IsValid)
                {
                    var result = query.Documents as List<ClientESModel>;
                    return result.Count;
                }
            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.Message;
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
            }
            return 0;
        }
        public ClientESModel GetExactByEmail(string email)
        {
            try
            {
                var nodes = new Uri[] { new Uri(_ElasticHost) };
                var connectionPool = new StaticConnectionPool(nodes);
                var connectionSettings = new ConnectionSettings(connectionPool).DisableDirectStreaming().DefaultIndex("people");
                var elasticClient = new ElasticClient(connectionSettings);

                var query = elasticClient.Search<dynamic>(sd => sd
                               .Index(index)
                               .Query(q => q
                                   .Match(m => m.Field("Email").Query(email)
                               )));

                if (query.IsValid)
                {
                    var data = query.Documents as List<dynamic>;
                    var result = JsonConvert.DeserializeObject<List<ClientESModel>>(JsonConvert.SerializeObject(data));
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                string error_msg = Assembly.GetExecutingAssembly().GetName().Name + "->" + MethodBase.GetCurrentMethod().Name + "=>" + ex.ToString();
                LogHelper.InsertLogTelegramByUrl(configuration["telegram:log_try_catch:bot_token"], configuration["telegram:log_try_catch:group_id"], error_msg);
            }
            return null;
        }
    }
}
