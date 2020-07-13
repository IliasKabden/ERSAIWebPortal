using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERSAI_Web_Portal.Areas.PersonalAccount.Models
{
    public partial class PersonalDetailsVM
    {
        public string BadgeNumber { get; set; }
        public string MailAddress { get; set; }
        public string FullName { get; set; }
        public string BusinessUnit { get; set; }
        public string Department { get; set; }
        public string ContractPosition { get; set; }
        public string CostCenter { get; set; }
        public string WorkLocation { get; set; }
        public string ProfessionalRole { get; set; }
        public string Classification { get; set; }
        public string Status { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? ProjectDate { get; set; }
        public DateTime? LastVacationLastDate { get; set; }
        public DateTime? VisaExpirationDate { get; set; }
        public DateTime? WorkPermitExpirationDate { get; set; }
        public DateTime? PoliceOfficeRegExpirationDate { get; set; }
        public int? DaysOnSiteAfterLastVacation
        {
            get
            {
                return (DateTime.Now - LastVacationLastDate)?.Days;
            }
        }
        public RotationInfoVM RotationInfo { get; set; }
        public PassportInfoVM PassportInfo { get; set; }
        public class RotationInfoVM
        {
            public PersonalDetailsVM p;

            public int? DaysOnSite { get; set; }
            public int? DaysOffSite { get; set; }
            public decimal? AccumulatedVacationDays
            {
                get
                {
                    return (decimal?)p.DaysOnSiteAfterLastVacation / DaysOnSite * DaysOffSite;
                }
            }
            public DateTime? NextForeseenVacationStartDate
            {
                get
                {
                    if (p.LastVacationLastDate != null && DaysOnSite != null)
                        return p.LastVacationLastDate.Value.AddDays(DaysOnSite.Value);
                    return null;
                }
            }
            public DateTime? NextForeseenRotationStartDate
            {
                get
                {
                    if (NextForeseenVacationStartDate != null && DaysOffSite != null)
                        return NextForeseenVacationStartDate.Value.AddDays(DaysOffSite.Value);
                    return null;
                }
            }
        }
        public class PassportInfoVM
        {
            public string Number;
            public DateTime? IssuedDate;
            public DateTime? ExpirationDate;
            public string IssuedBy;
        }
    }
    public partial class PersonalDetailsVM
    {
        public void FromIMSEmployee(DataModels.Models.IMS.Employee ef)
        {
            BadgeNumber = ef.BadgeNumber;
            MailAddress = ef.MailAddress;
            FullName = ef.FullName;
            BusinessUnit = ef.BusinessUnitID;
            Department = ef.DepartmentID == null ? null : $"{ef.DepartmentID} ({ef.Department.Descr})";
            ContractPosition = ef.ContractPosition?.Name;
            CostCenter = ef.CostCenter?.Descr;
            WorkLocation = ef.WorkLocation?.Descr;
            ProfessionalRole = ef.ProfessionalRole?.Descr;
            Classification = ef.Class?.Descr;
            Status = ef.Status?.Descr;
            ContractStartDate = ef.ContractStartDate;
            ReleaseDate = ef.ReleaseDate;
            ProjectDate = ef.ProjectDate;
            LastVacationLastDate = ef.LastVacationLastDate;
            VisaExpirationDate = ef.VisaExpirationDate;
            WorkPermitExpirationDate = ef.WorkPermitExpirationDate;
            PoliceOfficeRegExpirationDate = ef.PoliceOfficeRegExpirationDate;

            RotationInfo = ef.RotationType != null ? new RotationInfoVM()
            {
                p = this,
                DaysOnSite = ef.RotationType.DayOn,
                DaysOffSite = ef.RotationType.DayOff
            } : null;
            PassportInfo = new PassportInfoVM()
            {
                Number = ef.PassportNumber,
                IssuedDate = ef.PassportIssuedDate,
                ExpirationDate = ef.PassportExpirationDate,
                IssuedBy = ef.PassportIssuedBy,
            };
        }
        public void FromERSAIEmployee(DataModels.ERSAI.Employee ef)
        {
            BadgeNumber = ef.BadgeNumber;
            MailAddress = null;
            FullName = ef.FullName;
            BusinessUnit = null;
            Department = $"{ef.Department} ({ef.DepartmentDescription})";
            ContractPosition = ef.Position;
            CostCenter = ef.CostCenter;
            WorkLocation = ef.WorkLocation;
            ProfessionalRole = ef.ProfessionalRole;
            Classification = null;
            Status = ef.Status == 1 ? "Active" : "-";
            ContractStartDate = ef.ContractDate;
            ReleaseDate = ef.ReleaseDate;
            ProjectDate = null;
            LastVacationLastDate = null;

            PassportInfo = null;
        }
    }
}