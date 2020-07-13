namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class InventoryMobilePhone
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public int? ModelID { get; set; }
        public int SiteID { get; set; }
        [StringLength(16)]
        public string Number { get; set; }
        [StringLength(30)]
        public string OwnerBadge { get; set; }
        public int? Limit { get; set; }
        public bool International { get; set; }
        public bool Roaming { get; set; }
        [StringLength(50)]
        public string IMEI { get; set; }
        [StringLength(4)]
        public string PIN1 { get; set; }
        [StringLength(4)]
        public string PIN2 { get; set; }
        [StringLength(8)]
        public string PUK1 { get; set; }
        [StringLength(8)]
        public string PUK2 { get; set; }
        [StringLength(32)]
        public string SerialNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime IssueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required, StringLength(12)]
        public string CreatedByAccount { get; set; }
        [StringLength(255)]
        public string Comment { get; set; }
        public virtual List<RequestSimCardAndMobilePhone> RequestSimCardAndMobilePhones { get; set; }
    }
}