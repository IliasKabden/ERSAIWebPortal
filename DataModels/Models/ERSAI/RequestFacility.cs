namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("RequestFacility")]
    public partial class RequestFacility
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        public int? ComputerID { get; set; }
        [Required, StringLength(30)]
        public string RequestorBadge { get; set; }
        [Required, StringLength(32)]
        public string Firstname { get; set; }
        [Required, StringLength(32)]
        public string Lastname { get; set; }
        [Required, StringLength(50)]
        public string Company { get; set; }
        [Required, StringLength(50)]
        public string Department { get; set; }
        [StringLength(100)]
        public string Position { get; set; }
        [Required, StringLength(50)]
        public string WorkLocation { get; set; }
        [StringLength(255)]
        public string Building { get; set; }
        public int PhoneAccessID { get; set; }
        public bool? InternetAccess { get; set; }
        public bool? EmailAccount { get; set; }
        public bool? TokenKey { get; set; }
        [StringLength(255)]
        public string Software { get; set; }
        [StringLength(255)]
        public string Hardware { get; set; }
        [Required, StringLength(16)]
        public string CreatedByAccount { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required, StringLength(16)]
        public string DepartmentHeadAccount { get; set; }
        [StringLength(16)]
        public string HRDepartmentHeadAccount { get; set; }
        [Required, StringLength(16)]
        public string ICTDepartmentHeadAccount { get; set; }
        [StringLength(16)]
        public string PerformerAccount { get; set; }
        [StringLength(100)]
        public string ThirdPartyFullName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ThirdPartyWorkPeriodFrom { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ThirdPartyWorkPeriodTo { get; set; }
        public bool IsThirdParty { get; set; }
        public int? pid { get; set; }
        [StringLength(64)]
        public string B2B_Badge_Number { get; set; }
        public virtual RequestFacilityPhoneAccess RequestFacilityPhoneAccess { get; set; }
        public virtual List<RequestFacilityApprovalHistory> RequestFacilityApprovalHistories { get; set; }
        public virtual List<RequestFacilityComment> RequestFacilityComments { get; set; }
    }
}