namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("RequestWifi")]
    public partial class RequestWifi
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        public int GroupID { get; set; }
        [Required, StringLength(10), ForeignKey(nameof(Employee))]
        public string BadgeNumber { get; set; }
        public virtual Employee Employee { get; set; }
        [StringLength(32)]
        public string ThirdPartyFirstName { get; set; }
        [StringLength(32)]
        public string ThirdPartyLastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? WorkPeriodFrom { get; set; }
        [Column(TypeName = "date")]
        public DateTime? WorkPeriodTo { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [StringLength(12)]
        public string MyManagerAccount { get; set; }
        [StringLength(12)]
        public string HRManagerAccount { get; set; }
        [StringLength(12)]
        public string ProjectManagerAccount { get; set; }
        [StringLength(12)]
        public string ICTManagerAccount { get; set; }
        [StringLength(12)]
        public string PerformerAccount { get; set; }
        [Required]
        [StringLength(12)]
        public string CreatedByAccount { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual RequestWifiGroup RequestWifiGroup { get; set; }
        public virtual List<RequestWifiApprovalHistory> RequestWifiApprovalHistories { get; set; }
        public virtual List<RequestWifiComment> RequestWifiComments { get; set; }
        public virtual List<RequestWifiDevice> RequestWifiDevices { get; set; }
    }
}
