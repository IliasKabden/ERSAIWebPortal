namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("RequestHelpdesk")]
    public partial class RequestHelpdesk
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        public int CategoryID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, StringLength(36)]
        public string ComputerName { get; set; }
        public int PhoneExtension { get; set; }
        public int SiteID { get; set; }
        [Required, StringLength(255)]
        public string Location { get; set; }
        public int StatusID { get; set; }
        public int PriorityID { get; set; }
        [Required, StringLength(20)]
        public string CreatedByAccount { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required, StringLength(20)]
        public string RequestorAccount { get; set; }
        [StringLength(20)]
        public string OperatorAccount { get; set; }
        [StringLength(20)]
        public string PerformerAccount { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int? Mark { get; set; }
        public int? repeat { get; set; }
        public virtual RequestHelpdeskCategory RequestHelpdeskCategory { get; set; }
        public virtual RequestHelpdeskPriority RequestHelpdeskPriority { get; set; }
        public virtual List<RequestHelpdeskComment> RequestHelpdeskComments { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
        public virtual Site Site { get; set; }
    }
}