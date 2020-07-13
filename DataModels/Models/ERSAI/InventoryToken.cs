namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class InventoryToken
    {
        public int ID { get; set; }        public int CompanyID { get; set; }        [Required]
        [StringLength(16)]
        public string TokenID { get; set; }        public int CreationPlaceID { get; set; }        [StringLength(16)]
        public string OwnerBadge { get; set; }        [Required]
        [StringLength(32)]
        public string Location { get; set; }        [Column(TypeName = "date")]
        public DateTime ExpireDate { get; set; }        public DateTime CreatedDate { get; set; }        [Required]
        [StringLength(16)]
        public string CreatedByAccount { get; set; }        public DateTime? ModifiedDate { get; set; }        [StringLength(100)]
        public string ModifiedByAccount { get; set; }        [StringLength(255)]
        public string Remark { get; set; }        [StringLength(50)]
        public string pid { get; set; }        public virtual Company Company { get; set; }        public virtual InventoryLocation InventoryLocation { get; set; }
    }
}
