namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        public int ID { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Model { get; set; }
        [StringLength(32)]
        public string PartNumber { get; set; }
        [StringLength(32)]
        public string SerialNumber { get; set; }
        public string AssetNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        [StringLength(12)]
        public string CreatedByAccount { get; set; }
        public string Comment { get; set; }
    }
}