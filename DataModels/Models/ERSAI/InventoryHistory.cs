namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class InventoryHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectID { get; set; }
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemID { get; set; }
        [Column(Order = 2)]
        [StringLength(16)]
        public string CreatedByAccount { get; set; }
        [Column(Order = 3)]
        public DateTime CreatedDate { get; set; }
        [Column(Order = 4)]
        [StringLength(1000)]
        public string Changes { get; set; }
    }
}