using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataModels.Models.IMS.DTO
{
    public partial class EmployeeDTO
    {
        public string CurrentBadgeNumber { get; set; }
        public string BusinessUnitID { get; set; }

        public BasicInfoDTO BasicInfo { get; set; }
        public BasicCompanyInfoDTO BasicCompanyInfo { get; set; }
        public AdditionalPersonalInfoDTO AdditionalPersonalInfo { get; set; }
        public StatusInfoDTO StatusInfo { get; set; }
        public PassportInfoDTO PassportInfo { get; set; }
        public WorkPermitInfoDTO WorkPermitInfo { get; set; }
        public VisaInfoDTO VisaInfo { get; set; }
        public TaxPensionMedInfoDTO TaxPensionMedInfo { get; set; }
        public ContractInfoDTO ContractInfo { get; set; }
        public AccomodationInfoDTO AccomodationInfo { get; set; }
        public EducationInfoDTO EducationInfo { get; set; }
        public BankAccountInfoDTO BankAccountInfo { get; set; }
        public EmergencyContactInfoDTO EmergencyContactInfo { get; set; }
        public ProfessionalRoleInfoDTO ProfessionalRoleInfo { get; set; }
        public ContractOtherInfoDTO ContractOtherInfo { get; set; }
        public OtherInfoDTO OtherInfo { get; set; }
        public SalaryInfoDTO SalaryInfo { get; set; }
        public JobInfoDTO JobInfo { get; set; }
        public YTDInfoDTO YTDInfo { get; set; }

        public EmployeeDTO() { }
        public EmployeeDTO(Employee ef, IEnumerable<Employee.ComplexInfoSection> sections = null)
        {
            FromEF(ef, sections);
        }
        public void FromEF(Employee ef, IEnumerable<Employee.ComplexInfoSection> sections = null)
        {
            CurrentBadgeNumber = ef.BadgeNumber;
            BusinessUnitID = ef.BusinessUnitID;

            var allSections = sections == null;

            if (allSections || sections.Contains(Employee.ComplexInfoSection.BasicInfo))
                BasicInfo = new BasicInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.BasicCompanyInfo))
                BasicCompanyInfo = new BasicCompanyInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.AdditionalPersonalInfo))
                AdditionalPersonalInfo = new AdditionalPersonalInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.StatusInfo))
                StatusInfo = new StatusInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.PassportInfo))
                PassportInfo = new PassportInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.WorkPermitInfo))
                WorkPermitInfo = new WorkPermitInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.VisaInfo))
                VisaInfo = new VisaInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.TaxPensionMedInfo))
                TaxPensionMedInfo = new TaxPensionMedInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.ContractInfo))
                ContractInfo = new ContractInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.AccomodationInfo))
                AccomodationInfo = new AccomodationInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.EducationInfo))
                EducationInfo = new EducationInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.BankAccountInfo))
                BankAccountInfo = new BankAccountInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.EmergencyContactInfo))
                EmergencyContactInfo = new EmergencyContactInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.ProfessionalRoleInfo))
                ProfessionalRoleInfo = new ProfessionalRoleInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.OtherContractInfo))
                ContractOtherInfo = new ContractOtherInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.OtherInfo))
                OtherInfo = new OtherInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.SalaryInfo))
                SalaryInfo = new SalaryInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.JobInfo))
                JobInfo = new JobInfoDTO(ef);
            if (allSections || sections.Contains(Employee.ComplexInfoSection.YTDInfo))
                YTDInfo = new YTDInfoDTO(ef);
        }

        public class BasicInfoDTO
        {
            public string BadgeNumber { get; set; }
            public string GHRSID { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string FirstName { get; set; }
            public string FullName
            {
                get
                {
                    return $"{FirstName} {MiddleName} {LastName}".Replace("  ", " ");
                }
            }
            public string FullNameLocal { get; set; }



            public string PhotoBase64 { get; set; }
            public bool PhotoChanged { get; set; }

            public BasicInfoDTO() { }
            public BasicInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                BadgeNumber = ef.BadgeNumber;
                GHRSID = ef.GHRSID;
                LastName = ef.LastName;
                MiddleName = ef.MiddleName;
                FirstName = ef.FirstName;
                FullNameLocal = ef.FullNameLocal;
            }
        }
        public class BasicCompanyInfoDTO
        {
            public short? ContractPositionID { get; set; }
            public short? ProjectPositionID { get; set; }
            public string ProjectID { get; set; }
            public string DepartmentID { get; set; }
            public string SupervisorID { get; set; }
            public string Section { get; set; }
            public string GroupID { get; set; }
            public string BusinessUnitID { get; set; }
            public BasicCompanyInfoDTO() { }
            public BasicCompanyInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                ContractPositionID = ef.ContractPositionID;
                ProjectPositionID = ef.ProjectPositionID;
                ProjectID = ef.ProjectID;
                DepartmentID = ef.DepartmentID;
                SupervisorID = ef.SupervisorID;
                Section = ef.Section;
                GroupID = ef.GroupID;
                BusinessUnitID = ef.BusinessUnitID;
            }
        }
        public class AdditionalPersonalInfoDTO
        {
            public string Street { get; set; }
            public string Town { get; set; }
            public string City { get; set; }
            public string CountryID { get; set; }
            public string PostCode { get; set; }
            public string StreetLocal { get; set; }
            public string TownLocal { get; set; }
            public string CityLocal { get; set; }
            public string CitizenshipID { get; set; }
            public string HomeTel { get; set; }
            public string WorkTel { get; set; }
            public string MailAddress { get; set; }
            public string Category { get; set; }
            public string NationalityID { get; set; }
            public byte? Children { get; set; }
            public string MaritalStatusID { get; set; }
            public string Religion { get; set; }
            public DateTime? BirthDate { get; set; }
            public string BirthPlace { get; set; }
            public string Gender { get; set; }
            public AdditionalPersonalInfoDTO() { }
            public AdditionalPersonalInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                Street = ef.Street;
                Town = ef.Town;
                City = ef.City;
                CountryID = ef.CountryID;
                PostCode = ef.PostCode;

                StreetLocal = ef.StreetLocal;
                TownLocal = ef.TownLocal;
                CityLocal = ef.CityLocal;

                CitizenshipID = ef.CitizenshipID;
                HomeTel = ef.HomeTel;
                WorkTel = ef.WorkTel;
                MailAddress = ef.MailAddress;
                Category = ef.Category;
                NationalityID = ef.NationalityID;

                Children = ef.Children;
                MaritalStatusID = ef.MaritalStatusID;
                Religion = ef.Religion;
                BirthDate = ef.BirthDate;
                BirthPlace = ef.BirthPlace;
                Gender = ef.Gender;
            }
        }
        public class StatusInfoDTO
        {
            public short? StatusID { get; set; }
            public DateTime? ReleaseDate { get; set; }
            public short? StatusReasonID { get; set; }
            public StatusInfoDTO() { }
            public StatusInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                StatusID = ef.StatusID;
                ReleaseDate = ef.ReleaseDate;
                StatusReasonID = ef.StatusReasonID;
            }
        }
        public class PassportInfoDTO
        {
            public string Number { get; set; }
            public DateTime? IssuedDate { get; set; }
            public DateTime? ExpirationDate { get; set; }
            public string IssuedBy { get; set; }
            public string Status { get; set; }
            public PassportInfoDTO() { }
            public PassportInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                Number = ef.PassportNumber;
                IssuedDate = ef.PassportIssuedDate;
                ExpirationDate = ef.PassportExpirationDate;
                IssuedBy = ef.PassportIssuedBy;
                Status = ef.PassportStatus;
            }
        }
        public class WorkPermitInfoDTO
        {
            public string Number { get; set; }
            public short? LocationID { get; set; }
            public DateTime? IssuedDate { get; set; }
            public DateTime? ExpirationDate { get; set; }
            public DateTime? LocalStartDate { get; set; }
            public string Position { get; set; }
            public byte? CategoryID { get; set; }
            public WorkPermitInfoDTO() { }
            public WorkPermitInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                Number = ef.WorkPermitNumber;
                LocationID = ef.WorkPermitLocationID;
                IssuedDate = ef.WorkPermitIssuedDate;
                ExpirationDate = ef.WorkPermitIssuedDate;
                LocalStartDate = ef.WorkPermitLocalStartDate;
                Position = ef.WorkPermitPosition;
                CategoryID = ef.WorkPermitCategoryID;
            }
        }
        public class VisaInfoDTO
        {
            public string Number { get; set; }
            public short? TypeID { get; set; }
            public DateTime? IssuedDate { get; set; }
            public DateTime? ExpirationDate { get; set; }
            public DateTime? PoliceRegExpirationDate { get; set; }
            public VisaInfoDTO() { }
            public VisaInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                Number = ef.VisaNumber;
                TypeID = ef.VisaTypeID;
                IssuedDate = ef.VisaIssuedDate;
                ExpirationDate = ef.VisaExpirationDate;
                PoliceRegExpirationDate = ef.PoliceOfficeRegExpirationDate;
            }
        }
        public class TaxPensionMedInfoDTO
        {
            public string IIN { get; set; }
            public string PensionAccountNumber { get; set; }
            public double? PensionPercentage { get; set; }
            public short? PensionGroupID { get; set; }
            public DateTime? MedInsuranceExpirationDate { get; set; }
            public TaxPensionMedInfoDTO() { }
            public TaxPensionMedInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                IIN = ef.IIN;
                PensionAccountNumber = ef.PensionAccountNumber;
                PensionPercentage = ef.PensionPercentage;
                PensionGroupID = ef.PensionGroupID;
                MedInsuranceExpirationDate = ef.MedInsuranceExpirationDate;
            }
        }
        public class ContractInfoDTO
        {
            public string Number { get; set; }
            public DateTime? InitialStartDate { get; set; }
            public DateTime? ProjectDate { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public DateTime? LastAmendmentDate { get; set; }
            public DateTime? LastVacationLastDate { get; set; }
            public short? MonthlyWorkingHours { get; set; }
            public short? MonthlyWorkingHours2 { get; set; }
            public short? RotationTypeID { get; set; }
            public short? RotationType2ID { get; set; }
            public short? TypeID { get; set; }
            public short? Type2ID { get; set; }
            public string CurrencyID { get; set; }
            public double? HolidayFundDays { get; set; }
            public double? BonusFundDays { get; set; }
            public string ProbationPeriodInDays { get; set; }
            public byte? BeforeLeaveNoticePeriodInDays { get; set; }
            public byte? Duration { get; set; }
            public ContractInfoDTO() { }
            public ContractInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                Number = ef.ContractNumber;
                InitialStartDate = ef.InitialContractStartDate;
                ProjectDate = ef.ProjectDate;
                StartDate = ef.ContractStartDate;
                EndDate = ef.ContractEndDate;
                LastAmendmentDate = ef.ContractLastAmendmentDate;
                LastVacationLastDate = ef.LastVacationLastDate;
                MonthlyWorkingHours = ef.MonthlyWorkingHours;
                MonthlyWorkingHours2 = ef.MonthlyWorkingHours2;
                RotationTypeID = ef.RotationTypeID;
                RotationType2ID = ef.RotationType2ID;
                Type2ID = ef.ContractType2ID;
                CurrencyID = ef.CurrencyID;
                HolidayFundDays = ef.HolidayFundDays;
                BonusFundDays = ef.BonusFundDays;
                ProbationPeriodInDays = ef.ProbationPeriodInDays;
                BeforeLeaveNoticePeriodInDays = ef.BeforeLeaveNoticePeriodInDays;
                Duration = ef.ContractDuration;
            }
        }
        public class AccomodationInfoDTO
        {
            public string AccomodationLocation { get; set; }
            public DateTime? CampInDate { get; set; }
            public AccomodationInfoDTO() { }
            public AccomodationInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                AccomodationLocation = ef.AccomodationLocation;
                CampInDate = ef.CampInDate;
            }
        }
        public class EducationInfoDTO
        {
            public short? LevelID { get; set; }
            public string Direction { get; set; }
            public string Major { get; set; }
            public bool? Graduated { get; set; }
            public short? GraduationYear { get; set; }
            public string SchoolOrUniversityName { get; set; }
            public string SchoolOrUniversityAddress { get; set; }
            public EducationInfoDTO() { }
            public EducationInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                LevelID = ef.EducationLevelID;
                Direction = ef.EducationDirection;
                Major = ef.EducationMajor;
                Graduated = ef.EducationGraduated;
                GraduationYear = ef.EducationGraduationYear;
                SchoolOrUniversityName = ef.SchoolOrUniversityName;
                SchoolOrUniversityAddress = ef.SchoolOrUniversityAddress;
            }
        }
        public class BankAccountInfoDTO
        {
            public short? PaymentTypeID { get; set; }
            public string BeneficiaryName { get; set; }
            public string Number { get; set; }
            public short? BankID { get; set; }
            public string BankAddress { get; set; }
            public string BankSWIFT { get; set; }

            public string LocalBeneficiaryName { get; set; }
            public short? LocalBankName { get; set; }
            public string IBAN { get; set; }
            public string PaymentVendorID { get; set; }
            public BankAccountInfoDTO() { }
            public BankAccountInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                PaymentTypeID = ef.PaymentTypeID;
                BeneficiaryName = ef.PaymentBeneficiary;
                Number = ef.BankAccountNumber;
                BankID = ef.BankID;
                BankAddress = ef.BankAddress;
                BankSWIFT = ef.BankSWIFT;

                LocalBeneficiaryName = ef.LocalPaymentBeneficiaryName;
                LocalBankName = ef.LocalBankName;
                IBAN = ef.BankAccountIBAN;
                PaymentVendorID = ef.PaymentVendorID;
            }
        }
        public class EmergencyContactInfoDTO
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string PhoneNumber { get; set; }
            public byte? RelationshipTypeID { get; set; }
            public EmergencyContactInfoDTO() { }
            public EmergencyContactInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                Name = ef.EmergencyContactName;
                Address = ef.EmergencyContactAddress;
                PhoneNumber = ef.EmergencyContactPhoneNumber;
                RelationshipTypeID = ef.EmergencyContactRelationshipTypeID;
            }
        }
        public class ProfessionalRoleInfoDTO
        {
            public string RoleID { get; set; }
            public string HOBUnitID { get; set; }
            public string BOCUnitID { get; set; }
            public ProfessionalRoleInfoDTO() { }
            public ProfessionalRoleInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                RoleID = ef.ProfessionalRoleID;
                HOBUnitID = ef.HOBUnitID;
                BOCUnitID = ef.BOCUnitID;
            }
        }
        public class ContractOtherInfoDTO
        {
            public double? AnnualRotationAllowance { get; set; }
            public double? AnnualBasicSalary { get; set; }
            public double? AnnualOvertimeAllowance { get; set; }
            public bool? ContractIncludesFamily { get; set; }

            public double? TotalTravelSum { get; set; }
            public byte? AirlineTicketTypeID { get; set; }
            public short? DeathInsuranceTypeID { get; set; }
            public short? MedInsuranceTypeID { get; set; }
            public short? LifeInsuranceTypeID { get; set; }
            public short? IncomeProtectionTypeID { get; set; }

            public ContractOtherInfoDTO() { }
            public ContractOtherInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                AnnualRotationAllowance = ef.AnnualRotationAllowance;
                AnnualBasicSalary = ef.AnnualBasicSalary;
                AnnualOvertimeAllowance = ef.AnnualOvertimeAllowance;
                ContractIncludesFamily = ef.ContractIncludesFamily == 1;

                TotalTravelSum = ef.TotalTravelSum;
                AirlineTicketTypeID = ef.AirlineTicketTypeID;
                DeathInsuranceTypeID = ef.DeathInsuranceTypeID;
                MedInsuranceTypeID = ef.MedInsuranceTypeID;
                LifeInsuranceTypeID = ef.LifeInsuranceTypeID;
                IncomeProtectionTypeID = ef.IncomeProtectionTypeID;
            }
        }
        public class OtherInfoDTO
        {
            public string Comments { get; set; }
            public OtherInfoDTO() { }
            public OtherInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                Comments = ef.Comments;
            }
        }
        public class SalaryInfoDTO
        {
            public double? BasicSalary { get; set; }
            public double? BasicSalary2 { get; set; }
            public double? OvertimeRate { get; set; }
            public double? OvertimeRate2 { get; set; }
            public double? OvertimeAllowance { get; set; }
            public double? OvertimeRateWeekdays { get; set; }
            public double? OvertimeRateWeekends { get; set; }
            public double? SiteAllowance { get; set; }
            public short? SiteAllowanceTypeID { get; set; }
            public double? LivingAllowance { get; set; }
            public short? LivingAllowanceTypeID { get; set; }
            public double? VacationDaysRate { get; set; }
            public double? HardshipAllowance { get; set; }
            public double? QuayRate { get; set; }
            public string UnionID { get; set; }
            public bool? IsKindTaxable { get; set; }
            public bool? IsTradeUnionMember { get; set; }
            public bool? IsExemptedFromTaxes { get; set; }
            public bool? IsExemptedFromPensionPayments { get; set; }
            public bool? IsPensionOPFC { get; set; }
            public bool? IsExemptedFromCSHI { get; set; }
            public double? FoodAllowance { get; set; }
            public double? AccomodationAllowance { get; set; }

            public SalaryInfoDTO() { }
            public SalaryInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                BasicSalary = ef.BasicSalary;
                BasicSalary2 = ef.BasicSalary2;
                OvertimeRate = ef.OvertimeRate;
                OvertimeRate2 = ef.OvertimeRate2;
                OvertimeAllowance = ef.OvertimeAllowance;
                OvertimeRateWeekdays = ef.OvertimeRateWeekdays;
                OvertimeRateWeekends = ef.OvertimeRateWeekends;
                SiteAllowance = ef.SiteAllowance;
                SiteAllowanceTypeID = ef.SiteAllowanceTypeID;
                LivingAllowance = ef.LivingAllowance;
                LivingAllowanceTypeID = ef.LivingAllowanceTypeID;
                VacationDaysRate = ef.VacationDaysRate;
                HardshipAllowance = ef.HardshipAllowance;
                QuayRate = ef.QuayRate;
                UnionID = ef.UnionID;
                IsKindTaxable = ef.IsKindTaxable;
                IsTradeUnionMember = ef.IsTradeUnionMember;
                IsExemptedFromTaxes = ef.IsExemptedFromTaxes;
                IsExemptedFromPensionPayments = ef.IsExemptedFromPensionPayments;
                IsPensionOPFC = ef.IsPensionOPFC;
                IsExemptedFromCSHI = ef.IsExemptedFromCSHI;
                FoodAllowance = ef.FoodAllowance;
                AccomodationAllowance = ef.AccomodationAllowance;
            }
        }
        public class JobInfoDTO
        {
            public string CostCenterID { get; set; }
            public string CREA_ID { get; set; }
            public short? LevelID { get; set; }
            public short? QualificationID { get; set; }
            public short? WorkLocationID { get; set; }

            public string ClassID { get; set; }
            public short? KeyResourceID { get; set; }
            public short? NationalizationID { get; set; }
            public JobInfoDTO() { }
            public JobInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                CostCenterID = ef.CostCenterID;
                CREA_ID = ef.CREA_ID;
                LevelID = ef.LevelID;
                QualificationID = ef.QualificationID;
                WorkLocationID = ef.WorkLocationID;

                ClassID = ef.ClassID;
                KeyResourceID = ef.KeyResourceID;
                NationalizationID = ef.NationalizationID;
            }
        }
        public class YTDInfoDTO
        {
            public double? YTDTotalGrossSalary { get; set; }
            public double? YTDTotalGrossAllowance { get; set; }
            public double? YTDTotalExemption { get; set; }
            public double? YTDTotalMCB { get; set; }
            public double? YTDTotalTax { get; set; }
            public double? YTDTotalPension { get; set; }
            public double? YTDTotalBonus { get; set; }
            public double? BFund { get; set; }
            public double? YTDTotalVacMoney { get; set; }
            public double? HFund { get; set; }
            public double? YTDTotalRotationDays { get; set; }
            public YTDInfoDTO() { }
            public YTDInfoDTO(Employee ef)
            {
                FromEF(ef);
            }
            public void FromEF(Employee ef)
            {
                YTDTotalGrossSalary = ef.YTDTotalGrossSalary;
                YTDTotalGrossAllowance = ef.YTDTotalGrossAllowance;
                YTDTotalExemption = ef.YTDTotalExemption;
                YTDTotalMCB = ef.YTDTotalMCB;
                YTDTotalTax = ef.YTDTotalTax;
                YTDTotalPension = ef.YTDTotalPension;
                YTDTotalBonus = ef.YTDTotalBonus;
                BFund = ef.BFund;
                YTDTotalVacMoney = ef.YTDTotalVacMoney;
                HFund = ef.HFund;
                YTDTotalRotationDays = ef.YTDTotalRotationDays;
            }
        }
    }
}