using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HuloToys_Service.Models.SQL;

public partial class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountClient> AccountClients { get; set; }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<AddressClient> AddressClients { get; set; }

    public virtual DbSet<AffiliateGroupProduct> AffiliateGroupProducts { get; set; }

    public virtual DbSet<AirPortCode> AirPortCodes { get; set; }

    public virtual DbSet<Airline> Airlines { get; set; }

    public virtual DbSet<AllCode> AllCodes { get; set; }

    public virtual DbSet<AllotmentFund> AllotmentFunds { get; set; }

    public virtual DbSet<AllotmentHistory> AllotmentHistories { get; set; }

    public virtual DbSet<AllotmentUse> AllotmentUses { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleCategory> ArticleCategories { get; set; }

    public virtual DbSet<ArticleRelated> ArticleRelateds { get; set; }

    public virtual DbSet<ArticleTag> ArticleTags { get; set; }

    public virtual DbSet<AttachFile> AttachFiles { get; set; }

    public virtual DbSet<Baggage> Baggages { get; set; }

    public virtual DbSet<BankOnePay> BankOnePays { get; set; }

    public virtual DbSet<BankingAccount> BankingAccounts { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Campaign> Campaigns { get; set; }

    public virtual DbSet<CampaignAd> CampaignAds { get; set; }

    public virtual DbSet<Cashback> Cashbacks { get; set; }

    public virtual DbSet<Chapter> Chapters { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientLinkAff> ClientLinkAffs { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<ContactClient> ContactClients { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractHistory> ContractHistories { get; set; }

    public virtual DbSet<ContractPay> ContractPays { get; set; }

    public virtual DbSet<ContractPayDetail> ContractPayDetails { get; set; }

    public virtual DbSet<DebtStatistic> DebtStatistics { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepositHistory> DepositHistories { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<FlightSegment> FlightSegments { get; set; }

    public virtual DbSet<FlyBookingDetail> FlyBookingDetails { get; set; }

    public virtual DbSet<FlyBookingExtraPackage> FlyBookingExtraPackages { get; set; }

    public virtual DbSet<FlyBookingPackagesOptional> FlyBookingPackagesOptionals { get; set; }

    public virtual DbSet<GroupClassAirline> GroupClassAirlines { get; set; }

    public virtual DbSet<GroupClassAirlinesDetail> GroupClassAirlinesDetails { get; set; }

    public virtual DbSet<GroupProduct> GroupProducts { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelBankingAccount> HotelBankingAccounts { get; set; }

    public virtual DbSet<HotelBooking> HotelBookings { get; set; }

    public virtual DbSet<HotelBookingCode> HotelBookingCodes { get; set; }

    public virtual DbSet<HotelBookingRoom> HotelBookingRooms { get; set; }

    public virtual DbSet<HotelBookingRoomExtraPackage> HotelBookingRoomExtraPackages { get; set; }

    public virtual DbSet<HotelBookingRoomRate> HotelBookingRoomRates { get; set; }

    public virtual DbSet<HotelBookingRoomRatesOptional> HotelBookingRoomRatesOptionals { get; set; }

    public virtual DbSet<HotelBookingRoomsOptional> HotelBookingRoomsOptionals { get; set; }

    public virtual DbSet<HotelContact> HotelContacts { get; set; }

    public virtual DbSet<HotelGuest> HotelGuests { get; set; }

    public virtual DbSet<HotelPosition> HotelPositions { get; set; }

    public virtual DbSet<HotelRoom> HotelRooms { get; set; }

    public virtual DbSet<HotelSupplier> HotelSuppliers { get; set; }

    public virtual DbSet<HotelSurcharge> HotelSurcharges { get; set; }

    public virtual DbSet<ImageSize> ImageSizes { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<InvoiceRequest> InvoiceRequests { get; set; }

    public virtual DbSet<InvoiceRequestDetail> InvoiceRequestDetails { get; set; }

    public virtual DbSet<InvoiceRequestHistory> InvoiceRequestHistories { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<Label> Labels { get; set; }

    public virtual DbSet<Lession> Lessions { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuPermission> MenuPermissions { get; set; }

    public virtual DbSet<Mfauser> Mfausers { get; set; }

    public virtual DbSet<National> Nationals { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderBak> OrderBaks { get; set; }

    public virtual DbSet<OrderBookClosing> OrderBookClosings { get; set; }

    public virtual DbSet<OtherBooking> OtherBookings { get; set; }

    public virtual DbSet<OtherBookingPackage> OtherBookingPackages { get; set; }

    public virtual DbSet<OtherBookingPackagesOptional> OtherBookingPackagesOptionals { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentAccount> PaymentAccounts { get; set; }

    public virtual DbSet<PaymentRequest> PaymentRequests { get; set; }

    public virtual DbSet<PaymentRequestDetail> PaymentRequestDetails { get; set; }

    public virtual DbSet<PaymentVoucher> PaymentVouchers { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PlaygroundDetail> PlaygroundDetails { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    public virtual DbSet<PolicyDetail> PolicyDetails { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PriceDetail> PriceDetails { get; set; }

    public virtual DbSet<PriceLimitedSetting> PriceLimitedSettings { get; set; }

    public virtual DbSet<ProductFlyTicketService> ProductFlyTicketServices { get; set; }

    public virtual DbSet<ProductRoomService> ProductRoomServices { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<ProgramModification> ProgramModifications { get; set; }

    public virtual DbSet<ProgramPackage> ProgramPackages { get; set; }

    public virtual DbSet<ProgramPackageDaily> ProgramPackageDailies { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<ProvinceHotel> ProvinceHotels { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizAnswer> QuizAnswers { get; set; }

    public virtual DbSet<QuizResult> QuizResults { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<RoomFacility> RoomFacilities { get; set; }

    public virtual DbSet<RoomFun> RoomFuns { get; set; }

    public virtual DbSet<RoomPackage> RoomPackages { get; set; }

    public virtual DbSet<RunningScheduleService> RunningScheduleServices { get; set; }

    public virtual DbSet<ServiceDecline> ServiceDeclines { get; set; }

    public virtual DbSet<ServicePiceRoom> ServicePiceRooms { get; set; }

    public virtual DbSet<Source> Sources { get; set; }

    public virtual DbSet<SourceRelated> SourceRelateds { get; set; }

    public virtual DbSet<SourceTag> SourceTags { get; set; }

    public virtual DbSet<SourcesCategory> SourcesCategories { get; set; }

    public virtual DbSet<SourcesPrice> SourcesPrices { get; set; }

    public virtual DbSet<SportWaterGuest> SportWaterGuests { get; set; }

    public virtual DbSet<SportWaterPackage> SportWaterPackages { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierContact> SupplierContacts { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TelegramDetail> TelegramDetails { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<TourDestination> TourDestinations { get; set; }

    public virtual DbSet<TourGuest> TourGuests { get; set; }

    public virtual DbSet<TourPackage> TourPackages { get; set; }

    public virtual DbSet<TourPackagesOptional> TourPackagesOptionals { get; set; }

    public virtual DbSet<TourPosition> TourPositions { get; set; }

    public virtual DbSet<TourProduct> TourProducts { get; set; }

    public virtual DbSet<TourProgramPackage> TourProgramPackages { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAgent> UserAgents { get; set; }

    public virtual DbSet<UserDepart> UserDeparts { get; set; }

    public virtual DbSet<UserPosition> UserPositions { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<VinWonderBooking> VinWonderBookings { get; set; }

    public virtual DbSet<VinWonderBookingTicket> VinWonderBookingTickets { get; set; }

    public virtual DbSet<VinWonderBookingTicketCustomer> VinWonderBookingTicketCustomers { get; set; }

    public virtual DbSet<VinWonderBookingTicketDetail> VinWonderBookingTicketDetails { get; set; }

    public virtual DbSet<VinWonderPricePolicy> VinWonderPricePolicies { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    public virtual DbSet<VoucherCampaign> VoucherCampaigns { get; set; }

    public virtual DbSet<VoucherLogActivity> VoucherLogActivities { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=103.163.216.41;Initial Catalog=educationDb;Persist Security Info=True;User ID=us;Password=us@585668;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Account");

            entity.ToTable("AccountClient");

            entity.Property(e => e.ForgotPasswordToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordBackup)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Action>(entity =>
        {
            entity.ToTable("Action");

            entity.Property(e => e.ActionName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ControllerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Menu).WithMany(p => p.Actions)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK_Action_Menu");

            entity.HasOne(d => d.Permission).WithMany(p => p.Actions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK_Action_Permission");
        });

        modelBuilder.Entity<AddressClient>(entity =>
        {
            entity.ToTable("AddressClient");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DistrictId).HasMaxLength(5);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Đây là số điện thoại nhận hàng");
            entity.Property(e => e.ProvinceId).HasMaxLength(5);
            entity.Property(e => e.ReceiverName).HasMaxLength(255);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.WardId).HasMaxLength(5);
        });

        modelBuilder.Entity<AffiliateGroupProduct>(entity =>
        {
            entity.ToTable("AffiliateGroupProduct");
        });

        modelBuilder.Entity<AirPortCode>(entity =>
        {
            entity.ToTable("AirPortCode");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.DistrictEn)
                .HasMaxLength(100)
                .HasColumnName("District_En");
            entity.Property(e => e.DistrictVi)
                .HasMaxLength(100)
                .HasColumnName("District_Vi");
        });

        modelBuilder.Entity<Airline>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK_Airlines_1");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AirLineGroup)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Logo).HasMaxLength(150);
            entity.Property(e => e.NameEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_En");
            entity.Property(e => e.NameVi)
                .HasMaxLength(50)
                .HasColumnName("Name_Vi");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AllCode>(entity =>
        {
            entity.ToTable("AllCode");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.Type)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<AllotmentFund>(entity =>
        {
            entity.ToTable("AllotmentFund");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<AllotmentHistory>(entity =>
        {
            entity.ToTable("AllotmentHistory");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(200);

            entity.HasOne(d => d.AllotmentFund).WithMany(p => p.AllotmentHistories)
                .HasForeignKey(d => d.AllotmentFundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllotmentHistory_AllotmentFund");
        });

        modelBuilder.Entity<AllotmentUse>(entity =>
        {
            entity.ToTable("AllotmentUse");

            entity.Property(e => e.AllomentFundId).HasComment("Thông tin số tiền của quỹ đã được phân bổ");
            entity.Property(e => e.AmountUse).HasComment("Số tiền đã sử dụng cho dịch vụ");
            entity.Property(e => e.CreateDate)
                .HasComment("Ngày tạo đơn hàng")
                .HasColumnType("datetime");
            entity.Property(e => e.DataId).HasComment("Là lưu trữ id dịch vụ");

            entity.HasOne(d => d.AllomentFund).WithMany(p => p.AllotmentUses)
                .HasForeignKey(d => d.AllomentFundId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AllotmentUse_AllotmentFund");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.ToTable("Article");

            entity.Property(e => e.Body).HasColumnType("ntext");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DownTime).HasColumnType("datetime");
            entity.Property(e => e.Image11).HasMaxLength(350);
            entity.Property(e => e.Image169).HasMaxLength(350);
            entity.Property(e => e.Image43).HasMaxLength(350);
            entity.Property(e => e.Lead).HasMaxLength(400);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PublishDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UpTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ArticleCategory>(entity =>
        {
            entity.ToTable("ArticleCategory");
        });

        modelBuilder.Entity<ArticleRelated>(entity =>
        {
            entity.ToTable("ArticleRelated");

            entity.HasOne(d => d.Article).WithMany(p => p.ArticleRelateds)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("FK_ArticleRelated_Article");
        });

        modelBuilder.Entity<ArticleTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ArticleTags");

            entity.ToTable("ArticleTag");

            entity.HasOne(d => d.Article).WithMany(p => p.ArticleTags)
                .HasForeignKey(d => d.ArticleId)
                .HasConstraintName("FK_ArticleTags_Article");

            entity.HasOne(d => d.Tag).WithMany(p => p.ArticleTags)
                .HasForeignKey(d => d.TagId)
                .HasConstraintName("FK_ArticleTags_Tags");
        });

        modelBuilder.Entity<AttachFile>(entity =>
        {
            entity.ToTable("AttachFile");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Ext)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Path).HasMaxLength(400);
        });

        modelBuilder.Entity<Baggage>(entity =>
        {
            entity.ToTable("Baggage");

            entity.Property(e => e.Airline).HasMaxLength(50);
            entity.Property(e => e.Code).HasMaxLength(100);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.EndPoint).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.StartPoint).HasMaxLength(250);
            entity.Property(e => e.StatusCode).HasMaxLength(50);
            entity.Property(e => e.Value).HasMaxLength(250);
        });

        modelBuilder.Entity<BankOnePay>(entity =>
        {
            entity.ToTable("BankOnePay");

            entity.Property(e => e.BankName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bank_name");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.FullnameEn)
                .HasMaxLength(200)
                .HasColumnName("fullname_en");
            entity.Property(e => e.FullnameVi)
                .HasMaxLength(200)
                .HasColumnName("fullname_vi");
            entity.Property(e => e.Logo)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("logo");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<BankingAccount>(entity =>
        {
            entity.ToTable("BankingAccount");

            entity.Property(e => e.AccountName).HasMaxLength(200);
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BankId).HasMaxLength(200);
            entity.Property(e => e.Branch).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.BrandCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BrandName).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblPrice");

            entity.ToTable("Campaign");

            entity.Property(e => e.CampaignCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.ToDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateLast).HasColumnType("datetime");
        });

        modelBuilder.Entity<CampaignAd>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CampaignName).HasMaxLength(300);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(400);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Cashback>(entity =>
        {
            entity.ToTable("Cashback");

            entity.Property(e => e.CashbackDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
        });

        modelBuilder.Entity<Chapter>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tblAccount");

            entity.ToTable("Client");

            entity.Property(e => e.Avartar)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.BusinessAddress).HasMaxLength(200);
            entity.Property(e => e.ClientCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ClientName).HasMaxLength(256);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ExportBillAddress).HasMaxLength(200);
            entity.Property(e => e.IsReceiverInfoEmail).HasColumnName("isReceiverInfoEmail");
            entity.Property(e => e.JoinDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(400);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReferralId)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TaxNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ClientLinkAff>(entity =>
        {
            entity.ToTable("ClientLinkAff");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ClientId).ValueGeneratedOnAdd();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.LinkAff).IsUnicode(false);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.Property(e => e.AttachFile)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.AttachFileName).HasMaxLength(255);
            entity.Property(e => e.Content).HasMaxLength(1000);
            entity.Property(e => e.CreatedBy).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ContactClient>(entity =>
        {
            entity.ToTable("ContactClient");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.ToTable("Contract");

            entity.Property(e => e.ContractDate).HasColumnType("datetime");
            entity.Property(e => e.ContractNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.DebtType).HasComment("1: 7 ngày, 2: 15 ngày");
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.ServiceType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalVerify).HasComment("Tổng số lần được duyệt của hợp đồng. Cộng dồn sau mỗi lần duyệt");
            entity.Property(e => e.UpdateLast).HasColumnType("datetime");
            entity.Property(e => e.UserIdVerify).HasComment("AccountClientID là user sẽ duyệt hđ này");
            entity.Property(e => e.VerifyDate)
                .HasComment("Ngày duyệt hợp đồng")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ContractHistory>(entity =>
        {
            entity.ToTable("ContractHistory");

            entity.Property(e => e.Action).HasMaxLength(50);
            entity.Property(e => e.ActionDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ContractPay>(entity =>
        {
            entity.HasKey(e => e.PayId);

            entity.ToTable("ContractPay");

            entity.HasIndex(e => e.ClientId, "IX_ContractPay_ClientId");

            entity.Property(e => e.AttatchmentFile)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BillNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ExportDate)
                .HasComment("Ngày xuất hóa đơn")
                .HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.Note).HasMaxLength(300);
            entity.Property(e => e.PayType).HasComment("1: Tiền mặt , 2: Chuyển khoản");
            entity.Property(e => e.Type).HasComment("1:Thu tiền đơn hàng , 2: Thu tiền nạp quỹ");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ContractPayDetail>(entity =>
        {
            entity.ToTable("ContractPayDetail");

            entity.HasIndex(e => e.DataId, "IX_ContractPayDetail_DataId");

            entity.HasIndex(e => e.PayId, "IX_ContractPayDetail_PayId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DebtStatistic>(entity =>
        {
            entity.ToTable("DebtStatistic");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.DeclineReason).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.OrderIds)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.ToDate).HasColumnType("date");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VerifyDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentName).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.FullParent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsReport).HasDefaultValueSql("((1))");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<DepositHistory>(entity =>
        {
            entity.ToTable("DepositHistory");

            entity.Property(e => e.BankAccount).HasMaxLength(150);
            entity.Property(e => e.BankName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate)
                .HasComment("Thời gian giao dịch")
                .HasColumnType("datetime");
            entity.Property(e => e.ImageScreen)
                .HasMaxLength(200)
                .HasComment("Ảnh ủy nhiệm chi");
            entity.Property(e => e.NoteReject).HasMaxLength(300);
            entity.Property(e => e.PaymentType).HasComment("HÌnh thức thanh toán");
            entity.Property(e => e.Price).HasComment("Số tiền nạp");
            entity.Property(e => e.Status).HasComment("Trạng thái");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasComment("Tiêu đề nạp");
            entity.Property(e => e.TransNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Mã giao dịch");
            entity.Property(e => e.TransType).HasComment("Loại giao dịch");
            entity.Property(e => e.UpdateLast).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasComment("User nạp trans. Lấy user login");
            entity.Property(e => e.VerifyDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.ToTable("Discount");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__District__85FDA4C6D88CB461");

            entity.ToTable("District");

            entity.Property(e => e.DistrictId).HasMaxLength(5);
            entity.Property(e => e.Location).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NameNonUnicode)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ProvinceId).HasMaxLength(5);
            entity.Property(e => e.Type).HasMaxLength(30);
        });

        modelBuilder.Entity<FlightSegment>(entity =>
        {
            entity.ToTable("FlightSegment");

            entity.Property(e => e.AllowanceBaggage).HasMaxLength(50);
            entity.Property(e => e.Class).HasMaxLength(250);
            entity.Property(e => e.EndPoint).HasMaxLength(250);
            entity.Property(e => e.EndTerminal).HasMaxLength(250);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.FlightNumber).HasMaxLength(250);
            entity.Property(e => e.FlyBookingId).HasColumnName("FlyBookingID");
            entity.Property(e => e.HandBaggage).HasMaxLength(50);
            entity.Property(e => e.OperatingAirline).HasMaxLength(250);
            entity.Property(e => e.Plane).HasMaxLength(250);
            entity.Property(e => e.StartPoint).HasMaxLength(250);
            entity.Property(e => e.StartTerminal).HasMaxLength(250);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.StopPoint).HasMaxLength(250);
        });

        modelBuilder.Entity<FlyBookingDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ProductService");

            entity.ToTable("FlyBookingDetail");

            entity.HasIndex(e => e.OrderId, "IDX_FlyBookingDetail_OrderId");

            entity.Property(e => e.Adgcommission).HasColumnName("ADGCommission");
            entity.Property(e => e.Airline).HasMaxLength(50);
            entity.Property(e => e.BookingCode).HasMaxLength(250);
            entity.Property(e => e.Currency).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.EndPoint).HasMaxLength(50);
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.Flight).HasMaxLength(250);
            entity.Property(e => e.GroupBookingId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GroupClass).HasMaxLength(100);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Session).HasMaxLength(250);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.StartPoint).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<FlyBookingExtraPackage>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.GroupFlyBookingId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PackageCode).HasMaxLength(200);
            entity.Property(e => e.PackageId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<FlyBookingPackagesOptional>(entity =>
        {
            entity.ToTable("FlyBookingPackagesOptional");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PackageName).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GroupClassAirline>(entity =>
        {
            entity.Property(e => e.Airline)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ClassCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.DetailEn)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Detail_En");
            entity.Property(e => e.DetailVi)
                .HasMaxLength(50)
                .HasColumnName("Detail_Vi");
            entity.Property(e => e.FareType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GroupClassAirlinesDetail>(entity =>
        {
            entity.ToTable("GroupClassAirlinesDetail");

            entity.Property(e => e.Name).HasMaxLength(300);
        });

        modelBuilder.Entity<GroupProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_groupProduct");

            entity.ToTable("GroupProduct");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ImagePath)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(400);
            entity.Property(e => e.Path)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.ToTable("Hotel");

            entity.Property(e => e.CheckinTime).HasColumnType("datetime");
            entity.Property(e => e.CheckoutTime).HasColumnType("datetime");
            entity.Property(e => e.City).HasMaxLength(200);
            entity.Property(e => e.Country).HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Extends).HasColumnType("text");
            entity.Property(e => e.GroupName).HasMaxLength(200);
            entity.Property(e => e.HotelId)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.HotelType).HasMaxLength(200);
            entity.Property(e => e.ImageThumb).HasMaxLength(500);
            entity.Property(e => e.IsDisplayWebsite).HasDefaultValueSql("((0))");
            entity.Property(e => e.ListSupplierId)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.OtherSurcharge)
                .HasMaxLength(500)
                .HasComment("");
            entity.Property(e => e.ReviewRate).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.ShortName).HasMaxLength(50);
            entity.Property(e => e.Star).HasColumnType("decimal(6, 2)");
            entity.Property(e => e.State).HasMaxLength(500);
            entity.Property(e => e.Street).HasMaxLength(1000);
            entity.Property(e => e.TaxCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telephone)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfRoom).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelBankingAccount>(entity =>
        {
            entity.ToTable("HotelBankingAccount");

            entity.Property(e => e.AccountName).HasMaxLength(200);
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.BankId).HasMaxLength(100);
            entity.Property(e => e.Branch).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelBooking>(entity =>
        {
            entity.ToTable("HotelBooking");

            entity.HasIndex(e => e.OrderId, "IDX_HotelBooking_OrderId");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.ArrivalDate).HasColumnType("datetime");
            entity.Property(e => e.BookingId).HasMaxLength(100);
            entity.Property(e => e.CheckinTime).HasColumnType("datetime");
            entity.Property(e => e.CheckoutTime).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DepartureDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.HotelName).HasMaxLength(250);
            entity.Property(e => e.ImageThumb).HasMaxLength(750);
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.NumberOfAdult).HasColumnName("numberOfAdult");
            entity.Property(e => e.NumberOfChild).HasColumnName("numberOfChild");
            entity.Property(e => e.NumberOfInfant).HasColumnName("numberOfInfant");
            entity.Property(e => e.NumberOfPeople).HasColumnName("numberOfPeople");
            entity.Property(e => e.NumberOfRoom).HasColumnName("numberOfRoom");
            entity.Property(e => e.PropertyId).HasMaxLength(50);
            entity.Property(e => e.ReservationCode).HasMaxLength(150);
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telephone).HasMaxLength(150);
            entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");
            entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");
            entity.Property(e => e.TotalProfit).HasColumnName("totalProfit");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelBookingCode>(entity =>
        {
            entity.ToTable("HotelBookingCode");

            entity.Property(e => e.AttactFile)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BookingCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelBookingRoom>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsRoomFund).HasComment("");
            entity.Property(e => e.NumberOfAdult).HasColumnName("numberOfAdult");
            entity.Property(e => e.NumberOfChild).HasColumnName("numberOfChild");
            entity.Property(e => e.NumberOfInfant).HasColumnName("numberOfInfant");
            entity.Property(e => e.PackageIncludes).HasMaxLength(250);
            entity.Property(e => e.RoomTypeCode).HasMaxLength(50);
            entity.Property(e => e.RoomTypeId)
                .HasMaxLength(50)
                .HasColumnName("RoomTypeID");
            entity.Property(e => e.RoomTypeName).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelBookingRoomExtraPackage>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.HotelBookingRoomId).HasColumnName("HotelBookingRoomID");
            entity.Property(e => e.OperatorPrice).HasComment("Giá điều hành nhập 1 phòng/1 đêm");
            entity.Property(e => e.PackageCode).HasMaxLength(200);
            entity.Property(e => e.PackageId).HasMaxLength(50);
            entity.Property(e => e.SalePrice).HasComment("Giá sale nhập 1 phòng/1 đêm");
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelBookingRoomRate>(entity =>
        {
            entity.Property(e => e.AllotmentId).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.OperatorPrice).HasComment("Giá điều hành nhập 1 phòng/1 đêm");
            entity.Property(e => e.PackagesInclude).HasMaxLength(500);
            entity.Property(e => e.RatePlanCode).HasMaxLength(50);
            entity.Property(e => e.RatePlanId).HasMaxLength(50);
            entity.Property(e => e.SalePrice).HasComment("Giá sale nhập 1 phòng/1 đêm");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.StayDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelBookingRoomRatesOptional>(entity =>
        {
            entity.ToTable("HotelBookingRoomRatesOptional");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.OperatorPrice).HasComment("Giá điều hành nhập 1 phòng/1 đêm");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelBookingRoomsOptional>(entity =>
        {
            entity.ToTable("HotelBookingRoomsOptional");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PackageName).HasMaxLength(200);
            entity.Property(e => e.Price).HasComment("Giá đã trừ đi lợi nhuận");
            entity.Property(e => e.Profit).HasComment("Lợi nhuận");
            entity.Property(e => e.TotalAmount).HasComment("Tổng tiền dịch vụ khách phải trả");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelContact>(entity =>
        {
            entity.ToTable("HotelContact");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelGuest>(entity =>
        {
            entity.ToTable("HotelGuest");

            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.HotelBookingRoomsId).HasColumnName("HotelBookingRoomsID");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Note).HasMaxLength(250);
        });

        modelBuilder.Entity<HotelPosition>(entity =>
        {
            entity.ToTable("HotelPosition");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PositionType).HasComment("1: B2B, 2: B2C");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelRoom>(entity =>
        {
            entity.ToTable("HotelRoom");

            entity.Property(e => e.Avatar)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Extends).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsDisplayWebsite).HasDefaultValueSql("((0))");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.RoomAvatar)
                .HasMaxLength(8000)
                .IsUnicode(false);
            entity.Property(e => e.RoomId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Thumbnails)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.TypeOfRoom).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelSupplier>(entity =>
        {
            entity.ToTable("HotelSupplier");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<HotelSurcharge>(entity =>
        {
            entity.ToTable("HotelSurcharge");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FromDate)
                .HasComment("")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.ToDate)
                .HasComment("")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ImageSize>(entity =>
        {
            entity.ToTable("ImageSize");

            entity.Property(e => e.PositionName).HasMaxLength(250);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoice");

            entity.Property(e => e.AttactFile)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExportDate).HasColumnType("date");
            entity.Property(e => e.InvoiceCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceFromId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceSignId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("date");
            entity.Property(e => e.VerifyDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.ToTable("InvoiceDetail");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("date");
        });

        modelBuilder.Entity<InvoiceRequest>(entity =>
        {
            entity.ToTable("InvoiceRequest");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.AttachFile)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeclineReason).HasMaxLength(500);
            entity.Property(e => e.InvoiceRequestNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PlanDate).HasColumnType("date");
            entity.Property(e => e.TaxNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VerifyDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<InvoiceRequestDetail>(entity =>
        {
            entity.ToTable("InvoiceRequestDetail");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ProductName).HasMaxLength(500);
            entity.Property(e => e.Unit).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Vat).HasColumnName("VAT");
        });

        modelBuilder.Entity<InvoiceRequestHistory>(entity =>
        {
            entity.ToTable("InvoiceRequestHistory");

            entity.Property(e => e.Actioin).HasMaxLength(4000);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.ToTable("Job");

            entity.Property(e => e.Type).HasComment("1: sync client ; 2 : sync order");
        });

        modelBuilder.Entity<Label>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Store");

            entity.ToTable("Label");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.DescExpire).HasMaxLength(300);
            entity.Property(e => e.Domain)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Icon).HasMaxLength(500);
            entity.Property(e => e.PrefixOrderCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StoreName).HasMaxLength(50);
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Lession>(entity =>
        {
            entity.Property(e => e.Article).HasColumnType("ntext");
            entity.Property(e => e.Author).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.ThumbnailName).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VideoDuration)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.ToTable("Menu");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.FullParent)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Icon).HasMaxLength(50);
            entity.Property(e => e.Link).HasMaxLength(200);
            entity.Property(e => e.MenuCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<Mfauser>(entity =>
        {
            entity.ToTable("MFAUser");

            entity.Property(e => e.BackupCode)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SecretKey)
                .HasMaxLength(32)
                .IsFixedLength();
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            entity.Property(e => e.UserCreatedYear)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<National>(entity =>
        {
            entity.ToTable("National");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NameVn)
                .HasMaxLength(200)
                .HasColumnName("NameVN");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("Note");

            entity.Property(e => e.Comment).HasMaxLength(400);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("Order");

            entity.Property(e => e.BankCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ClosingEndDate).HasColumnType("datetime");
            entity.Property(e => e.ColorCode).HasMaxLength(10);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.DebtNote).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.EndDate)
                .HasComment("Ngay ket thuc dich vu")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpriryDate).HasColumnType("datetime");
            entity.Property(e => e.FinalizeDate).HasColumnType("date");
            entity.Property(e => e.IsLock).HasDefaultValueSql("((0))");
            entity.Property(e => e.Label).HasMaxLength(500);
            entity.Property(e => e.Note)
                .HasMaxLength(300)
                .HasComment("Chính là label so với wiframe");
            entity.Property(e => e.OperatorId)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.OrderNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentNo).HasMaxLength(250);
            entity.Property(e => e.ProductService)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Refund).HasDefaultValueSql("((0))");
            entity.Property(e => e.SalerGroupId)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.SmsContent).HasMaxLength(400);
            entity.Property(e => e.StartDate)
                .HasComment("ngay bat dau khoi tao dich vu")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdateLast).HasColumnType("datetime");
            entity.Property(e => e.UtmMedium)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UtmSource)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VerifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.ContactClient).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ContactClientId)
                .HasConstraintName("FK_Order_ContactClient");

            entity.HasOne(d => d.Contract).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_Order_Contract");
        });

        modelBuilder.Entity<OrderBak>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Order_bak");

            entity.Property(e => e.BankCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ColorCode).HasMaxLength(10);
            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ExpriryDate).HasColumnType("datetime");
            entity.Property(e => e.Label).HasMaxLength(500);
            entity.Property(e => e.Note).HasMaxLength(300);
            entity.Property(e => e.OrderId).ValueGeneratedOnAdd();
            entity.Property(e => e.OrderNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentNo).HasMaxLength(250);
            entity.Property(e => e.ProductService)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SalerGroupId)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.SmsContent).HasMaxLength(400);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateLast).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderBookClosing>(entity =>
        {
            entity.ToTable("OrderBookClosing");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FinalizeDate).HasColumnType("date");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.ToDate).HasColumnType("date");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OtherBooking>(entity =>
        {
            entity.ToTable("OtherBooking");

            entity.HasIndex(e => e.OrderId, "IDX_OtherBooking_OrderId");

            entity.Property(e => e.ConfNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.OperatorId).HasColumnName("OperatorID");
            entity.Property(e => e.RoomNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SerialNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceCode).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OtherBookingPackage>(entity =>
        {
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BasePrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Commission)
                .HasComment("")
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(400);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OtherBookingPackagesOptional>(entity =>
        {
            entity.ToTable("OtherBookingPackagesOptional");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PackageName).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.ToTable("Passenger");

            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.GroupBookingId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.MembershipCard)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Note).HasMaxLength(250);
            entity.Property(e => e.PersonType).HasMaxLength(100);

            entity.HasOne(d => d.Order).WithMany(p => p.Passengers)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Passenger_Order");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.ToTable("Payment");

            entity.Property(e => e.BankName).HasMaxLength(50);
            entity.Property(e => e.BotPaymentScreenShot).HasMaxLength(250);
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.DepositPaymentType).HasComment("loại thanh toán cho đối tượng nào. Đơn hàng hay nạp quỹ");
            entity.Property(e => e.ImageScreenShot).HasMaxLength(250);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.TransferContent).HasMaxLength(250);
        });

        modelBuilder.Entity<PaymentAccount>(entity =>
        {
            entity.ToTable("PaymentAccount");

            entity.Property(e => e.AccountName)
                .HasMaxLength(50)
                .HasComment("Tên chủ tài khoản");
            entity.Property(e => e.AccountNumb)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Số tài khoản");
            entity.Property(e => e.BankName)
                .HasMaxLength(50)
                .HasComment("Tên ngân hàng");
            entity.Property(e => e.Branch)
                .HasMaxLength(50)
                .HasComment("Chi nhánh");
        });

        modelBuilder.Entity<PaymentRequest>(entity =>
        {
            entity.ToTable("PaymentRequest");

            entity.HasIndex(e => e.SupplierId, "IX_PaymentRequest_SupplierId_Status");

            entity.Property(e => e.AbandonmentReason).HasMaxLength(500);
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BankAccount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BankName).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeclineReason).HasMaxLength(500);
            entity.Property(e => e.Description).HasMaxLength(3000);
            entity.Property(e => e.IsPaymentBefore).HasDefaultValueSql("((0))");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PaymentCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasComment("1: Thanh toán dịch vụ , 2: Thanh toán khác");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VerifyDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PaymentRequestDetail>(entity =>
        {
            entity.ToTable("PaymentRequestDetail");

            entity.HasIndex(e => e.RequestId, "IDX_PaymentRequestDetail_RequestId");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PaymentVoucher>(entity =>
        {
            entity.ToTable("PaymentVoucher");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.AttachFiles)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BankAccount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BankName).HasMaxLength(200);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PaymentCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RequestId)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("Id Phiếu yêu cầu chi");
            entity.Property(e => e.Type).HasComment("1: Thanh toán dịch vụ , 2: Thanh toán khác");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permission");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<PlaygroundDetail>(entity =>
        {
            entity.ToTable("PlaygroundDetail");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.LocationName).HasMaxLength(250);
            entity.Property(e => e.NewsId).HasComment("Bài viết liên quan");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.ToTable("Policy");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsPrivate).HasDefaultValueSql("((0))");
            entity.Property(e => e.PolicyCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PolicyName).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PolicyDetail>(entity =>
        {
            entity.ToTable("PolicyDetail");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.HotelDebtAmout).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HotelDepositAmout).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductFlyTicketDebtAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductFlyTicketDepositAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TourDebtAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TourDepositAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TouringCarDebtAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TouringCarDepositAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VinWonderDebtAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VinWonderDepositAmount).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Position");

            entity.Property(e => e.PositionName).HasMaxLength(250);
        });

        modelBuilder.Entity<PriceDetail>(entity =>
        {
            entity.ToTable("PriceDetail");

            entity.Property(e => e.DayList)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.MonthList)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ToDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PriceLimitedSetting>(entity =>
        {
            entity.ToTable("PriceLimitedSetting");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.UpdateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductFlyTicketService>(entity =>
        {
            entity.ToTable("ProductFlyTicketService");

            entity.Property(e => e.GroupProviderType)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Campaign).WithMany(p => p.ProductFlyTicketServices)
                .HasForeignKey(d => d.CampaignId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductFlyTicketService_Campaign");
        });

        modelBuilder.Entity<ProductRoomService>(entity =>
        {
            entity.ToTable("ProductRoomService");

            entity.Property(e => e.AllotmentsId)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PackageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoomId).HasComment("");
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.ProgramCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProgramName).HasMaxLength(500);
            entity.Property(e => e.ServiceName).HasMaxLength(500);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.StayEndDate).HasColumnType("datetime");
            entity.Property(e => e.StayStartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VerifyDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProgramModification>(entity =>
        {
            entity.ToTable("ProgramModification");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.VerifyDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProgramPackage>(entity =>
        {
            entity.ToTable("ProgramPackage");

            entity.Property(e => e.ApplyDate).HasColumnType("date");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.PackageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PackageName).HasMaxLength(200);
            entity.Property(e => e.RoomType).HasMaxLength(50);
            entity.Property(e => e.ToDate).HasColumnType("date");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProgramPackageDaily>(entity =>
        {
            entity.ToTable("ProgramPackageDaily");

            entity.Property(e => e.ApplyDate).HasColumnType("date");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.PackageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PackageName).HasMaxLength(200);
            entity.Property(e => e.RoomType).HasMaxLength(50);
            entity.Property(e => e.ToDate).HasColumnType("date");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Province__FD0A6F838767F971");

            entity.ToTable("Province");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NameNonUnicode)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ProvinceId).HasMaxLength(5);
            entity.Property(e => e.Type).HasMaxLength(30);
        });

        modelBuilder.Entity<ProvinceHotel>(entity =>
        {
            entity.ToTable("ProvinceHotel");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.ToTable("Quiz");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("date");
        });

        modelBuilder.Entity<QuizAnswer>(entity =>
        {
            entity.ToTable("QuizAnswer");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("date");
        });

        modelBuilder.Entity<QuizResult>(entity =>
        {
            entity.ToTable("QuizResult");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("date");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("Request");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.HotelId)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.RequestNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ToDate).HasColumnType("date");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.ToTable("RolePermission");

            entity.HasOne(d => d.Menu).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Menu");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Permission");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolePermission_Role");
        });

        modelBuilder.Entity<RoomFacility>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<RoomFun>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RoomFun_1");

            entity.ToTable("RoomFun");

            entity.Property(e => e.AllotmentId)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.AllotmentName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.HotelId).IsUnicode(false);
            entity.Property(e => e.HotelName).HasMaxLength(250);
            entity.Property(e => e.UpdateLast).HasColumnType("datetime");
        });

        modelBuilder.Entity<RoomPackage>(entity =>
        {
            entity.ToTable("RoomPackage");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.PackageId).IsUnicode(false);
            entity.Property(e => e.UpdateLast).HasColumnType("datetime");

            entity.HasOne(d => d.RoomFun).WithMany(p => p.RoomPackages)
                .HasForeignKey(d => d.RoomFunId)
                .HasConstraintName("FK_RoomPackage_RoomFun1");
        });

        modelBuilder.Entity<RunningScheduleService>(entity =>
        {
            entity.ToTable("RunningScheduleService");

            entity.Property(e => e.LogDate).HasColumnType("datetime");

            entity.HasOne(d => d.Price).WithMany(p => p.RunningScheduleServices)
                .HasForeignKey(d => d.PriceId)
                .HasConstraintName("FK_RunningScheduleService_Price");
        });

        modelBuilder.Entity<ServiceDecline>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.ServiceId)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("date");
        });

        modelBuilder.Entity<ServicePiceRoom>(entity =>
        {
            entity.ToTable("ServicePiceRoom");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.HotelId)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.RoomCode).HasMaxLength(100);
            entity.Property(e => e.RoomId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RoomName).HasMaxLength(250);
            entity.Property(e => e.UpdateLast).HasColumnType("datetime");

            entity.HasOne(d => d.RoomPackage).WithMany(p => p.ServicePiceRooms)
                .HasForeignKey(d => d.RoomPackageId)
                .HasConstraintName("FK_ServicePiceRoom_RoomPackage");
        });

        modelBuilder.Entity<Source>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.DownTime).HasColumnType("datetime");
            entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PublishDate).HasColumnType("datetime");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SourceRelated>(entity =>
        {
            entity.ToTable("SourceRelated");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SourceTag>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SourcesCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SourcesTopics");

            entity.ToTable("SourcesCategory");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SourcesPrice>(entity =>
        {
            entity.ToTable("SourcesPrice");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.ToDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SportWaterGuest>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.RoomNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(200);
        });

        modelBuilder.Entity<SportWaterPackage>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EffectDate).HasColumnType("datetime");
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(500);
            entity.Property(e => e.IsDisplayWebsite).HasDefaultValueSql("((0))");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ResidenceType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShortName).HasMaxLength(50);
            entity.Property(e => e.SupplierCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TaxCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SupplierContact>(entity =>
        {
            entity.ToTable("SupplierContact");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Position).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tags");

            entity.ToTable("Tag");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.TagName).HasMaxLength(100);
        });

        modelBuilder.Entity<TelegramDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Telegram");

            entity.ToTable("TelegramDetail");

            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.GroupChatId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GroupLog).HasMaxLength(80);
            entity.Property(e => e.Token)
                .HasMaxLength(400)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.TopicName).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.ToTable("Tour");

            entity.HasIndex(e => e.OrderId, "IDX_Tour_OrderId");

            entity.Property(e => e.AdditionInfo).HasColumnType("text");
            entity.Property(e => e.Avatar)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Image)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.IsDisplayWeb).HasDefaultValueSql("((0))");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Schedule).HasColumnType("text");
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TourDestination>(entity =>
        {
            entity.ToTable("TourDestination");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasComment("Lưu theo Tour Type ");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TourGuest>(entity =>
        {
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Cccd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CCCD");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TourPackage>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PackageCode).HasMaxLength(50);
            entity.Property(e => e.PackageName).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Vat).HasColumnName("VAT");
        });

        modelBuilder.Entity<TourPackagesOptional>(entity =>
        {
            entity.ToTable("TourPackagesOptional");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.PackageName).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TourPosition>(entity =>
        {
            entity.ToTable("TourPosition");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.PositionType).HasComment("1: B2C , 2: B2B");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TourProduct>(entity =>
        {
            entity.ToTable("TourProduct");

            entity.Property(e => e.AdditionInfo).HasColumnType("ntext");
            entity.Property(e => e.Avatar)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateDeparture).HasMaxLength(500);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.Exclude).HasColumnType("ntext");
            entity.Property(e => e.Image)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Include).HasColumnType("ntext");
            entity.Property(e => e.IsDelete).HasDefaultValueSql("((0))");
            entity.Property(e => e.IsDisplayWeb).HasDefaultValueSql("((0))");
            entity.Property(e => e.Note).HasColumnType("ntext");
            entity.Property(e => e.Refund).HasColumnType("ntext");
            entity.Property(e => e.Schedule).HasColumnType("ntext");
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Surcharge).HasColumnType("ntext");
            entity.Property(e => e.TourName).HasMaxLength(200);
            entity.Property(e => e.Transportation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TourProgramPackage>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("date");
            entity.Property(e => e.IsDaily).HasDefaultValueSql("((0))");
            entity.Property(e => e.ToDate).HasColumnType("date");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(e => e.BankReference)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.ContractNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.TransactionNo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VerifyDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User_1");

            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Avata).HasMaxLength(500);
            entity.Property(e => e.BirthDay).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(500);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(2500);
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ResetPassword)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserAgent>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK_UserAgent_1");

            entity.ToTable("UserAgent");

            entity.Property(e => e.ClientId).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.MainFollow).HasComment("Quyền danh cho  0: Đối tác | 1: nhân viên của đối tác | 2: Saler phụ trách chính | 3: saler phụ trách cùng");
            entity.Property(e => e.UpdateLast).HasColumnType("datetime");
            entity.Property(e => e.VerifyDate).HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithOne(p => p.UserAgent)
                .HasForeignKey<UserAgent>(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAgent_Client");

            entity.HasOne(d => d.User).WithMany(p => p.UserAgents)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAgent_User");
        });

        modelBuilder.Entity<UserDepart>(entity =>
        {
            entity.ToTable("UserDepart");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.JoinDate).HasColumnType("date");
            entity.Property(e => e.LeaveDate).HasColumnType("date");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserPosition>(entity =>
        {
            entity.ToTable("UserPosition");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_Role");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRole_User");
        });

        modelBuilder.Entity<VinWonderBooking>(entity =>
        {
            entity.ToTable("VinWonderBooking");

            entity.HasIndex(e => e.OrderId, "IDX_VinWonderBooking_OrderId");

            entity.Property(e => e.AdavigoBookingId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SiteCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SiteName).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VinWonderBookingTicket>(entity =>
        {
            entity.ToTable("VinWonderBookingTicket");

            entity.Property(e => e.Adt).HasColumnName("adt");
            entity.Property(e => e.Child).HasColumnName("child");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateUsed).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.Old).HasColumnName("old");
            entity.Property(e => e.RateCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VinWonderBookingTicketCustomer>(entity =>
        {
            entity.ToTable("VinWonderBookingTicketCustomer");

            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Genre).HasMaxLength(20);
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.Property(e => e.OtherDetail).HasColumnType("text");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VinWonderBookingTicketDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_VinWonderBookingTickeDetail");

            entity.ToTable("VinWonderBookingTicketDetail");

            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DateFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTo).HasColumnType("datetime");
            entity.Property(e => e.GateCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GateName).HasMaxLength(50);
            entity.Property(e => e.GroupName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.ServiceKey)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ShortName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TypeCode).HasMaxLength(20);
            entity.Property(e => e.TypeName).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Vatpercent).HasColumnName("VATPercent");
            entity.Property(e => e.WeekDays)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VinWonderPricePolicy>(entity =>
        {
            entity.ToTable("VinWonderPricePolicy");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(300);
            entity.Property(e => e.ServiceCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceId).HasComment("Khóa chính của các loại vé theo tên đặt bên Vinwonder");
            entity.Property(e => e.SiteName).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Campaign).WithMany(p => p.VinWonderPricePolicies)
                .HasForeignKey(d => d.CampaignId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VinWonderPricePolicy_Campaign");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.ToTable("Voucher");

            entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
            entity.Property(e => e.Cdate)
                .HasColumnType("datetime")
                .HasColumnName("cdate");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EDate)
                .HasColumnType("datetime")
                .HasColumnName("eDate");
            entity.Property(e => e.GroupUserPriority)
                .IsUnicode(false)
                .HasComment("Trường này để lưu nhóm những user được áp dụng trên voucher này")
                .HasColumnName("group_user_priority");
            entity.Property(e => e.IsLimitVoucher).HasColumnName("is_limit_voucher");
            entity.Property(e => e.IsMaxPriceProduct).HasColumnName("is_max_price_product");
            entity.Property(e => e.IsPublic)
                .HasComment("Nêu set true thì hiểu voucher này được public cho các user thanh toán đơn hàng")
                .HasColumnName("is_public");
            entity.Property(e => e.LimitTotalDiscount).HasColumnName("limit_total_discount");
            entity.Property(e => e.LimitUse).HasColumnName("limitUse");
            entity.Property(e => e.MinTotalAmount).HasColumnName("min_total_amount");
            entity.Property(e => e.PriceSales)
                .HasColumnType("money")
                .HasColumnName("price_sales");
            entity.Property(e => e.RuleType)
                .HasComment("Trường này dùng để phân biệt voucher triển khai này chạy theo rule nào. Ví dụ: rule giảm giá với 1 số tiền vnđ trên toàn bộ đơn hàng. Giảm giá 20% phí first pound đầu tiên của nhãn hàng amazon. 1: triển khai rule giảm giá cho toàn bộ đơn hàng. 2 là rule áp dụng cho 20% phí first pound đầu tiên.")
                .HasColumnName("rule_type");
            entity.Property(e => e.StoreApply)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("store_apply");
            entity.Property(e => e.Udate)
                .HasColumnType("datetime")
                .HasColumnName("udate");
            entity.Property(e => e.Unit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("unit");
        });

        modelBuilder.Entity<VoucherCampaign>(entity =>
        {
            entity.ToTable("VoucherCampaign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CampaignVoucher)
                .HasMaxLength(400)
                .HasColumnName("campaign_voucher");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");
        });

        modelBuilder.Entity<VoucherLogActivity>(entity =>
        {
            entity.ToTable("voucherLogActivity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.CreateDate)
                .HasColumnType("datetime")
                .HasColumnName("create_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PriceSaleVnd).HasColumnName("price_sale_vnd");
            entity.Property(e => e.Status)
                .HasComment("Trang thai giao dịch voucher. 1: khoa. 0: dang ap dung")
                .HasColumnName("status");
            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.UpdateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VoucherId).HasColumnName("voucher_id");

            entity.HasOne(d => d.Voucher).WithMany(p => p.VoucherLogActivities)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK_voucherLogActivity_Voucher");
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ward__C6BD9BCA1EF01D69");

            entity.ToTable("Ward");

            entity.Property(e => e.DistrictId).HasMaxLength(5);
            entity.Property(e => e.Location).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.NameNonUnicode)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Type).HasMaxLength(30);
            entity.Property(e => e.WardId).HasMaxLength(5);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
