namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_EmpGroup")]
    public partial class EmployeeGroup
    {
        [Key, StringLength(3)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Descr { get; set; }
        [StringLength(6)]
        public string SIDAC { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
    }
}