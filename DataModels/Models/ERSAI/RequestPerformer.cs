namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class RequestPerformer
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestTypeID { get; set; }
        [Key, Column(Order = 1), StringLength(16)]
        public string Account { get; set; }
        [Key, Column(Order = 2), StringLength(10), ForeignKey(nameof(Employee))]
        public string BadgeNumber { get; set; }
        public virtual Employee Employee { get; set; }
        [StringLength(32)]
        public string Company { get; set; }
        public int? SiteID { get; set; }
    }
}