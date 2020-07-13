namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class InventoryLocation
    {
        public int ID { get; set; }
        [Required, StringLength(50)]
        public string Location { get; set; }
        public virtual List<InventoryComputer> InventoryComputers { get; set; }
        public virtual List<InventoryComputer> InventoryComputers1 { get; set; }
        public virtual List<InventoryIPPhone> InventoryIPPhones { get; set; }
        public virtual List<InventoryIPPhone> InventoryIPPhones1 { get; set; }
        public virtual List<InventoryMonitor> InventoryMonitors { get; set; }
        public virtual List<InventoryMonitor> InventoryMonitors1 { get; set; }
        public virtual List<InventoryNetworkEquipment> InventoryNetworkEquipments { get; set; }
        public virtual List<InventoryNetworkEquipment> InventoryNetworkEquipments1 { get; set; }
        public virtual List<InventoryPrinter> InventoryPrinters { get; set; }
        public virtual List<InventoryPrinter> InventoryPrinters1 { get; set; }
        public virtual List<InventoryPrinter> InventoryPrinters2 { get; set; }
        public virtual List<InventoryServer> InventoryServers { get; set; }
        public virtual List<InventoryServer> InventoryServers1 { get; set; }
        public virtual List<InventoryToken> InventoryTokens { get; set; }
    }
}
