namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Department")]
    public partial class Department
    {
        public int ID { get; set; }
        [Required, StringLength(16)]
        public string Code { get; set; }
        [Column("Department"), Required, StringLength(100)]
        public string Name { get; set; }
        public virtual List<Audit> Audits { get; set; }
    }
}
