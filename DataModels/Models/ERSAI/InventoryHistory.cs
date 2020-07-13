namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("InventoryHistory")]
    public partial class InventoryHistory
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectID { get; set; }        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemID { get; set; }        [Key]
        [Column(Order = 2)]
        [StringLength(16)]
        public string CreatedByAccount { get; set; }        [Key]
        [Column(Order = 3)]
        public DateTime CreatedDate { get; set; }        [Key]
        [Column(Order = 4)]
        [StringLength(1000)]
        public string Changes { get; set; }
    }
}
