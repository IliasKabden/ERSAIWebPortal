namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_BOCUnit")]
    public partial class BOCUnit
    {
        [Key, StringLength(6)]
        public string Code { get; set; }
        [StringLength(30)]
        public string Descr { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}