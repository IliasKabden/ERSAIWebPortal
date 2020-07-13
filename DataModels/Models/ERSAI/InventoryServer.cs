namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        public int ID { get; set; }
        [StringLength(32)]
        public string SerialNumber { get; set; }
        public string AssetNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public string Characteristic { get; set; }
        [StringLength(12)]
        public string CreatedByAccount { get; set; }
        public string Comment { get; set; }
    }
}