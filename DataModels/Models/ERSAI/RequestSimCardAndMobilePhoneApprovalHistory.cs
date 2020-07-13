namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("RequestSimCardAndMobilePhoneApprovalHistory")]
    public partial class RequestSimCardAndMobilePhoneApprovalHistory
    {
        public int ID { get; set; }        public int RequestID { get; set; }        public int ApprovalTypeID { get; set; }        public int StatusID { get; set; }        public DateTime CreatedDate { get; set; }        public virtual RequestApprovalType RequestApprovalType { get; set; }        public virtual RequestSimCardAndMobilePhone RequestSimCardAndMobilePhone { get; set; }        public virtual RequestStatus RequestStatus { get; set; }
    }
}
