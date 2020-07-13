namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("InventoryStatuses")]
    public partial class InventoryStatus
    {
        public int ID { get; set; }
        [Required, StringLength(50)]
        public string Status { get; set; }
        public virtual List<InventoryComputer> InventoryComputers { get; set; }
        public virtual List<InventoryIPPhone> InventoryIPPhones { get; set; }
        public virtual List<InventoryMonitor> InventoryMonitors { get; set; }
        public virtual List<InventoryNetworkEquipment> InventoryNetworkEquipments { get; set; }
        public virtual List<InventoryPrinter> InventoryPrinters { get; set; }
        public virtual List<InventoryRadio> InventoryRadios { get; set; }
        public virtual List<InventoryServer> InventoryServers { get; set; }
    }
}