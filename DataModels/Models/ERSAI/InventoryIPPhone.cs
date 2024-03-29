namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class InventoryIPPhone
    {
        public int ID { get; set; }        public int CompanyID { get; set; }        public int ModelID { get; set; }        public int StatusID { get; set; }        public int LocationID { get; set; }        public int SiteID { get; set; }        [StringLength(10)]
        public string OwnerBadge { get; set; }        [StringLength(4)]
        public string Extension { get; set; }        [Required]
        [StringLength(32)]
        public string SerialNumber { get; set; }        [StringLength(32)]
        public string AssetNumber { get; set; }        [StringLength(32)]
        public string PurchaseOrderNumber { get; set; }        [Required]
        [StringLength(12)]
        public string CreatedByAccount { get; set; }        public DateTime CreatedDate { get; set; }        [StringLength(255)]
        public string Comment { get; set; }        public virtual Company Company { get; set; }        public virtual InventoryIPPhoneModel InventoryIPPhoneModel { get; set; }        public virtual InventoryLocation InventoryLocation { get; set; }        public virtual InventoryLocation InventoryLocation1 { get; set; }        public virtual InventoryStatus InventoryStatus { get; set; }
    }
}
