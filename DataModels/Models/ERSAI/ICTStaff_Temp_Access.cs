namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string BadgeNumber { get; set; }
        [Column(Order = 1)]
        [StringLength(16)]
        public string Account { get; set; }
        public string CrewChange { get; set; }
        public string Site { get; set; }
    }
}