namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("ICTStaff")]
    public partial class ICTStaff
    {
        [Key, Column(Order = 0), StringLength(10), ForeignKey(nameof(Employee))]
        public string BadgeNumber { get; set; }
        public virtual Employee Employee { get; set; }
        [Key, Column(Order = 1), StringLength(16)]
        public string Account { get; set; }
        [StringLength(1)]
        public string CrewChange { get; set; }
    }
}