namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("RequestSimCardAndMobilePhone")]
    public partial class RequestSimCardAndMobilePhone
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        public int? MobilePhoneID { get; set; }
        [Required]
        [StringLength(30)]
        public string RequestorBadge { get; set; }
        [StringLength(50)]
        public string Firstname { get; set; }
        [StringLength(50)]
        public string Lastname { get; set; }
        [StringLength(50)]
        public string Company { get; set; }
        [StringLength(50)]
        public string Department { get; set; }
        [StringLength(100)]
        public string Position { get; set; }
        [StringLength(50)]
        public string WorkLocation { get; set; }
        public int TariffPlanID { get; set; }
        public bool? MobilePhone { get; set; }
        [Required]
        [StringLength(16)]
        public string CreatedByAccount { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(16)]
        public string DepartmentHeadAccount { get; set; }
        [Required]
        [StringLength(16)]
        public string HRDepartmentHeadAccount { get; set; }
        [StringLength(16)]
        public string ICTDepartmentHeadAccount { get; set; }
        [StringLength(16)]
        public string PerformerAccount { get; set; }
        public int? pid { get; set; }
        public int? requestID { get; set; }
        public virtual InventoryMobilePhone InventoryMobilePhone { get; set; }
        public virtual RequestSimCardAndMobilePhoneTariffPlan RequestSimCardAndMobilePhoneTariffPlan { get; set; }

        public virtual List<RequestSimCardAndMobilePhoneApprovalHistory> RequestSimCardAndMobilePhoneApprovalHistories { get; set; }

        public virtual List<RequestSimCardAndMobilePhoneComment> RequestSimCardAndMobilePhoneComments { get; set; }
    }
}
