namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_CostCenter")]
    public partial class CostCenter
    {
        [Key, StringLength(6)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Descr { get; set; }
        [StringLength(10)]
        public string Referer { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
    }
}