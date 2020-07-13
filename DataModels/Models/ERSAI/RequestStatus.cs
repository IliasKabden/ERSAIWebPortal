namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("RequestStatuses")]
    public partial class RequestStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required]
        [StringLength(32)]
        public string Status { get; set; }

        public virtual List<RequestHelpdesk> RequestHelpdesks { get; set; }

        public virtual List<RequestRadioApprovalHistory> RequestRadioApprovalHistories { get; set; }

        public virtual List<RequestSimCardAndMobilePhoneApprovalHistory> RequestSimCardAndMobilePhoneApprovalHistories { get; set; }

        public virtual List<RequestFacilityApprovalHistory> RequestFacilityApprovalHistories { get; set; }
    }
}
