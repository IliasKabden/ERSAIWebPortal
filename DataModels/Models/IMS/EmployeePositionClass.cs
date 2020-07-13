namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_PosClass")]
    public partial class EmployeePositionClass
    {
        [Key, StringLength(1)]
        public string Code { get; set; }
        [StringLength(30)]
        public string Descr { get; set; }
        public virtual ICollection<EmployeePosition> Positions { get; set; }
    }
}