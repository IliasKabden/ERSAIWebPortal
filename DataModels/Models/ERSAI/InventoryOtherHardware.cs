namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class InventoryOtherHardware
    {
        public int ID { get; set; }
        public string OwnerBadge { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        public string AssetNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        [StringLength(12)]
        public string CreatedByAccount { get; set; }
        public string Comment { get; set; }
    }
}