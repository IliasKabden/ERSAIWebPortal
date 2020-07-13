namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class ICTStaff_Temp_Access
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string BadgeNumber { get; set; }        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string Account { get; set; }        [StringLength(1)]
        public string CrewChange { get; set; }        [StringLength(100)]
        public string Site { get; set; }
    }
}
