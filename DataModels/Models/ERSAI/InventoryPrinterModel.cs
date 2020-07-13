namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class InventoryPrinterModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required, StringLength(255)]
        public string Model { get; set; }
        public virtual List<InventoryPrinter> InventoryPrinters { get; set; }
    }
}