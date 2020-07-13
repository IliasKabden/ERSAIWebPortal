namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class InventoryRadio
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        public int CompanyID { get; set; }
        public int ModelID { get; set; }
        public int StatusID { get; set; }
        [Required]
        [StringLength(32)]
        public string SerialNumber { get; set; }
        [Required]
        [StringLength(32)]
        public string AssetNumber { get; set; }
        public int Code { get; set; }
        [StringLength(10)]
        public string OwnerBadge { get; set; }
        [Required]
        [StringLength(12)]
        public string CreatedByAccount { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public string Comment { get; set; }
        public virtual Company Company { get; set; }
        public virtual InventoryRadioModel InventoryRadioModel { get; set; }
        public virtual InventoryStatus InventoryStatus { get; set; }
        public virtual List<RequestRadio> RequestRadios { get; set; }
    }
}
