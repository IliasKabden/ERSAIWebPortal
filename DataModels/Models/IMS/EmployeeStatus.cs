namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_EmpStat")]
    public partial class EmployeeStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Code { get; set; }
        [StringLength(10)]
        public string Descr { get; set; }
        [StringLength(10)]
        public string SIDAC { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
    }
}