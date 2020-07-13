namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("RequestAbsence")]
    public partial class RequestAbsence
    {
        [Key]
        public int? ID { get; set; }
        [Required, StringLength(10), Column("RequestorBadge"), ForeignKey(nameof(Requestor))]
        public string RequestorBadge { get; set; }
        public virtual Employee Requestor { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string Department { get; set; }
        [StringLength(100)]
        public string Position { get; set; }
        [Column(TypeName = "date")]
        public DateTime? RequestedDate { get; set; }
        public TimeSpan? FromTime1 { get; set; }
        public TimeSpan? TillTime1 { get; set; }
        public bool? isWorkReason1 { get; set; }
        [StringLength(255)]
        public string Comment1 { get; set; }
        [StringLength(50)]
        public string MyDepartmentHeadAccount { get; set; }
        [StringLength(50)]
        public string CreatedByAccount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? DeaprtmentHeadActionDate { get; set; }
        public int? Status { get; set; }
        public TimeSpan? FromTime2 { get; set; }
        public TimeSpan? TillTime2 { get; set; }
        public bool? isWorkReason2 { get; set; }
        [StringLength(255)]
        public string Comment2 { get; set; }
    }
}