namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_Currency")]
    public partial class Currency
    {
        [Key, StringLength(3)]
        public string Code { get; set; }
        [StringLength(20)]
        public string Descr { get; set; }
        [StringLength(5)]
        public string Symbol { get; set; }
        public double? CCount { get; set; }
        public double? Rate { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}