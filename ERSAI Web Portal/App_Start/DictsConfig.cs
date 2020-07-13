using DataModels;
using ERSAI_Web_Portal.Controllers;
using ERSAI_Web_Portal.Models.DTO.Dicts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static ERSAI_Web_Portal.Controllers.AppBaseMVCController;

namespace ERSAI_Web_Portal
{
    public class DictsConfig
    {
        public const string HRDictName = "HR",
            UMDictName = "UM";
        public static void Configure(MvcApplication app)
        {
            var Dicts = app.Dicts = new Dictionary<string, DictsDTO>();
            Dicts[HRDictName] = new DictsDTO()
            {
                DictsRetrievalFunction = (MVCControllerDbContexts contexts) =>
                {
                    var IMSDB = contexts.IMS;
                    var dicts = new Dictionary<string, object>
                    {
                        { "Positions", IMSDB.EmployeesPositions.Select(p => new DictItemDTO() { ID = p.Code.ToString(), Name = p.Name + " (" + p.DescrLoc + ")" }).OrderBy(x => x.Name) },
                        { "Departments", IMSDB.Departments.Select(d => new DictItemDTO() { ID = d.Code, Name = d.Descr }).OrderBy(x => x.Name) },
                        { "Projects", IMSDB.Projects.Select(d => new DictItemDTO() { ID = d.Code, Name = d.Code + " (" + d.Descr + ")" }).OrderBy(x => x.Name) },
                        { "Sections", IMSDB.Employees.Select(e => e.Section).Distinct().Where(x => x != null).OrderBy(x => x) },
                        { "EmployeeGroups", IMSDB.EmployeeGroups.Select(g => new DictItemDTO() { ID = g.Code, Name = g.Descr }).OrderBy(x => x.Name) },
                        { "Cities", IMSDB.Employees.Select(e => e.City).Distinct().Where(x => x != null).OrderBy(x => x) },
                        { "Countries", IMSDB.Countries.Select(c => new CountryDTO() { ID = c.Code, Name = c.Descr, CSSIconClass = c.SIDAC.Trim().ToLower(), NationalityName = c.NationalityName }).OrderBy(x => x.Name) },
                        { "Religions", IMSDB.Employees.Select(e => e.Religion).Distinct().Where(x => x != null).OrderBy(x => x) },
                        { "PassportIssuedBy", IMSDB.Employees.Select(e => e.PassportIssuedBy).Distinct().Where(x => x != null).OrderBy(x => x) },
                        { "PassportStatuses", IMSDB.Employees.Select(e => e.PassportStatus).Distinct().Where(x => x != null).OrderBy(x => x) },
                        { "VisaTypes", IMSDB.VisaTypes.Select(vt => new DictItemDTO() { ID = vt.Code.ToString(), Name = vt.Descr }).OrderBy(x => x.Name) },
                        { "WorkPermitPositions", IMSDB.Employees.Select(e => e.WorkPermitPosition).Distinct().Where(x => x != null).OrderBy(x => x) },
                        { "WorkPermitLocations", IMSDB.WorkPermitLocations.Select(loc => new DictItemDTO() { ID = loc.Code.ToString(), Name = loc.Descr }).OrderBy(x => x.Name) },
                        { "WorkPermitCategories", IMSDB.WorkPermitCategories.Select(cat => new DictItemDTO() { ID = cat.Code.ToString(), Name = cat.Descr }).OrderBy(x => x.Name) },
                        { "BusinessUnits", IMSDB.BusinessUnits.Select(bu => new DictItemDTO() { ID = bu.Code, Name = bu.Descr }).OrderBy(x => x.Name) },
                        { "Employees", IMSDB.Employees
                            .Select(emp => new DictItemDTO()
                            {
                                ID = emp.BadgeNumber,
                                Name = emp.FirstName + " " + emp.MiddleName + " " + emp.LastName,
                                IsNotActive = (emp.StatusID == null || emp.StatusID.Value == 8)
                            })
                            .OrderBy(emp => emp.Name) },
                        { "EmployeeStatuses", IMSDB.EmployeeStatuses.Select(es => new DictItemDTO() { ID = es.Code.ToString(), Name = es.Descr.Trim() }).OrderBy(x => x.Name) },
                        { "MaritalStatuses", IMSDB.MaritalStatuses.Select(ms => new DictItemDTO() { ID = ms.Code, Name = ms.Descr }).OrderBy(x => x.Name) },
                        { "PensionGroups", IMSDB.PensionGroups.Select(ms => new DictItemDTO() { ID = ms.Code.ToString(), Name = ms.Descr }).OrderBy(x => x.Name) },
                        { "RotationTypes", IMSDB.RotationTypes.Select(rt => new DictItemDTO() { ID = rt.Code.ToString(), Name = rt.DayOn.ToString() + "/" + rt.DayOff.ToString() + " (" + rt.Descr + ")" }).OrderBy(x => x.Name) },
                        { "ContractTypes", IMSDB.ContractTypes.Select(ct => new DictItemDTO() { ID = ct.Code.ToString(), Name = ct.Descr }).OrderBy(x => x.Name) },
                        { "Currencies", IMSDB.Currencies.Select(c => new DictItemDTO() { ID = c.Code, Name = c.Code + " (" + c.Descr + ")" }).OrderBy(x => x.Name) },
                        { "EducationLevels", IMSDB.EducationLevels.Select(l => new DictItemDTO() { ID = l.Code.ToString(), Name = l.Descr }).OrderBy(x => x.Name) },
                        { "EducationDirections", IMSDB.Employees.Select(e => e.EducationDirection).Distinct().Where(x => x != null).OrderBy(x => x) },
                        { "EducationMajors", IMSDB.Employees.Select(e => e.EducationMajor).Distinct().Where(x => x != null).OrderBy(x => x) },
                        { "PaymentTypes", IMSDB.PaymentTypes.Select(pt => new DictItemDTO() { ID = pt.Code.ToString(), Name = pt.Descr }).OrderBy(x => x.Name) },
                        { "Banks", IMSDB.Banks.Select(b => new DictItemDTO() { ID = b.Code.ToString(), Name = b.Name + (b.BankCode != null ? (", " + b.BankCode) : "") + (b.BranchCode != null ? (", " + b.BranchCode) : "") }).OrderBy(x => x.Name) },
                        { "RelationshipTypes", IMSDB.RelationshipTypes.Select(rt => new DictItemDTO() { ID = rt.Code.ToString(), Name = rt.Descr }).OrderBy(x => x.Name) },
                        { "Genders", new[] { new DictItemDTO() { ID = "M", Name = "Male" }, new DictItemDTO() { ID = "F", Name = "Female" } } },
                        { "ProfessionalRoles", IMSDB.ProfessionalRoles.Select(pr => new DictItemDTO() { ID = pr.Code, Name = pr.Code + ", " + (pr.Descr + " (" + pr.Family.Descr + ")").Replace(" ()", string.Empty) }).OrderBy(x => x.Name) },
                        { "HOBUnits", IMSDB.HOBUnits.Select(u => new DictItemDTO() { ID = u.Code, Name = u.Descr }).OrderBy(x => x.Name) },
                        { "BOCUnits", IMSDB.BOCUnits.Select(u => new DictItemDTO() { ID = u.Code, Name = u.Descr }).OrderBy(x => x.Name) },
                        { "EmployeeStatusReasons", IMSDB.EmployeeStatusReasons.Select(u => new DictItemDTO() { ID = u.Code.ToString(), Name = u.Descr }).OrderBy(x => x.Name) },
                        { "CostCenters", IMSDB.CostCenters.Select(cc => new DictItemDTO() { ID = cc.Code, Name = cc.Code + " (" + cc.Descr + ")" }).OrderBy(x => x.Name) },
                        { "CREAValues", IMSDB.CREAValues.Select(c => new DictItemDTO() { ID = c.Code, Name = c.Descr }).OrderBy(x => x.Name) },
                        { "EmployeeLevels", IMSDB.EmployeeLevels.Select(l => new DictItemDTO() { ID = l.Code.ToString(), Name = l.Level+" ("+ l.Descr+")" }).OrderBy(x => x.Name) },
                        { "Qualifications", IMSDB.EmployeeQualifications.Select(q => new DictItemDTO() { ID = q.Code.ToString(), Name = q.Descr }).OrderBy(x => x.Name) },
                        { "WorkLocations", IMSDB.WorkLocations.Select(wl => new DictItemDTO() { ID = wl.Code.ToString(), Name = wl.Descr }).OrderBy(x => x.Name) },
                        { "EmployeeClasses", IMSDB.EmployeeClasses.Select(c => new DictItemDTO() { ID = c.Code, Name = c.Descr }).OrderBy(x => x.Name) },
                        { "KeyResources", IMSDB.KeyResources.Select(res => new DictItemDTO() { ID = res.Code.ToString(), Name = res.Descr }).OrderBy(x => x.Name) },
                        { "Nationalizations", IMSDB.Nationalizations.Select(n => new DictItemDTO() { ID = n.Code.ToString(), Name = n.Descr }).OrderBy(x => x.Name) },

                        { "SiteAllowanceTypes", new[] { new DictItemDTO() { ID = "0", Name = "Daily" }, new DictItemDTO() { ID = "1", Name = "Monthly" } } },
                        { "LivingAllowanceTypes", new[] { new DictItemDTO() { ID = "0", Name = "Daily KZT" }, new DictItemDTO() { ID = "1", Name = "Monthly KZT" } } },
                        { "UnionGroups", IMSDB.UnionGroups.Select(g => new DictItemDTO() { ID = g.Code, Name = g.Descr }).OrderBy(x => x.Name) },
                        { "AirlineTicketTypes", IMSDB.TicketTypes.Select(t => new DictItemDTO() { ID = t.Code.ToString(), Name = t.Descr }).OrderBy(x => x.Name) },
                        { "DeathInsuranceTypes", IMSDB.DeathInsuranceTypes.Select(t => new DictItemDTO() { ID = t.Code.ToString(), Name =System.Data.Entity.SqlServer.SqlFunctions.StringConvert(t.Amount) }).OrderBy(x => x.Name) },
                        { "MedInsuranceTypes", IMSDB.MedInsuranceTypes.Select(t => new DictItemDTO() { ID = t.Code.ToString(), Name = t.Descr }).OrderBy(x => x.Name) },
                        { "LifeInsuranceTypes", IMSDB.LifeInsuranceTypes.Select(t => new DictItemDTO() { ID = t.Code.ToString(), Name = System.Data.Entity.SqlServer.SqlFunctions.StringConvert(t.Amount) }).OrderBy(x => x.Name) },
                        { "IncomeProtectionTypes", IMSDB.IncomeProtectionTypes.Select(t => new DictItemDTO() { ID = t.Code.ToString(), Name = t.Descr }).OrderBy(x => x.Name) },
                        { "EmployeeCategories", new[] { new DictItemDTO() { ID = "E", Name = "Expat" }, new DictItemDTO() { ID = "L", Name = "Local" } } },

                        { "BirthPlaces", IMSDB.Employees.Select(e => e.BirthPlace).Distinct().Where(x => x != null).OrderBy(x => x) },
                        { "Towns", IMSDB.Employees.Select(e => e.Town).Distinct().Where(x => x != null).OrderBy(x => x) },
                        { "AccomodationLocations", IMSDB.Employees.Select(e => e.AccomodationLocation).Distinct().Where(x => x != null).OrderBy(x => x) },
                        { "BankSWIFTValues", IMSDB.Employees.Select(e => e.BankSWIFT).Distinct().Where(x => x != null).OrderBy(x => x) }

                    };
                    return JsonConvert.SerializeObject(dicts);
                }
            };
            Dicts[UMDictName] = new DictsDTO()
            {
                DictsRetrievalFunction = (MVCControllerDbContexts contexts) =>
                {
                    var dicts = new Dictionary<string, object>
                    {
                        { "Roles", contexts.ERSAI.Roles.Select(x => new DictItemDTO() { ID = x.Id, Name = x.Description ?? x.Name }).OrderBy(x => x.Name) },
                        { "EmployeeClassSections", Enum.GetValues(typeof(DataModels.Models.IMS.Employee.ComplexInfoSection))
                            .Cast<DataModels.Models.IMS.Employee.ComplexInfoSection>()
                            .Select(x => new DictItemDTO<DataModels.Models.IMS.Employee.ComplexInfoSection>() {
                                ID = x,
                                Name = x.ToString()
                            })
                        },
                        { "BusinessUnits", contexts.IMS.BusinessUnits.Select(bu => new DictItemDTO() { ID = bu.Code, Name = bu.Descr }).OrderBy(x => x.Name) }
                    };
                    return JsonConvert.SerializeObject(dicts);
                }
            };
        }
    }
}