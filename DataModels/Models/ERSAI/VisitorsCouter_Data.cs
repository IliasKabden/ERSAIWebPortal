namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class VisitorsCouter_Data
    {
        public int ID { get; set; }
        [StringLength(100)]
        public string Login { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime? Visit_date { get; set; }
        public string BadgeNumLogin { get; set; }
    }
}