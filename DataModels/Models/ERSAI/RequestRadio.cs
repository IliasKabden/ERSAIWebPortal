namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("RequestRadio")]
    public partial class RequestRadio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required]
        [StringLength(16)]
        public string RequestorBadge { get; set; }
        [Required]
        [StringLength(32)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(32)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(32)]
        public string Company { get; set; }
        [Required]
        [StringLength(50)]
        public string Department { get; set; }
        [Required]
        [StringLength(100)]
        public string Position { get; set; }
        [Required]
        [StringLength(50)]
        public string WorkLocation { get; set; }
        [Required]
        [StringLength(4)]
        public string PhoneExtension { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(16)]
        public string MyDepartmentHeadAccount { get; set; }
        [Required]
        [StringLength(16)]
        public string AssetDepartmentHeadAccount { get; set; }
        [StringLength(16)]
        public string PerformerAccount { get; set; }
        [Required]
        [StringLength(16)]
        public string CreatedByAccount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? RadioID { get; set; }
        public virtual InventoryRadio InventoryRadio { get; set; }

        public virtual List<RequestRadioApprovalHistory> RequestRadioApprovalHistories { get; set; }

        public virtual List<RequestRadioComment> RequestRadioComments { get; set; }
    }
}
