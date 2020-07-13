namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class InventorySAPUser
    {
        public int ID { get; set; }        [Required]
        [StringLength(16)]
        public string SAPAccount { get; set; }        [Required]
        [StringLength(10)]
        public string OwnerBadge { get; set; }        public DateTime CreatedDate { get; set; }        [Required]
        [StringLength(12)]
        public string CreatedByAccount { get; set; }
    }
}
