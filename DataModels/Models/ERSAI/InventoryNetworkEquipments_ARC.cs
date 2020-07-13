namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class InventoryNetworkEquipments_ARC
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyID { get; set; }        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationID { get; set; }        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatusID { get; set; }        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SiteID { get; set; }        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string Name { get; set; }        [Key]
        [Column(Order = 6)]
        [StringLength(100)]
        public string Model { get; set; }        [Key]
        [Column(Order = 7)]
        [StringLength(32)]
        public string PartNumber { get; set; }        [Key]
        [Column(Order = 8)]
        [StringLength(32)]
        public string SerialNumber { get; set; }        [StringLength(32)]
        public string AssetNumber { get; set; }        [StringLength(32)]
        public string PurchaseOrderNumber { get; set; }        [Key]
        [Column(Order = 9)]
        public DateTime CreatedDate { get; set; }        [Key]
        [Column(Order = 10)]
        [StringLength(12)]
        public string CreatedByAccount { get; set; }        [StringLength(255)]
        public string Comment { get; set; }
    }
}
