namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        public int ID { get; set; }
        public string OwnerBadge { get; set; }
        public string Extension { get; set; }
        [StringLength(32)]
        public string SerialNumber { get; set; }
        public string AssetNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        [StringLength(12)]
        public string CreatedByAccount { get; set; }
        public string Comment { get; set; }
    }
}