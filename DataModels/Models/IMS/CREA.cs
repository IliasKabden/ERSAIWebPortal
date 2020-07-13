namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_CREA")]
    public partial class CREA
    {
        [Key, StringLength(2)]
        public string Code { get; set; }
        [StringLength(30)]
        public string Descr { get; set; }
        public double? Family { get; set; }
        public double? Single { get; set; }
        public double? Onshore { get; set; }
        public double? Offshore { get; set; }
        public double? Drilling { get; set; }
        public double? Quay { get; set; }
        public virtual ICollection<EmployeePosition> tb_Position { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
    }
}