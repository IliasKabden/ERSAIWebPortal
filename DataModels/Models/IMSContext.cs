namespace DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models.IMS;

    public partial class IMSContext : DbContext
    {
        public IMSContext()
            : base("name=IMSConnectionString")
        {
        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BOCUnit> BOCUnits { get; set; }
        public virtual DbSet<BusinessUnit> BusinessUnits { get; set; }
        public virtual DbSet<ContractType> ContractTypes { get; set; }
        public virtual DbSet<CostCenter> CostCenters { get; set; }
        public virtual DbSet<CREA> CREAValues { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<DeathInsuranceType> DeathInsuranceTypes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<EducationLevel> EducationLevels { get; set; }
        public virtual DbSet<EmployeeClass> EmployeeClasses { get; set; }
        public virtual DbSet<EmployeeGroup> EmployeeGroups { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public virtual DbSet<EmployeeStatusReason> EmployeeStatusReasons { get; set; }
        public virtual DbSet<HOBUnit> HOBUnits { get; set; }
        public virtual DbSet<IncomeProtectionType> IncomeProtectionTypes { get; set; }
        public virtual DbSet<EmployeeLevel> EmployeeLevels { get; set; }
        public virtual DbSet<KeyResource> KeyResources { get; set; }
        public virtual DbSet<LifeInsuranceType> LifeInsuranceTypes { get; set; }
        public virtual DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public virtual DbSet<MedInsuranceType> MedInsuranceTypes { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Nationalization> Nationalizations { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<PensionGroup> PensionGroups { get; set; }
        public virtual DbSet<EmployeePositionClass> EmployeesPositionsClasses { get; set; }
        public virtual DbSet<EmployeePosition> EmployeesPositions { get; set; }
        public virtual DbSet<ProfessionalRole> ProfessionalRoles { get; set; }
        public virtual DbSet<ProfessionalRoleArea> ProfessionalRoleAreas { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectType> ProjectTypes { get; set; }
        public virtual DbSet<Qualification> EmployeeQualifications { get; set; }
        public virtual DbSet<RelationshipType> RelationshipTypes { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<ProfessionalRoleFamily> ProfessionalRolesFamilies { get; set; }
        public virtual DbSet<RotationType> RotationTypes { get; set; }
        public virtual DbSet<TicketType> TicketTypes { get; set; }
        public virtual DbSet<UnionGroup> UnionGroups { get; set; }
        public virtual DbSet<VisaType> VisaTypes { get; set; }
        public virtual DbSet<WorkLocation> WorkLocations { get; set; }
        public virtual DbSet<WorkPermitCategory> WorkPermitCategories { get; set; }
        public virtual DbSet<WorkPermitLocation> WorkPermitLocations { get; set; }
        public virtual DbSet<ContractAmendment> EmployeesContractAmendments { get; set; }
        public virtual DbSet<ContractAmendmentType> ContractAmendmentTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Bank>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Bank>()
                .Property(e => e.SWIFT)
                .IsUnicode(false);

            modelBuilder.Entity<Bank>()
                .Property(e => e.BankCode)
                .IsUnicode(false);

            modelBuilder.Entity<Bank>()
                .Property(e => e.BranchCode)
                .IsUnicode(false);

            modelBuilder.Entity<Bank>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Bank)
                .HasForeignKey(e => e.BankID);

            modelBuilder.Entity<BOCUnit>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<BOCUnit>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<BOCUnit>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.BOCUnit)
                .HasForeignKey(e => e.BOCUnitID);

            modelBuilder.Entity<BusinessUnit>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessUnit>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<BusinessUnit>()
                .HasMany(e => e.tb_Project)
                .WithOptional(e => e.tb_BussUnit)
                .HasForeignKey(e => e.BussUnit);

            modelBuilder.Entity<BusinessUnit>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.BusinessUnit)
                .HasForeignKey(e => e.BusinessUnitID);

            modelBuilder.Entity<ContractType>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<ContractType>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.ContractType)
                .HasForeignKey(e => e.ContractTypeID);

            modelBuilder.Entity<ContractType>()
                .HasMany(e => e.tb_Employee1)
                .WithOptional(e => e.ContractType2)
                .HasForeignKey(e => e.ContractType2ID);

            modelBuilder.Entity<CostCenter>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<CostCenter>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<CostCenter>()
                .Property(e => e.Referer)
                .IsUnicode(false);

            modelBuilder.Entity<CostCenter>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.CostCenter)
                .HasForeignKey(e => e.CostCenterID);

            modelBuilder.Entity<CREA>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<CREA>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<CREA>()
                .HasMany(e => e.tb_Position)
                .WithOptional(e => e.tb_CREA)
                .HasForeignKey(e => e.CREA);

            modelBuilder.Entity<CREA>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.CREA)
                .HasForeignKey(e => e.CREA_ID);

            modelBuilder.Entity<Currency>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Currency>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<Currency>()
                .Property(e => e.Symbol);

            modelBuilder.Entity<Currency>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Currency)
                .HasForeignKey(e => e.CurrencyID);

            modelBuilder.Entity<DeathInsuranceType>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.DeathInsuranceType)
                .HasForeignKey(e => e.DeathInsuranceTypeID);

            modelBuilder.Entity<Department>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.HOD)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.DepartmentID);

            modelBuilder.Entity<EducationLevel>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<EducationLevel>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.EducationLevel)
                .HasForeignKey(e => e.EducationLevelID);

            modelBuilder.Entity<EmployeeClass>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeClass>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeClass>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeClass>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Class)
                .HasForeignKey(e => e.ClassID);

            modelBuilder.Entity<EmployeeGroup>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeGroup>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeGroup>()
                .Property(e => e.SIDAC)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeGroup>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.Group)
                .HasForeignKey(e => e.GroupID);

            modelBuilder.Entity<Employee>()
                .Property(e => e.BadgeNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.GHRSID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.ProjectID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.DepartmentID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.SupervisorID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Section)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.BusinessUnitID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Town)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CountryID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PostCode)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CitizenshipID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.HomeTel)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.WorkTel)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.NationalityID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.MaritalStatusID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Religion)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.BirthPlace)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PassportNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PassportIssuedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PassportStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.WorkPermitNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.VisaNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.IIN)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PensionAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.ContractNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CurrencyID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.AccomodationLocation)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.UnionID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CostCenterID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CREA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.ClassID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EducationDirection)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EducationMajor)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.SchoolOrUniversityName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.SchoolOrUniversityAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.BankAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.BankSWIFT)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.BankAccountIBAN)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PaymentVendorID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.ProfessionalRoleID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.HOBUnitID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.BOCUnitID)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmergencyContactName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmergencyContactPhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.ProbationPeriodInDays)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeStatus>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeStatus>()
                .Property(e => e.SIDAC)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeStatus>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.Status)
                .HasForeignKey(e => e.StatusID);

            modelBuilder.Entity<EmployeeStatusReason>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeStatusReason>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.StatusReason)
                .HasForeignKey(e => e.StatusReasonID);

            modelBuilder.Entity<HOBUnit>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<HOBUnit>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<HOBUnit>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.HOBUnit)
                .HasForeignKey(e => e.HOBUnitID);

            modelBuilder.Entity<IncomeProtectionType>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<IncomeProtectionType>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.IncomeProtectionType)
                .HasForeignKey(e => e.IncomeProtectionTypeID);

            modelBuilder.Entity<EmployeeLevel>()
                .Property(e => e.Level)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLevel>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeeLevel>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.Level)
                .HasForeignKey(e => e.LevelID);

            modelBuilder.Entity<KeyResource>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<KeyResource>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.KeyResource)
                .HasForeignKey(e => e.KeyResourceID);

            modelBuilder.Entity<LifeInsuranceType>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.LifeInsuranceType)
                .HasForeignKey(e => e.LifeInsuranceTypeID);

            modelBuilder.Entity<MaritalStatus>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<MaritalStatus>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<MaritalStatus>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.MaritalStatus)
                .HasForeignKey(e => e.MaritalStatusID);

            modelBuilder.Entity<MedInsuranceType>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.MedInsuranceType)
                .HasForeignKey(e => e.MedInsuranceTypeID);

            modelBuilder.Entity<Continent>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<Continent>()
                .HasMany(e => e.Countries)
                .WithOptional(e => e.Continent)
                .HasForeignKey(e => e.NatGroup);

            modelBuilder.Entity<Country>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.NationalityName)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.SIDAC)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.BCClass)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.BFClass)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.WCClass)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .Property(e => e.MMClass)
                .IsUnicode(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.Country)
                .HasForeignKey(e => e.CountryID);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.tb_Employee1)
                .WithOptional(e => e.Citizenship)
                .HasForeignKey(e => e.CitizenshipID);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.tb_Employee2)
                .WithOptional(e => e.Nationality)
                .HasForeignKey(e => e.NationalityID);

            modelBuilder.Entity<Nationalization>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<Nationalization>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Nationalization)
                .HasForeignKey(e => e.NationalizationID);

            modelBuilder.Entity<PaymentType>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<PaymentType>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.PaymentType)
                .HasForeignKey(e => e.PaymentTypeID);

            modelBuilder.Entity<PensionGroup>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<PensionGroup>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.PensionGroup)
                .HasForeignKey(e => e.PensionGroupID);

            modelBuilder.Entity<EmployeePositionClass>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePositionClass>()
                .HasMany(e => e.Positions)
                .WithOptional(e => e.tb_PosClass)
                .HasForeignKey(e => e.Class);

            modelBuilder.Entity<EmployeePosition>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePosition>()
                .Property(e => e.CREA)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePosition>()
                .Property(e => e.Class)
                .IsUnicode(false);

            modelBuilder.Entity<EmployeePosition>()
                .HasMany(e => e.tb_Employee)
                .WithRequired(e => e.ContractPosition)
                .HasForeignKey(e => e.ProjectPositionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EmployeePosition>()
                .HasMany(e => e.tb_Employee1)
                .WithRequired(e => e.ProjectPosition)
                .HasForeignKey(e => e.ContractPositionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProfessionalRole>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessionalRole>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessionalRole>()
                .Property(e => e.AreaID)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessionalRole>()
                .Property(e => e.FamilyID)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessionalRole>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.ProfessionalRole)
                .HasForeignKey(e => e.ProfessionalRoleID);

            modelBuilder.Entity<ProfessionalRoleArea>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessionalRoleArea>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessionalRoleArea>()
                .HasMany(e => e.Roles)
                .WithOptional(e => e.Area)
                .HasForeignKey(e => e.AreaID);

            modelBuilder.Entity<Project>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.Manager)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .Property(e => e.BussUnit)
                .IsUnicode(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.Project)
                .HasForeignKey(e => e.ProjectID);

            modelBuilder.Entity<ProjectType>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectType>()
                .HasMany(e => e.WorkLocations)
                .WithOptional(e => e.ProjectType)
                .HasForeignKey(e => e.ProjectTypeID);

            modelBuilder.Entity<Qualification>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<Qualification>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.Qualification)
                .HasForeignKey(e => e.QualificationID);

            modelBuilder.Entity<RelationshipType>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<RelationshipType>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.EmergencyContactRelationshipType)
                .HasForeignKey(e => e.EmergencyContactRelationshipTypeID);

            modelBuilder.Entity<Religion>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessionalRoleFamily>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessionalRoleFamily>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessionalRoleFamily>()
                .HasMany(e => e.Roles)
                .WithOptional(e => e.Family)
                .HasForeignKey(e => e.FamilyID);

            modelBuilder.Entity<RotationType>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<RotationType>()
                .HasMany(e => e.tb_Employee)
                .WithOptional(e => e.RotationType)
                .HasForeignKey(e => e.RotationTypeID);

            modelBuilder.Entity<RotationType>()
                .HasMany(e => e.tb_Employee1)
                .WithOptional(e => e.RotationType2)
                .HasForeignKey(e => e.RotationType2ID);

            modelBuilder.Entity<TicketType>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<TicketType>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.AirlineTicketType)
                .HasForeignKey(e => e.AirlineTicketTypeID);

            modelBuilder.Entity<UnionGroup>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<UnionGroup>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<UnionGroup>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Union)
                .HasForeignKey(e => e.UnionID);

            modelBuilder.Entity<VisaType>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<VisaType>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.VisaType)
                .HasForeignKey(e => e.VisaTypeID);

            modelBuilder.Entity<WorkLocation>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<WorkLocation>()
                .Property(e => e.WArea)
                .IsUnicode(false);

            modelBuilder.Entity<WorkLocation>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<WorkLocation>()
                .Property(e => e.SIDAC)
                .IsUnicode(false);

            modelBuilder.Entity<WorkLocation>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.WorkLocation)
                .HasForeignKey(e => e.WorkLocationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkPermitCategory>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<WorkPermitCategory>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.WorkPermitCategory)
                .HasForeignKey(e => e.WorkPermitCategoryID);

            modelBuilder.Entity<WorkPermitLocation>()
                .Property(e => e.Descr)
                .IsUnicode(false);

            modelBuilder.Entity<WorkPermitLocation>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.WorkPermitLocation)
                .HasForeignKey(e => e.WorkPermitLocationID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ContractAmendments)
                .WithRequired(e => e.Employee)
                .HasForeignKey(e => e.BadgeNo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContractAmendment>()
                .Property(e => e.BadgeNo)
                .IsUnicode(false);

            modelBuilder.Entity<ContractAmendment>()
                .Property(e => e.Number)
                .IsUnicode(false);

            modelBuilder.Entity<ContractAmendment>()
                .Property(e => e.OldProfessionalRoleID)
                .IsUnicode(false);

            modelBuilder.Entity<ContractAmendment>()
                .Property(e => e.NewProfessionalRoleID)
                .IsUnicode(false);

            modelBuilder.Entity<ContractAmendment>()
                .Property(e => e.OldCREA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContractAmendment>()
                .Property(e => e.NewCREA_ID)
                .IsUnicode(false);

            modelBuilder.Entity<ContractAmendment>()
                .Property(e => e.LastEditorID)
                .IsUnicode(false);
        }
    }
}