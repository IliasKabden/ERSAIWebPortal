namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_UnionGroup")]
    public partial class UnionGroup
    {
        [Key, StringLength(3)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Descr { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}