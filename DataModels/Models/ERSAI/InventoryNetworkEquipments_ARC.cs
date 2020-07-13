namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyID { get; set; }
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationID { get; set; }
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatusID { get; set; }
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SiteID { get; set; }
        [Column(Order = 5)]
        [StringLength(100)]
        public string Name { get; set; }
        [Column(Order = 6)]
        [StringLength(100)]
        public string Model { get; set; }
        [Column(Order = 7)]
        [StringLength(32)]
        public string PartNumber { get; set; }
        [Column(Order = 8)]
        [StringLength(32)]
        public string SerialNumber { get; set; }
        public string AssetNumber { get; set; }
        public string PurchaseOrderNumber { get; set; }
        [Column(Order = 9)]
        public DateTime CreatedDate { get; set; }
        [Column(Order = 10)]
        [StringLength(12)]
        public string CreatedByAccount { get; set; }
        public string Comment { get; set; }
    }
}