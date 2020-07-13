namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class InventoryComputerModel
    {
        public int ID { get; set; }
        [Required, StringLength(255)]
        public string Model { get; set; }
        public int? Is_Laptop { get; set; }
        public virtual List<InventoryComputer> InventoryComputers { get; set; }
    }
}