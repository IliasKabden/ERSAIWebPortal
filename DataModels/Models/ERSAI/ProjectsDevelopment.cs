namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("ProjectsDevelopment")]
    public partial class ProjectsDevelopment
    {
        public int ID { get; set; }        [Required]
        [StringLength(32)]
        public string Department { get; set; }        [Required]
        [StringLength(100)]
        public string ProjectName { get; set; }        [Required]
        [StringLength(255)]
        public string ProjectDescription { get; set; }        public int? Order { get; set; }        [Required]
        [StringLength(32)]
        public string Status { get; set; }        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }        [Column(TypeName = "date")]
        public DateTime? CompletedDate { get; set; }        public byte PercentageOfCompletion { get; set; }        [Column(TypeName = "date")]
        public DateTime? Deadline { get; set; }        [StringLength(12)]
        public string ContactBadgeNumber { get; set; }
    }
}
