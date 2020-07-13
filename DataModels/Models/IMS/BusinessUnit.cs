namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_BussUnit")]
    public partial class BusinessUnit
    {
        [Key, StringLength(6)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Descr { get; set; }
        public byte[] Logo { get; set; }
        public virtual ICollection<Project> tb_Project { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
    }
}