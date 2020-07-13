namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class RequestApprovalType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required, StringLength(32)]
        public string ApprovalType { get; set; }
        public virtual List<RequestRadioApprovalHistory> RequestRadioApprovalHistories { get; set; }
        public virtual List<RequestSimCardAndMobilePhoneApprovalHistory> RequestSimCardAndMobilePhoneApprovalHistories { get; set; }
        public virtual List<RequestWifiApprovalHistory> RequestWifiApprovalHistories { get; set; }
    }
}