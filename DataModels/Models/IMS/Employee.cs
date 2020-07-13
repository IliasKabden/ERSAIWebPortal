namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using static DTO.EmployeeDTO;

    [Table("tb_Employee")]
    public partial class Employee
    {
        #region BasicInfo
        [Key, StringLength(10), Column("EmpBadge")]
        public string BadgeNumber { get; set; }
        [StringLength(15), Column("EmpGHRSID")]
        public string GHRSID { get; set; }
        [Required, StringLength(25), Column("EmpLName"), Display(Name = "Last Name")]
        public string LastName { get; set; }
        [StringLength(25), Column("EmpMName")]
        public string MiddleName { get; set; }
        [StringLength(25), Column("EmpFName")]
        public string FirstName { get; set; }
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {MiddleName} {LastName}".Replace("  ", " ");
            }
        }
        [StringLength(50), Column("EmpNameLoc")]
        public string FullNameLocal { get; set; }
        public byte[] EmpPhoto { get; set; }
        [Column("EmpCPos")]
        public short? ContractPositionID { get; set; }
        public virtual EmployeePosition ContractPosition { get; set; }
        [Column("EmpAPos")]
        public short? ProjectPositionID { get; set; }
        public virtual EmployeePosition ProjectPosition { get; set; }
        [StringLength(10), Column("EmpProj")]
        public string ProjectID { get; set; }
        public virtual Project Project { get; set; }
        [StringLength(6), Column("EmpDept")]
        public string DepartmentID { get; set; }
        public virtual Department Department { get; set; }
        [StringLength(10), Column("EmpSupv"), ForeignKey(nameof(Supervisor))]
        public string SupervisorID { get; set; }
        public virtual Employee Supervisor { get; set; }
        [StringLength(30), Column("EmpSect")]
        public string Section { get; set; }
        [StringLength(3), Column("EmpGroup")]
        public string GroupID { get; set; }
        public virtual EmployeeGroup Group { get; set; }
        [StringLength(6), Column("EmpBussUnit")]
        public string BusinessUnitID { get; set; }
        public virtual BusinessUnit BusinessUnit { get; set; }
        [StringLength(50), Column("EmpStreet")]
        public string Street { get; set; }
        [StringLength(50), Column("EmpTown")]
        public string Town { get; set; }
        [StringLength(50), Column("EmpCity")]
        public string City { get; set; }
        [StringLength(3), Column("EmpCountry")]
        public string CountryID { get; set; }
        public virtual Country Country { get; set; }
        [StringLength(20), Column("EmpPostCode")]
        public string PostCode { get; set; }
        [StringLength(50), Column("EmpStreetLoc")]
        public string StreetLocal { get; set; }
        [StringLength(50), Column("EmpTownLoc")]
        public string TownLocal { get; set; }
        [StringLength(50), Column("EmpCityLoc")]
        public string CityLocal { get; set; }
        [StringLength(3), Column("EmpCountryLoc")]
        public string CitizenshipID { get; set; }
        public virtual Country Citizenship { get; set; }
        [StringLength(50), Column("EmpHomeTel")]
        public string HomeTel { get; set; }
        [StringLength(50), Column("EmpWorkTel")]
        public string WorkTel { get; set; }
        [StringLength(50), Column("EmpEmail")]
        public string MailAddress { get; set; }
        [Required, StringLength(1), Column("EmpCat")]
        public string Category { get; set; }
        [StringLength(3), Column("EmpNat")]
        public string NationalityID { get; set; }
        public virtual Country Nationality { get; set; }
        [Column("EmpChild")]
        public byte? Children { get; set; }
        [StringLength(1), Column("EmpMarital")]
        public string MaritalStatusID { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        [StringLength(20), Column("EmpReligion")]
        public string Religion { get; set; }
        [Column("EmpBDate", TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [StringLength(50), Column("EmpBPlace")]
        public string BirthPlace { get; set; }
        [Required, StringLength(1), Column("EmpSex")]
        public string Gender { get; set; }
        [Column("EmpStat")]
        public short? StatusID { get; set; }
        public virtual EmployeeStatus Status { get; set; }
        [Column("EmpRelDate", TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }
        [Column("EmpRelReason")]
        public short? StatusReasonID { get; set; }
        public virtual EmployeeStatusReason StatusReason { get; set; }
        #endregion
        #region Passport Information
        [StringLength(20), Column("EmpPassNo")]
        public string PassportNumber { get; set; }
        [Column("EmpPassIss", TypeName = "date")]
        public DateTime? PassportIssuedDate { get; set; }
        [Column("EmpPassExp", TypeName = "date")]
        public DateTime? PassportExpirationDate { get; set; }
        [StringLength(60), Column("EmpPassLoc")]
        public string PassportIssuedBy { get; set; }
        [StringLength(20), Column("EmpPassStat")]
        public string PassportStatus { get; set; }
        [StringLength(20)]
        #endregion
        #region WorkPermit Information
        [Column("EmpWPNo")]
        public string WorkPermitNumber { get; set; }
        [Column("EmpWPLoc")]
        public short? WorkPermitLocationID { get; set; }
        public virtual WorkPermitLocation WorkPermitLocation { get; set; }
        [Column("EmpWPIss", TypeName = "date")]
        public DateTime? WorkPermitIssuedDate { get; set; }
        [Column("EmpWPExp", TypeName = "date")]
        public DateTime? WorkPermitExpirationDate { get; set; }
        [Column("EmpWPSDate", TypeName = "date")]
        public DateTime? WorkPermitLocalStartDate { get; set; }
        [Column("EmpWPPos"), StringLength(150)]
        public string WorkPermitPosition { get; set; }
        [Column("EmpWPCat")]
        public byte? WorkPermitCategoryID { get; set; }
        public virtual WorkPermitCategory WorkPermitCategory { get; set; }
        #endregion
        #region Visa Information
        [StringLength(20), Column("EmpVisaNo")]
        public string VisaNumber { get; set; }
        [Column("EmpVisaType")]
        public short? VisaTypeID { get; set; }
        public virtual VisaType VisaType { get; set; }
        [Column("EmpVisaIss", TypeName = "date")]
        public DateTime? VisaIssuedDate { get; set; }
        [Column("EmpVisaExp", TypeName = "date")]
        public DateTime? VisaExpirationDate { get; set; }
        [Column("EmpPoliceReg", TypeName = "date")]
        public DateTime? PoliceOfficeRegExpirationDate { get; set; }
        #endregion
        #region TaxPensionMedInfo
        [StringLength(20), Column("EmpIIN")]
        public string IIN { get; set; }
        [StringLength(25), Column("EmpPensionNo")]
        public string PensionAccountNumber { get; set; }
        [Column("EmpPensionPerc")]
        public double? PensionPercentage { get; set; }
        [Column("EmpPensionGroup")]
        public short? PensionGroupID { get; set; }
        public virtual PensionGroup PensionGroup { get; set; }
        [Column("EmpMedExp", TypeName = "date")]
        public DateTime? MedInsuranceExpirationDate { get; set; }
        #endregion
        #region Contract Information
        [Column("EmpContractNo"), StringLength(20)]
        public string ContractNumber { get; set; }
        [Column("EmpContrIni", TypeName = "date")]
        public DateTime? InitialContractStartDate { get; set; }
        [Column("EmpProjDate", TypeName = "date")]
        public DateTime? ProjectDate { get; set; }
        [Column("EmpContrSDate", TypeName = "date")]
        public DateTime? ContractStartDate { get; set; }
        [Column("EmpContrEDate", TypeName = "date")]
        public DateTime? ContractEndDate { get; set; }
        [Column("EmpContrADate", TypeName = "date")]
        public DateTime? ContractLastAmendmentDate { get; set; }
        [Column("EmpLVacDate", TypeName = "date")]
        public DateTime? LastVacationLastDate { get; set; }
        [Column("EmpMWHour")]
        public short? MonthlyWorkingHours { get; set; }
        [Column("EmpMWHour2")]
        public short? MonthlyWorkingHours2 { get; set; }
        [Column("EmpRotation")]
        public short? RotationTypeID { get; set; }
        public virtual RotationType RotationType { get; set; }
        [Column("EmpRotation2")]
        public short? RotationType2ID { get; set; }
        public virtual RotationType RotationType2 { get; set; }
        [Column("EmpContrType")]
        public short? ContractTypeID { get; set; }
        public virtual ContractType ContractType { get; set; }
        [Column("EmpContrType2")]
        public short? ContractType2ID { get; set; }
        public virtual ContractType ContractType2 { get; set; }
        [StringLength(3), Column("EmpCurr")]
        public string CurrencyID { get; set; }
        public virtual Currency Currency { get; set; }
        #endregion
        #region Salary Info
        [Column("EmpBasicSal")]
        public double? BasicSalary { get; set; }
        [Column("EmpBasicSal2")]
        public double? BasicSalary2 { get; set; }
        [Column("EmpOTRate")]
        public double? OvertimeRate { get; set; }
        [Column("EmpOTRate2")]
        public double? OvertimeRate2 { get; set; }
        [Column("EmpOTLump")]
        public double? OvertimeAllowance { get; set; }
        [Column("EmpOTWeekday")]
        public double? OvertimeRateWeekdays { get; set; }
        [Column("EmpOTWeekend")]
        public double? OvertimeRateWeekends { get; set; }
        [Column("EmpSiteAllow")]
        public double? SiteAllowance { get; set; }
        [Column("EmpSiteAllowType")]
        public short? SiteAllowanceTypeID { get; set; }
        [Column("EmpLivingAllow")]
        public double? LivingAllowance { get; set; }
        [Column("EmpLivingAllowType")]
        public short? LivingAllowanceTypeID { get; set; }
        [Column("EmpVacDaysRate")]
        public double? VacationDaysRate { get; set; }
        [Column("EmpHardship")]
        public double? HardshipAllowance { get; set; }
        [Column("EmpQuay")]
        public double? QuayRate { get; set; }
        [Column("EmpUnionName"), StringLength(3)]
        public string UnionID { get; set; }
        public virtual UnionGroup Union { get; set; }
        [Column("EmpInkindTax")]
        public bool? IsKindTaxable { get; set; }
        [Column("EmpTradeUnion")]
        public bool? IsTradeUnionMember { get; set; }
        [Column("EmpTaxExempt")]
        public bool? IsExemptedFromTaxes { get; set; }
        [Column("EmpPensionExempt")]
        public bool? IsExemptedFromPensionPayments { get; set; }
        [Column("EmpOPFC")]
        public bool? IsPensionOPFC { get; set; }
        [Column("EmpCSHIExempt")]
        public bool? IsExemptedFromCSHI { get; set; }
        [Column("EmpFoodAllow")]
        public double? FoodAllowance { get; set; }
        [Column("EmpAccomAllow")]
        public double? AccomodationAllowance { get; set; }
        #endregion
        #region Education Information
        [Column("EmpEduLevel")]
        public short? EducationLevelID { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }
        [StringLength(50), Column("EmpEduDegree")]
        public string EducationDirection { get; set; }
        [StringLength(50), Column("EmpEduMajor")]
        public string EducationMajor { get; set; }
        [Column("EmpEduGrad")]
        public bool? EducationGraduated { get; set; }
        [Column("EmpEduDate")]
        public short? EducationGraduationYear { get; set; }
        [StringLength(100), Column("EmpSchool")]
        public string SchoolOrUniversityName { get; set; }
        [StringLength(100), Column("EmpSchoolAddr")]
        public string SchoolOrUniversityAddress { get; set; }
        #endregion
        #region Bank Account Information
        [Column("EmpPayType")]
        public short? PaymentTypeID { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        [StringLength(50), Column("EmpPayee")]
        public string PaymentBeneficiary { get; set; }
        [StringLength(40), Column("EmpBankAccnt")]
        public string BankAccountNumber { get; set; }
        [Column("EmpBankName")]
        public short? BankID { get; set; }
        public virtual Bank Bank { get; set; }
        [StringLength(150), Column("EmpBankAddr")]
        public string BankAddress { get; set; }
        [StringLength(25), Column("EmpBankSWIFT")]
        public string BankSWIFT { get; set; }
        [StringLength(50), Column("EmpPayeeLoc")]
        public string LocalPaymentBeneficiaryName { get; set; }
        [Column("EmpBankNameLoc")]
        public short? LocalBankName { get; set; }
        [StringLength(25), Column("EmpBankIBANLoc")]
        public string BankAccountIBAN { get; set; }
        [StringLength(8), Column("EmpVendorID")]
        public string PaymentVendorID { get; set; }
        #endregion
        #region Professional Role Information
        [StringLength(8), Column("EmpPRole")]
        public string ProfessionalRoleID { get; set; }
        public virtual ProfessionalRole ProfessionalRole { get; set; }
        [StringLength(6), Column("EmpHOBUnit")]
        public string HOBUnitID { get; set; }
        public virtual HOBUnit HOBUnit { get; set; }
        [StringLength(6), Column("EmpBOCUnit")]
        public string BOCUnitID { get; set; }
        public virtual BOCUnit BOCUnit { get; set; }
        #endregion
        #region Emergency contact information
        [StringLength(50), Column("EmpKinName")]
        public string EmergencyContactName { get; set; }
        [StringLength(150), Column("EmpKinAddr")]
        public string EmergencyContactAddress { get; set; }
        [StringLength(50), Column("EmpKinTel")]
        public string EmergencyContactPhoneNumber { get; set; }
        [Column("EmpKinRel")]
        public byte? EmergencyContactRelationshipTypeID { get; set; }
        public virtual RelationshipType EmergencyContactRelationshipType { get; set; }
        #endregion
        #region Other Information
        [Column("EmpHFundDay")]
        public double? HolidayFundDays { get; set; }
        [Column("EmpBFundDay")]
        public double? BonusFundDays { get; set; }

        [StringLength(30), Column("EmpAccomm")]
        public string AccomodationLocation { get; set; }
        [Column("EmpCampIn", TypeName = "date")]
        public DateTime? CampInDate { get; set; }

        [Column("EmpOCC"), StringLength(6)]
        public string CostCenterID { get; set; }
        public virtual CostCenter CostCenter { get; set; }
        [Column("EmpGrade"), StringLength(2)]
        public string CREA_ID { get; set; }
        public virtual CREA CREA { get; set; }
        [Column("EmpLevel")]
        public short? LevelID { get; set; }
        public virtual EmployeeLevel Level { get; set; }
        [Column("EmpQualifi")]
        public short? QualificationID { get; set; }
        public virtual Qualification Qualification { get; set; }
        [Column("EmpWorkLoc")]
        public short? WorkLocationID { get; set; }
        public virtual WorkLocation WorkLocation { get; set; }

        [Column("EmpClass"), StringLength(4)]
        public string ClassID { get; set; }
        public virtual EmployeeClass Class { get; set; }
        [Column("EmpKeyRes")]
        public short? KeyResourceID { get; set; }
        public virtual KeyResource KeyResource { get; set; }
        [Column("EmpNational")]
        public short? NationalizationID { get; set; }
        public virtual Nationalization Nationalization { get; set; }

        [Column("EmpAccGrossSal")]
        public double? YTDTotalGrossSalary { get; set; }
        [Column("EmpAccGrossInc")]
        public double? YTDTotalGrossAllowance { get; set; }
        [Column("EmpAccExempt")]
        public double? YTDTotalExemption { get; set; }
        [Column("EmpAccMCB")]
        public double? YTDTotalMCB { get; set; }
        [Column("EmpAccTax")]
        public double? YTDTotalTax { get; set; }
        [Column("EmpAccPension")]
        public double? YTDTotalPension { get; set; }
        [Column("EmpYTDBonus")]
        public double? YTDTotalBonus { get; set; }
        [Column("EmpBFund")]
        public double? BFund { get; set; }
        [Column("EmpYTDVac")]
        public double? YTDTotalVacMoney { get; set; }
        [Column("EmpHFund")]
        public double? HFund { get; set; }
        [Column("EmpAccDays")]
        public double? YTDTotalRotationDays { get; set; }

        [Column("EmpRotAllow")]
        public double? AnnualRotationAllowance { get; set; }
        [Column("EmpABasicSal")]
        public double? AnnualBasicSalary { get; set; }
        [Column("EmpAOAllow")]
        public double? AnnualOvertimeAllowance { get; set; }
        [Column("EmpSF")]
        public short? ContractIncludesFamily { get; set; }

        [Column("EmpDuration")]
        public byte? ContractDuration { get; set; }
        [Column("EmpTravelLump")]
        public double? TotalTravelSum { get; set; }
        [Column("EmpTicket")]
        public byte? AirlineTicketTypeID { get; set; }
        public virtual TicketType AirlineTicketType { get; set; }
        [Column("EmpDeathIns")]
        public short? DeathInsuranceTypeID { get; set; }
        public virtual DeathInsuranceType DeathInsuranceType { get; set; }
        [Column("EmpMedIns")]
        public short? MedInsuranceTypeID { get; set; }
        public virtual MedInsuranceType MedInsuranceType { get; set; }
        [Column("EmpLifeIns")]
        public short? LifeInsuranceTypeID { get; set; }
        public virtual LifeInsuranceType LifeInsuranceType { get; set; }
        [Column("EmpIncProt")]
        public short? IncomeProtectionTypeID { get; set; }
        public virtual IncomeProtectionType IncomeProtectionType { get; set; }
        [Column("EmpProb"), StringLength(5)]
        public string ProbationPeriodInDays { get; set; }
        [Column("EmpNotice")]
        public byte? BeforeLeaveNoticePeriodInDays { get; set; }
        [Column("EmpRemark")]
        public string Comments { get; set; }
        #endregion
        public virtual List<ContractAmendment> ContractAmendments { get; set; }
    }
    public partial class Employee
    {
        public void FromDTO(DTO.EmployeeDTO dto, IEnumerable<ComplexInfoSection> sectionsToEdit = null)
        {
            var allSections = sectionsToEdit == null;

            if (dto.BasicInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.BasicInfo)))
                FromBasicInfoDTO(dto.BasicInfo);
            if (dto.BasicCompanyInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.BasicCompanyInfo)))
                FromBasicCompanyInfoDTO(dto.BasicCompanyInfo);
            if (dto.AdditionalPersonalInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.AdditionalPersonalInfo)))
                FromAdditionalPersonalInfoDTO(dto.AdditionalPersonalInfo);
            if (dto.StatusInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.StatusInfo)))
                FromStatusInfoDTO(dto.StatusInfo);
            if (dto.PassportInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.PassportInfo)))
                FromPassportInfoDTO(dto.PassportInfo);
            if (dto.WorkPermitInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.WorkPermitInfo)))
                FromWorkPermitInfoDTO(dto.WorkPermitInfo);
            if (dto.VisaInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.VisaInfo)))
                FromVisaInfoDTO(dto.VisaInfo);
            if (dto.TaxPensionMedInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.TaxPensionMedInfo)))
                FromTaxPensionMedInfoDTO(dto.TaxPensionMedInfo);
            if (dto.ContractInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.ContractInfo)))
                FromContractInfoDTO(dto.ContractInfo);
            if (dto.AccomodationInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.AccomodationInfo)))
                FromAccomodationInfoDTO(dto.AccomodationInfo);
            if (dto.EducationInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.EducationInfo)))
                FromEducationInfoDTO(dto.EducationInfo);
            if (dto.BankAccountInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.BankAccountInfo)))
                FromBankAccountInfoDTO(dto.BankAccountInfo);
            if (dto.EmergencyContactInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.EmergencyContactInfo)))
                FromEmergencyContactInfoDTO(dto.EmergencyContactInfo);
            if (dto.ProfessionalRoleInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.ProfessionalRoleInfo)))
                FromProfessionalRoleInfoDTO(dto.ProfessionalRoleInfo);
            if (dto.ContractOtherInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.OtherContractInfo)))
                FromContractOtherInfoDTO(dto.ContractOtherInfo);
            if (dto.OtherInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.OtherInfo)))
                FromOtherInfoDTO(dto.OtherInfo);
            if (dto.SalaryInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.SalaryInfo)))
                FromSalaryInfoDTO(dto.SalaryInfo);
            if (dto.JobInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.JobInfo)))
                FromJobInfoDTO(dto.JobInfo);
            if (dto.YTDInfo != null && (allSections || sectionsToEdit.Contains(ComplexInfoSection.YTDInfo)))
                FromYTDInfoDTO(dto.YTDInfo);
        }

        public void FromBasicInfoDTO(BasicInfoDTO dto)
        {
            BadgeNumber = dto.BadgeNumber;
            GHRSID = dto.GHRSID;
            LastName = dto.LastName;
            MiddleName = dto.MiddleName;
            FirstName = dto.FirstName;
            FullNameLocal = dto.FullNameLocal;
        }
        public void FromBasicCompanyInfoDTO(BasicCompanyInfoDTO dto)
        {
            ContractPositionID = dto.ContractPositionID;
            ProjectPositionID = dto.ProjectPositionID;
            ProjectID = dto.ProjectID;
            DepartmentID = dto.DepartmentID;
            SupervisorID = dto.SupervisorID;
            Section = dto.Section;
            GroupID = dto.GroupID;
            BusinessUnitID = dto.BusinessUnitID;
        }
        public void FromAdditionalPersonalInfoDTO(AdditionalPersonalInfoDTO dto)
        {
            Street = dto.Street;
            Town = dto.Town;
            City = dto.City;
            CountryID = dto.CountryID;
            PostCode = dto.PostCode;

            StreetLocal = dto.StreetLocal;
            TownLocal = dto.TownLocal;
            CityLocal = dto.CityLocal;
            CitizenshipID = dto.CitizenshipID;

            HomeTel = dto.HomeTel;
            WorkTel = dto.WorkTel;
            MailAddress = dto.MailAddress;
            Category = dto.Category;
            NationalityID = dto.NationalityID;

            Children = dto.Children;
            MaritalStatusID = dto.MaritalStatusID;
            Religion = dto.Religion;
            BirthDate = dto.BirthDate;
            BirthPlace = dto.BirthPlace;
            Gender = dto.Gender;
        }
        public void FromStatusInfoDTO(StatusInfoDTO dto)
        {
            StatusID = dto.StatusID;
            ReleaseDate = dto.ReleaseDate;
            StatusReasonID = dto.StatusReasonID;
        }
        public void FromPassportInfoDTO(PassportInfoDTO dto)
        {
            PassportNumber = dto.Number;
            PassportIssuedDate = dto.IssuedDate;
            PassportExpirationDate = dto.ExpirationDate;
            PassportIssuedBy = dto.IssuedBy;
            PassportStatus = dto.Status;
        }
        public void FromWorkPermitInfoDTO(WorkPermitInfoDTO dto)
        {
            WorkPermitNumber = dto.Number;
            WorkPermitLocationID = dto.LocationID;
            WorkPermitIssuedDate = dto.IssuedDate;
            WorkPermitExpirationDate = dto.IssuedDate;
            WorkPermitLocalStartDate = dto.LocalStartDate;
            WorkPermitPosition = dto.Position;
            WorkPermitCategoryID = dto.CategoryID;
        }
        public void FromVisaInfoDTO(VisaInfoDTO dto)
        {
            VisaNumber = dto.Number;
            VisaTypeID = dto.TypeID;
            VisaIssuedDate = dto.IssuedDate;
            VisaExpirationDate = dto.ExpirationDate;
            PoliceOfficeRegExpirationDate = dto.PoliceRegExpirationDate;
        }
        public void FromTaxPensionMedInfoDTO(TaxPensionMedInfoDTO dto)
        {
            IIN = dto.IIN;
            PensionAccountNumber = dto.PensionAccountNumber;
            PensionPercentage = dto.PensionPercentage;
            PensionGroupID = dto.PensionGroupID;
            MedInsuranceExpirationDate = dto.MedInsuranceExpirationDate;
        }
        public void FromContractInfoDTO(ContractInfoDTO dto)
        {
            ContractNumber = dto.Number;
            InitialContractStartDate = dto.InitialStartDate;
            ProjectDate = dto.ProjectDate;
            ContractStartDate = dto.StartDate;
            ContractEndDate = dto.EndDate;
            ContractLastAmendmentDate = dto.LastAmendmentDate;
            LastVacationLastDate = dto.LastVacationLastDate;
            MonthlyWorkingHours = dto.MonthlyWorkingHours;
            MonthlyWorkingHours2 = dto.MonthlyWorkingHours2;
            RotationTypeID = dto.RotationTypeID;
            RotationType2ID = dto.RotationType2ID;
            ContractType2ID = dto.Type2ID;
            CurrencyID = dto.CurrencyID;
            HolidayFundDays = dto.HolidayFundDays;
            BonusFundDays = dto.BonusFundDays;
            ProbationPeriodInDays = dto.ProbationPeriodInDays;
            BeforeLeaveNoticePeriodInDays = dto.BeforeLeaveNoticePeriodInDays;
            ContractDuration = dto.Duration;
        }
        public void FromAccomodationInfoDTO(AccomodationInfoDTO dto)
        {
            AccomodationLocation = dto.AccomodationLocation;
            CampInDate = dto.CampInDate;
        }
        public void FromEducationInfoDTO(EducationInfoDTO dto)
        {
            EducationLevelID = dto.LevelID;
            EducationDirection = dto.Direction;
            EducationMajor = dto.Major;
            EducationGraduated = dto.Graduated;
            EducationGraduationYear = dto.GraduationYear;
            SchoolOrUniversityName = dto.SchoolOrUniversityName;
            SchoolOrUniversityAddress = dto.SchoolOrUniversityAddress;
        }
        public void FromBankAccountInfoDTO(BankAccountInfoDTO dto)
        {
            PaymentTypeID = dto.PaymentTypeID;
            PaymentBeneficiary = dto.BeneficiaryName;
            BankAccountNumber = dto.Number;
            BankID = dto.BankID;
            BankAddress = dto.BankAddress;
            BankSWIFT = dto.BankSWIFT;

            LocalPaymentBeneficiaryName = dto.LocalBeneficiaryName;
            LocalBankName = dto.LocalBankName;
            BankAccountIBAN = dto.IBAN;
            PaymentVendorID = dto.PaymentVendorID;
        }
        public void FromEmergencyContactInfoDTO(EmergencyContactInfoDTO dto)
        {
            EmergencyContactName = dto.Name;
            EmergencyContactAddress = dto.Address;
            EmergencyContactPhoneNumber = dto.PhoneNumber;
            EmergencyContactRelationshipTypeID = dto.RelationshipTypeID;
        }
        public void FromProfessionalRoleInfoDTO(ProfessionalRoleInfoDTO dto)
        {
            ProfessionalRoleID = dto.RoleID;
            HOBUnitID = dto.HOBUnitID;
            BOCUnitID = dto.BOCUnitID;
        }
        public void FromContractOtherInfoDTO(ContractOtherInfoDTO dto)
        {
            AnnualRotationAllowance = dto.AnnualRotationAllowance;
            AnnualBasicSalary = dto.AnnualBasicSalary;
            AnnualOvertimeAllowance = dto.AnnualOvertimeAllowance;
            ContractIncludesFamily = (short)(dto.ContractIncludesFamily == true ? 1 : 0);

            TotalTravelSum = dto.TotalTravelSum;
            AirlineTicketTypeID = dto.AirlineTicketTypeID;
            DeathInsuranceTypeID = dto.DeathInsuranceTypeID;
            MedInsuranceTypeID = dto.MedInsuranceTypeID;
            LifeInsuranceTypeID = dto.LifeInsuranceTypeID;
            IncomeProtectionTypeID = dto.IncomeProtectionTypeID;
        }
        public void FromOtherInfoDTO(OtherInfoDTO dto)
        {
            Comments = dto.Comments;
        }
        public void FromSalaryInfoDTO(SalaryInfoDTO dto)
        {
            BasicSalary = dto.BasicSalary;
            BasicSalary2 = dto.BasicSalary2;
            OvertimeRate = dto.OvertimeRate;
            OvertimeRate2 = dto.OvertimeRate2;
            OvertimeAllowance = dto.OvertimeAllowance;
            OvertimeRateWeekdays = dto.OvertimeRateWeekdays;
            OvertimeRateWeekends = dto.OvertimeRateWeekends;
            SiteAllowance = dto.SiteAllowance;
            SiteAllowanceTypeID = dto.SiteAllowanceTypeID;
            LivingAllowance = dto.LivingAllowance;
            LivingAllowanceTypeID = dto.LivingAllowanceTypeID;
            VacationDaysRate = dto.VacationDaysRate;
            HardshipAllowance = dto.HardshipAllowance;
            QuayRate = dto.QuayRate;
            UnionID = dto.UnionID;
            IsKindTaxable = dto.IsKindTaxable;
            IsTradeUnionMember = dto.IsTradeUnionMember;
            IsExemptedFromTaxes = dto.IsExemptedFromTaxes;
            IsExemptedFromPensionPayments = dto.IsExemptedFromPensionPayments;
            IsPensionOPFC = dto.IsPensionOPFC;
            IsExemptedFromCSHI = dto.IsExemptedFromCSHI;
            FoodAllowance = dto.FoodAllowance;
            AccomodationAllowance = dto.AccomodationAllowance;
        }
        public void FromJobInfoDTO(JobInfoDTO dto)
        {
            CostCenterID = dto.CostCenterID;
            CREA_ID = dto.CREA_ID;
            LevelID = dto.LevelID;
            QualificationID = dto.QualificationID;
            WorkLocationID = dto.WorkLocationID;

            ClassID = dto.ClassID;
            KeyResourceID = dto.KeyResourceID;
            NationalizationID = dto.NationalizationID;
        }
        public void FromYTDInfoDTO(YTDInfoDTO dto)
        {
            YTDTotalGrossSalary = dto.YTDTotalGrossSalary;
            YTDTotalGrossAllowance = dto.YTDTotalGrossAllowance;
            YTDTotalExemption = dto.YTDTotalExemption;
            YTDTotalMCB = dto.YTDTotalMCB;
            YTDTotalTax = dto.YTDTotalTax;
            YTDTotalPension = dto.YTDTotalPension;
            YTDTotalBonus = dto.YTDTotalBonus;
            BFund = dto.BFund;
            YTDTotalVacMoney = dto.YTDTotalVacMoney;
            HFund = dto.HFund;
            YTDTotalRotationDays = dto.YTDTotalRotationDays;
        }

        public enum ComplexInfoSection : byte
        {
            BasicInfo,
            BasicCompanyInfo,
            AdditionalPersonalInfo,
            StatusInfo,
            PassportInfo,
            WorkPermitInfo,
            VisaInfo,
            TaxPensionMedInfo,
            ContractInfo,
            AccomodationInfo,
            EducationInfo,
            BankAccountInfo,
            EmergencyContactInfo,
            ProfessionalRoleInfo,
            OtherContractInfo,
            OtherInfo,
            SalaryInfo,
            JobInfo,
            YTDInfo
        }
    }
}