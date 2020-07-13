namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_EmpClass")]
    public partial class EmployeeClass
    {
        [Key, StringLength(4)]
        public string Code { get; set; }
        [StringLength(30)]
        public string Descr { get; set; }
        [StringLength(2)]
        public string Level { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}