namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("RequestRadioApprovalHistory")]
    public partial class RequestRadioApprovalHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestID { get; set; }        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApprovalTypeID { get; set; }        public int StatusID { get; set; }        public DateTime CreatedDate { get; set; }        public virtual RequestApprovalType RequestApprovalType { get; set; }        public virtual RequestRadio RequestRadio { get; set; }        public virtual RequestStatus RequestStatus { get; set; }
    }
}
