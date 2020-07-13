namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("RequestICTTask")]
    public partial class RequestICTTask
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [StringLength(16)]
        public string CreatedByAccount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }
        public int PriorityID { get; set; }
        public int Progress { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
        [StringLength(16)]
        public string ApprovedByAccount { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public virtual RequestICTTaskCategory RequestICTTaskCategory { get; set; }
        public virtual RequestPriority RequestPriority { get; set; }

        public virtual List<RequestICTTaskComment> RequestICTTaskComments { get; set; }
    }
}
