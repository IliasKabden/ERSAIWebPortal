namespace DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ERSAI;

    public partial class ERSAIContext : IdentityDbContext<AppUser, AppRole, string, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public ERSAIContext()
            : base("ERSAIConnectionString")
        {
        }
        public static ERSAIContext Create()
        {
            return new ERSAIContext();
        }
        #region ERSAI Tables
        public virtual DbSet<AccommodationBuilding> AccommodationBuildings { get; set; }
        public virtual DbSet<AccommodationHistory> AccommodationHistories { get; set; }
        public virtual DbSet<AccommodationLiveType> AccommodationLiveTypes { get; set; }
        public virtual DbSet<AccommodationRoom> AccommodationRooms { get; set; }
        public virtual DbSet<AccommodationRoomStatus> AccommodationRoomStatuses { get; set; }
        public virtual DbSet<AccommodationRoomType> AccommodationRoomTypes { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<approval> approvals { get; set; }
        public virtual DbSet<Audit_Statuses> Audit_Statuses { get; set; }
        public virtual DbSet<Audit_Types> Audit_Types { get; set; }
        public virtual DbSet<Audit> Audits { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<elAnswer> elAnswers { get; set; }
        public virtual DbSet<elAssignment> elAssignments { get; set; }
        public virtual DbSet<elDepartment_DistribList> elDepartment_DistribList { get; set; }
        public virtual DbSet<elQuestion> elQuestions { get; set; }
        public virtual DbSet<elStatus> elStatuses { get; set; }
        public virtual DbSet<elTest> elTests { get; set; }
        public virtual DbSet<elTrainer> elTrainers { get; set; }
        public virtual DbSet<elTraining> elTrainings { get; set; }
        public virtual DbSet<Emlpoyee_Statuses> Emlpoyee_Statuses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeesMobilePhone> EmployeesMobilePhones { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<ICTOperator> ICTOperators { get; set; }
        public virtual DbSet<ICTStaff> ICTStaffs { get; set; }
        public virtual DbSet<ICTStatistic> ICTStatistics { get; set; }
        public virtual DbSet<InventoryCompany> InventoryCompanies { get; set; }
        public virtual DbSet<InventoryComputerModel> InventoryComputerModels { get; set; }
        public virtual DbSet<InventoryComputer> InventoryComputers { get; set; }
        public virtual DbSet<InventoryIPPhoneModel> InventoryIPPhoneModels { get; set; }
        public virtual DbSet<InventoryIPPhone> InventoryIPPhones { get; set; }
        public virtual DbSet<InventoryLocation> InventoryLocations { get; set; }
        public virtual DbSet<InventoryMobilePhoneModel> InventoryMobilePhoneModels { get; set; }
        public virtual DbSet<InventoryMobilePhone> InventoryMobilePhones { get; set; }
        public virtual DbSet<InventoryMonitorModel> InventoryMonitorModels { get; set; }
        public virtual DbSet<InventoryMonitor> InventoryMonitors { get; set; }
        public virtual DbSet<InventoryNetworkEquipment> InventoryNetworkEquipments { get; set; }
        public virtual DbSet<InventoryOtherHardware> InventoryOtherHardwares { get; set; }
        public virtual DbSet<InventoryPrinterModel> InventoryPrinterModels { get; set; }
        public virtual DbSet<InventoryPrinter> InventoryPrinters { get; set; }
        public virtual DbSet<InventoryRadioModel> InventoryRadioModels { get; set; }
        public virtual DbSet<InventoryRadio> InventoryRadios { get; set; }
        public virtual DbSet<InventorySAPUser> InventorySAPUsers { get; set; }
        public virtual DbSet<InventoryServerModel> InventoryServerModels { get; set; }
        public virtual DbSet<InventoryServer> InventoryServers { get; set; }
        public virtual DbSet<InventoryStatus> InventoryStatuses { get; set; }
        public virtual DbSet<InventoryToken> InventoryTokens { get; set; }
        public virtual DbSet<KPIDoc> KPIDocs { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<MonthName> MonthNames { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<PersonalAccountUser> PersonalAccountUsers { get; set; }
        public virtual DbSet<PermissionLevel> PermissionLevels { get; set; }
        public virtual DbSet<PhoneDirectory> PhoneDirectories { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectsDevelopment> ProjectsDevelopments { get; set; }
        public virtual DbSet<RequestAbsence> RequestAbsences { get; set; }
        public virtual DbSet<RequestApprovalType> RequestApprovalTypes { get; set; }
        public virtual DbSet<RequestFacility> RequestFacilities { get; set; }
        public virtual DbSet<RequestFacilityApprovalType> RequestFacilityApprovalTypes { get; set; }
        public virtual DbSet<RequestFacilityPhoneAccess> RequestFacilityPhoneAccesses { get; set; }
        public virtual DbSet<RequestHelpdesk> RequestHelpdesks { get; set; }
        public virtual DbSet<RequestHelpdeskCategory> RequestHelpdeskCategories { get; set; }
        public virtual DbSet<RequestHelpdeskPriority> RequestHelpdeskPriorities { get; set; }
        public virtual DbSet<RequestICTTask> RequestICTTasks { get; set; }
        public virtual DbSet<RequestICTTaskCategory> RequestICTTaskCategories { get; set; }
        public virtual DbSet<RequestInfrastructure> RequestInfrastructures { get; set; }
        public virtual DbSet<RequestInfrastructureComment> RequestInfrastructureComments { get; set; }
        public virtual DbSet<RequestPriority> RequestPriorities { get; set; }
        public virtual DbSet<RequestPublicACL> RequestPublicACLs { get; set; }
        public virtual DbSet<RequestPublicACLAccessType> RequestPublicACLAccessTypes { get; set; }
        public virtual DbSet<RequestPublicACLComment> RequestPublicACLComments { get; set; }
        public virtual DbSet<RequestPublicACLDistributionList> RequestPublicACLDistributionLists { get; set; }
        public virtual DbSet<RequestRadio> RequestRadios { get; set; }
        public virtual DbSet<RequestRadioApprovalHistory> RequestRadioApprovalHistories { get; set; }
        public virtual DbSet<RequestSimCardAndMobilePhone> RequestSimCardAndMobilePhones { get; set; }
        public virtual DbSet<RequestSimCardAndMobilePhoneApprovalHistory> RequestSimCardAndMobilePhoneApprovalHistories { get; set; }
        public virtual DbSet<RequestSimCardAndMobilePhoneComment> RequestSimCardAndMobilePhoneComments { get; set; }
        public virtual DbSet<RequestSimCardAndMobilePhonePerformer> RequestSimCardAndMobilePhonePerformers { get; set; }
        public virtual DbSet<RequestSimCardAndMobilePhoneTariffPlan> RequestSimCardAndMobilePhoneTariffPlans { get; set; }
        public virtual DbSet<RequestStatus> RequestStatuses { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<RequestWifi> RequestWifis { get; set; }
        public virtual DbSet<RequestWifiDevice> RequestWifiDevices { get; set; }
        public virtual DbSet<RequestWifiDeviceType> RequestWifiDeviceTypes { get; set; }
        public virtual DbSet<RequestWifiGroup> RequestWifiGroups { get; set; }
        public virtual DbSet<RquestAbsenceHistory> RquestAbsenceHistories { get; set; }
        public virtual DbSet<Signature> Signatures { get; set; }
        public virtual DbSet<Site> Sites { get; set; }
        public virtual DbSet<SupervisorManager> SupervisorManagers { get; set; }
        public virtual DbSet<TechnicalEvaluation> TechnicalEvaluations { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<test4> test4 { get; set; }
        public virtual DbSet<test41> test41 { get; set; }
        public virtual DbSet<TestAdmin> TestAdmins { get; set; }
        public virtual DbSet<TestAnswer> TestAnswers { get; set; }
        public virtual DbSet<TestHistory> TestHistories { get; set; }
        public virtual DbSet<TestHistory_ARC> TestHistory_ARC { get; set; }
        public virtual DbSet<TestQuestion> TestQuestions { get; set; }
        public virtual DbSet<TransferAndAcceptanceOfICTEquipment> TransferAndAcceptanceOfICTEquipments { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<VideoConferenceCallAlias> VideoConferenceCallAliases { get; set; }
        public virtual DbSet<WorkLocation> WorkLocations { get; set; }
        public virtual DbSet<elMaterial> elMaterials { get; set; }
        public virtual DbSet<Employee_ARC> Employee_ARC { get; set; }
        public virtual DbSet<ICTStaff_Temp_Access> ICTStaff_Temp_Access { get; set; }
        public virtual DbSet<InventoryHistory> InventoryHistories { get; set; }
        public virtual DbSet<InventoryNetworkEquipments_ARC> InventoryNetworkEquipments_ARC { get; set; }
        public virtual DbSet<RequestFacilityApprovalHistory> RequestFacilityApprovalHistories { get; set; }
        public virtual DbSet<RequestFacilityComment> RequestFacilityComments { get; set; }
        public virtual DbSet<RequestHelpdeskComment> RequestHelpdeskComments { get; set; }
        public virtual DbSet<RequestICTTaskComment> RequestICTTaskComments { get; set; }
        public virtual DbSet<RequestPerformer> RequestPerformers { get; set; }
        public virtual DbSet<RequestPublicACLRequestType> RequestPublicACLRequestTypes { get; set; }
        public virtual DbSet<RequestRadioComment> RequestRadioComments { get; set; }
        public virtual DbSet<RequestWifiApprovalHistory> RequestWifiApprovalHistories { get; set; }
        public virtual DbSet<RequestWifiComment> RequestWifiComments { get; set; }
        public virtual DbSet<VisitorsCouter_Data> VisitorsCouter_Data { get; set; }
        #endregion
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>().ToTable("__AppUsers");
            modelBuilder.Entity<AppRole>().ToTable("__AppRoles");
            modelBuilder.Entity<AppUserClaim>().ToTable("__AppUserClaims");
            modelBuilder.Entity<AppUserLogin>().ToTable("__AppUserLogins");
            modelBuilder.Entity<AppUserRole>().ToTable("__AppUserRoles");

            #region ERSAI
            modelBuilder.Entity<AccommodationBuilding>()
                .HasMany(e => e.AccommodationRooms)
                .WithRequired(e => e.AccommodationBuilding)
                .HasForeignKey(e => e.BuildingID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<AccommodationLiveType>()
                .HasMany(e => e.AccommodationRooms)
                .WithOptional(e => e.AccommodationLiveType)
                .HasForeignKey(e => e.LiveTypeID);
            modelBuilder.Entity<AccommodationRoom>()
                .HasMany(e => e.AccommodationHistories)
                .WithRequired(e => e.AccommodationRoom)
                .HasForeignKey(e => e.RoomID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<AccommodationRoomStatus>()
                .HasMany(e => e.AccommodationRooms)
                .WithOptional(e => e.AccommodationRoomStatus)
                .HasForeignKey(e => e.RoomStatusID);
            modelBuilder.Entity<AccommodationRoomType>()
                .HasMany(e => e.AccommodationRooms)
                .WithOptional(e => e.AccommodationRoomType)
                .HasForeignKey(e => e.TypeID);
            modelBuilder.Entity<Company>()
                .HasMany(e => e.InventoryComputers)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>()
                .HasMany(e => e.InventoryIPPhones)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>()
                .HasMany(e => e.InventoryMonitors)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>()
                .HasMany(e => e.InventoryNetworkEquipments)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>()
                .HasMany(e => e.InventoryPrinters)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>()
                .HasMany(e => e.InventoryRadios)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>()
                .HasMany(e => e.InventoryServers)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Company>()
                .HasMany(e => e.InventoryTokens)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Audits)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.Department_ID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryComputerModel>()
                .HasMany(e => e.InventoryComputers)
                .WithRequired(e => e.InventoryComputerModel)
                .HasForeignKey(e => e.ModelID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryIPPhoneModel>()
                .HasMany(e => e.InventoryIPPhones)
                .WithRequired(e => e.InventoryIPPhoneModel)
                .HasForeignKey(e => e.ModelID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryComputers)
                .WithRequired(e => e.InventoryLocation)
                .HasForeignKey(e => e.LocationID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryComputers1)
                .WithRequired(e => e.InventoryLocation1)
                .HasForeignKey(e => e.SiteID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryIPPhones)
                .WithRequired(e => e.InventoryLocation)
                .HasForeignKey(e => e.LocationID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryIPPhones1)
                .WithRequired(e => e.InventoryLocation1)
                .HasForeignKey(e => e.SiteID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryMonitors)
                .WithRequired(e => e.InventoryLocation)
                .HasForeignKey(e => e.LocationID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryMonitors1)
                .WithRequired(e => e.InventoryLocation1)
                .HasForeignKey(e => e.SiteID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryNetworkEquipments)
                .WithRequired(e => e.InventoryLocation)
                .HasForeignKey(e => e.LocationID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryNetworkEquipments1)
                .WithRequired(e => e.InventoryLocation1)
                .HasForeignKey(e => e.SiteID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryPrinters)
                .WithRequired(e => e.InventoryLocation)
                .HasForeignKey(e => e.LocationID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryPrinters1)
                .WithRequired(e => e.InventoryLocation1)
                .HasForeignKey(e => e.SiteID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryPrinters2)
                .WithRequired(e => e.InventoryLocation2)
                .HasForeignKey(e => e.SiteID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryServers)
                .WithRequired(e => e.InventoryLocation)
                .HasForeignKey(e => e.LocationID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryServers1)
                .WithRequired(e => e.InventoryLocation1)
                .HasForeignKey(e => e.SiteID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryLocation>()
                .HasMany(e => e.InventoryTokens)
                .WithRequired(e => e.InventoryLocation)
                .HasForeignKey(e => e.CreationPlaceID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryMobilePhone>()
                .HasMany(e => e.RequestSimCardAndMobilePhones)
                .WithOptional(e => e.InventoryMobilePhone)
                .HasForeignKey(e => e.MobilePhoneID);
            modelBuilder.Entity<InventoryMonitorModel>()
                .HasMany(e => e.InventoryMonitors)
                .WithRequired(e => e.InventoryMonitorModel)
                .HasForeignKey(e => e.ModelID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryPrinterModel>()
                .HasMany(e => e.InventoryPrinters)
                .WithRequired(e => e.InventoryPrinterModel)
                .HasForeignKey(e => e.ModelID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryRadioModel>()
                .HasMany(e => e.InventoryRadios)
                .WithRequired(e => e.InventoryRadioModel)
                .HasForeignKey(e => e.ModelID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryRadio>()
                .HasMany(e => e.RequestRadios)
                .WithOptional(e => e.InventoryRadio)
                .HasForeignKey(e => e.RadioID);
            modelBuilder.Entity<InventoryServerModel>()
                .HasMany(e => e.InventoryServers)
                .WithRequired(e => e.InventoryServerModel)
                .HasForeignKey(e => e.ModelID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryStatus>()
                .HasMany(e => e.InventoryComputers)
                .WithRequired(e => e.InventoryStatus)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryStatus>()
                .HasMany(e => e.InventoryIPPhones)
                .WithRequired(e => e.InventoryStatus)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryStatus>()
                .HasMany(e => e.InventoryMonitors)
                .WithRequired(e => e.InventoryStatus)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryStatus>()
                .HasMany(e => e.InventoryNetworkEquipments)
                .WithRequired(e => e.InventoryStatus)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryStatus>()
                .HasMany(e => e.InventoryPrinters)
                .WithRequired(e => e.InventoryStatus)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryStatus>()
                .HasMany(e => e.InventoryRadios)
                .WithRequired(e => e.InventoryStatus)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InventoryStatus>()
                .HasMany(e => e.InventoryServers)
                .WithRequired(e => e.InventoryStatus)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Language>()
                .Property(e => e.Code)
                .IsUnicode(false);
            modelBuilder.Entity<ProjectsDevelopment>()
                .Property(e => e.ContactBadgeNumber)
                .IsFixedLength();
            modelBuilder.Entity<RequestApprovalType>()
                .HasMany(e => e.RequestRadioApprovalHistories)
                .WithRequired(e => e.RequestApprovalType)
                .HasForeignKey(e => e.ApprovalTypeID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestApprovalType>()
                .HasMany(e => e.RequestSimCardAndMobilePhoneApprovalHistories)
                .WithRequired(e => e.RequestApprovalType)
                .HasForeignKey(e => e.ApprovalTypeID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestApprovalType>()
                .HasMany(e => e.RequestWifiApprovalHistories)
                .WithRequired(e => e.RequestApprovalType)
                .HasForeignKey(e => e.ApprovalTypeID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestFacility>()
                .HasMany(e => e.RequestFacilityApprovalHistories)
                .WithRequired(e => e.RequestFacility)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestFacility>()
                .HasMany(e => e.RequestFacilityComments)
                .WithRequired(e => e.RequestFacility)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestFacilityApprovalType>()
                .HasMany(e => e.RequestFacilityApprovalHistories)
                .WithRequired(e => e.RequestFacilityApprovalType)
                .HasForeignKey(e => e.ApprovalTypeID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestFacilityPhoneAccess>()
                .HasMany(e => e.RequestFacilities)
                .WithRequired(e => e.RequestFacilityPhoneAccess)
                .HasForeignKey(e => e.PhoneAccessID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestHelpdesk>()
                .HasMany(e => e.RequestHelpdeskComments)
                .WithRequired(e => e.RequestHelpdesk)
                .HasForeignKey(e => e.RequestID);
            modelBuilder.Entity<RequestHelpdeskCategory>()
                .Property(e => e.Short_Label)
                .IsUnicode(false);
            modelBuilder.Entity<RequestHelpdeskCategory>()
                .HasMany(e => e.RequestHelpdesks)
                .WithRequired(e => e.RequestHelpdeskCategory)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestHelpdeskPriority>()
                .HasMany(e => e.RequestHelpdesks)
                .WithRequired(e => e.RequestHelpdeskPriority)
                .HasForeignKey(e => e.PriorityID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestICTTask>()
                .HasMany(e => e.RequestICTTaskComments)
                .WithRequired(e => e.RequestICTTask)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestICTTaskCategory>()
                .HasMany(e => e.RequestICTTasks)
                .WithRequired(e => e.RequestICTTaskCategory)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestInfrastructure>()
                .HasMany(e => e.RequestInfrastructureComments)
                .WithRequired(e => e.RequestInfrastructure)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestPriority>()
                .HasMany(e => e.RequestICTTasks)
                .WithRequired(e => e.RequestPriority)
                .HasForeignKey(e => e.PriorityID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestRadio>()
                .HasMany(e => e.RequestRadioApprovalHistories)
                .WithRequired(e => e.RequestRadio)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestRadio>()
                .HasMany(e => e.RequestRadioComments)
                .WithRequired(e => e.RequestRadio)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestSimCardAndMobilePhone>()
                .HasMany(e => e.RequestSimCardAndMobilePhoneApprovalHistories)
                .WithRequired(e => e.RequestSimCardAndMobilePhone)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestSimCardAndMobilePhone>()
                .HasMany(e => e.RequestSimCardAndMobilePhoneComments)
                .WithRequired(e => e.RequestSimCardAndMobilePhone)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestSimCardAndMobilePhoneTariffPlan>()
                .HasMany(e => e.RequestSimCardAndMobilePhones)
                .WithRequired(e => e.RequestSimCardAndMobilePhoneTariffPlan)
                .HasForeignKey(e => e.TariffPlanID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestStatus>()
                .HasMany(e => e.RequestHelpdesks)
                .WithRequired(e => e.RequestStatus)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestStatus>()
                .HasMany(e => e.RequestRadioApprovalHistories)
                .WithRequired(e => e.RequestStatus)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestStatus>()
                .HasMany(e => e.RequestSimCardAndMobilePhoneApprovalHistories)
                .WithRequired(e => e.RequestStatus)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestStatus>()
                .HasMany(e => e.RequestFacilityApprovalHistories)
                .WithRequired(e => e.RequestStatus)
                .HasForeignKey(e => e.StatusID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestWifi>()
                .HasMany(e => e.RequestWifiApprovalHistories)
                .WithRequired(e => e.RequestWifi)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestWifi>()
                .HasMany(e => e.RequestWifiComments)
                .WithRequired(e => e.RequestWifi)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestWifi>()
                .HasMany(e => e.RequestWifiDevices)
                .WithRequired(e => e.RequestWifi)
                .HasForeignKey(e => e.RequestID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestWifiDeviceType>()
                .HasMany(e => e.RequestWifiDevices)
                .WithRequired(e => e.RequestWifiDeviceType)
                .HasForeignKey(e => e.DeviceTypeID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<RequestWifiGroup>()
                .HasMany(e => e.RequestWifis)
                .WithRequired(e => e.RequestWifiGroup)
                .HasForeignKey(e => e.GroupID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Site>()
                .HasMany(e => e.RequestHelpdesks)
                .WithRequired(e => e.Site)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Site>()
                .HasMany(e => e.VideoConferenceCallAliases)
                .WithRequired(e => e.Site)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Test>()
                .HasMany(e => e.TestAdmins)
                .WithRequired(e => e.Test)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Test>()
                .HasMany(e => e.TestHistories)
                .WithRequired(e => e.Test)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Test>()
                .HasMany(e => e.TestHistory_ARC)
                .WithRequired(e => e.Test)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Test>()
                .HasMany(e => e.TestQuestions)
                .WithRequired(e => e.Test)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<TestQuestion>()
                .HasMany(e => e.TestAnswers)
                .WithRequired(e => e.TestQuestion)
                .HasForeignKey(e => e.QuestionID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ICTStaff_Temp_Access>()
                .Property(e => e.Site)
                .IsUnicode(false);
            #endregion
        }
    }
}