namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_Project")]
    public partial class Project
    {
        [Key, StringLength(10)]
        public string Code { get; set; }
        [StringLength(100)]
        public string Descr { get; set; }
        [StringLength(100)]
        public string DescrLoc { get; set; }
        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [StringLength(10)]
        public string Manager { get; set; }
        [StringLength(6)]
        public string BussUnit { get; set; }
        public virtual BusinessUnit tb_BussUnit { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
    }
}