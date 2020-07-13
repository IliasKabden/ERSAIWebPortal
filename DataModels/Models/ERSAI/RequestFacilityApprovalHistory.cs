namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("RequestFacilityApprovalHistory")]
    public partial class RequestFacilityApprovalHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestID { get; set; }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApprovalTypeID { get; set; }
        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatusID { get; set; }
        [Key]
        [Column(Order = 3)]
        public DateTime CreatedDate { get; set; }
        public virtual RequestFacility RequestFacility { get; set; }
        public virtual RequestFacilityApprovalType RequestFacilityApprovalType { get; set; }
        public virtual RequestStatus RequestStatus { get; set; }
    }
}
