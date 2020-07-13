namespace DataModels.Models.Travel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("LeaveRequest")]
    public partial class LeaveRequest
    {
        public int id { get; set; }

        [Required, StringLength(20)]
        public string RefNo { get; set; }

        [Required, StringLength(50)]
        public string BadgeNo { get; set; }

        public DateTime? DateApply { get; set; }

        public int LeaveTypeCode { get; set; }

        [Required, StringLength(255)]
        public string OthersReason { get; set; }

        public short Status { get; set; }

        [Required, StringLength(11)]
        public string HRUser { get; set; }

        [Required, StringLength(255)]
        public string HRRemarks { get; set; }

        public DateTime? HRStatDate { get; set; }

        public DateTime? DateStatus { get; set; }

        [Required, StringLength(50)]
        public string EmailRecipient1 { get; set; }

        [Required, StringLength(50)]
        public string EmailRecipient2 { get; set; }

        [Required, StringLength(50)]
        public string EmailRecipient3 { get; set; }

        [Required, StringLength(11)]
        public string RecipientID1 { get; set; }

        [Required, StringLength(11)]
        public string DisapprovedBy { get; set; }

        public Boolean? ReqFlight { get; set; }

        [Required, StringLength(20)]
        public string VacationDue { get; set; }

        [Required, StringLength(50)]
        public string DateVisaExpiry { get; set; }

        [Required, StringLength(20)]
        public string ContractStatus { get; set; }

        [Required, StringLength(11)]
        public string UserID { get; set; }

        public DateTime? LastUpdate { get; set; }

        [Required, StringLength(20)]
        public string LastVacation { get; set; }

    }
}
