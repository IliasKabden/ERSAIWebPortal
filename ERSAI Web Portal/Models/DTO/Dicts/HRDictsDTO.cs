using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.IMS.DTO.Dicts
{
    public class HRDictsDTO
    {
        public IEnumerable<DictItemDTO> Positions { get; set; }
        public IEnumerable<DictItemDTO> Departments { get; set; }
        public IEnumerable<DictItemDTO> Projects { get; set; }
        public IEnumerable<string> Sections { get; set; }
        public IEnumerable<DictItemDTO> EmployeeGroups { get; set; }
        public IEnumerable<string> Cities { get; set; }
        public IEnumerable<DictItemDTO> Countries { get; set; }
        public IEnumerable<string> Religions { get; set; }
        public IEnumerable<string> PassportIssuedBy { get; set; }
        public IEnumerable<string> PassportStatuses { get; set; }
        public IEnumerable<string> WorkPermitPositions { get; set; }
        public IEnumerable<DictItemDTO> WorkPermitLocations { get; set; }
        public IEnumerable<DictItemDTO> WorkPermitCategories { get; set; }
        public IEnumerable<DictItemDTO> BusinessUnits { get; set; }
        public IEnumerable<DictItemDTO> Employees { get; set; }
        public IEnumerable<DictItemDTO> EmployeeStatuses { get; set; }
        public IEnumerable<DictItemDTO> MaritalStatuses { get; set; }
        public IEnumerable<DictItemDTO> PensionGroups { get; set; }
        public IEnumerable<DictItemDTO> RotationTypes { get; set; }
        public IEnumerable<DictItemDTO> ContractTypes { get; set; }
        public IEnumerable<DictItemDTO> Currencies { get; set; }
        public IEnumerable<DictItemDTO> EducationLevels { get; set; }
        public IEnumerable<string> EducationDirections { get; set; }
        public IEnumerable<string> EducationMajors { get; set; }
        public IEnumerable<DictItemDTO> PaymentTypes { get; set; }
        public IEnumerable<DictItemDTO> Banks { get; set; }
        public IEnumerable<DictItemDTO> RelationshipTypes { get; set; }
        public IEnumerable<DictItemDTO> Genders { get; set; }
        public IEnumerable<DictItemDTO> ProfessionalRoles { get; set; }
        public IEnumerable<DictItemDTO> HOBUnits { get; set; }
        public IEnumerable<DictItemDTO> BOCUnits { get; set; }
        public IEnumerable<DictItemDTO> EmployeeStatusReasons { get; set; }
    }
}