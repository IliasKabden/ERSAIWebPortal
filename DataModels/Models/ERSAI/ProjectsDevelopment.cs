namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class ProjectsDevelopment
    {
        public int ID { get; set; }
        [StringLength(32)]
        public string Department { get; set; }
        [StringLength(100)]
        public string ProjectName { get; set; }
        [StringLength(255)]
        public string ProjectDescription { get; set; }
        [StringLength(32)]
        public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? Deadline { get; set; }
        public string ContactBadgeNumber { get; set; }
    }
}