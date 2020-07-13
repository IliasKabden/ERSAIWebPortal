namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_Marital")]
    public partial class MaritalStatus
    {
        [Key, StringLength(1)]
        public string Code { get; set; }
        [StringLength(20)]
        public string Descr { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
    }
}