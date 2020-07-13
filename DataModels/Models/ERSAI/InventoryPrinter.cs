namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class InventoryPrinter
    {
        public int ID { get; set; }        public int CompanyID { get; set; }        public int ModelID { get; set; }        public int LocationID { get; set; }        public int StatusID { get; set; }        public int SiteID { get; set; }        [StringLength(50)]
        public string Name { get; set; }        [Required]
        [StringLength(32)]
        public string SerialNumber { get; set; }        [StringLength(32)]
        public string AssetNumber { get; set; }        [StringLength(32)]
        public string PurchaseOrderNumber { get; set; }        [Column(TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }        [StringLength(15)]
        public string IPAddress { get; set; }        [StringLength(10)]
        public string OwnerBadge { get; set; }        public DateTime CreatedDate { get; set; }        [Required]
        [StringLength(12)]
        public string CreatedByAccount { get; set; }        [StringLength(255)]
        public string Comment { get; set; }        public virtual Company Company { get; set; }        public virtual InventoryLocation InventoryLocation { get; set; }        public virtual InventoryLocation InventoryLocation1 { get; set; }        public virtual InventoryLocation InventoryLocation2 { get; set; }        public virtual InventoryPrinterModel InventoryPrinterModel { get; set; }        public virtual InventoryStatus InventoryStatus { get; set; }
    }
}
