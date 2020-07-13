namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class InventoryMonitorModel
    {
        public int ID { get; set; }
        [Required, StringLength(255)]
        public string Model { get; set; }
        public virtual List<InventoryMonitor> InventoryMonitors { get; set; }
    }
}