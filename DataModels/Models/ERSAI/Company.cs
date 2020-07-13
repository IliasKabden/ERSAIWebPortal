namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Company")]
    public partial class Company
    {
        public int ID { get; set; }
        [Required, StringLength(255)]
        public string Company_Name { get; set; }
        [Required, StringLength(255)]
        public string Company_Desc { get; set; }
        [StringLength(50)]
        public string Original_TMS_Code { get; set; }
        public virtual List<InventoryComputer> InventoryComputers { get; set; }
        public virtual List<InventoryIPPhone> InventoryIPPhones { get; set; }
        public virtual List<InventoryMonitor> InventoryMonitors { get; set; }
        public virtual List<InventoryNetworkEquipment> InventoryNetworkEquipments { get; set; }
        public virtual List<InventoryOtherHardware> InventoryOtherHardwares { get; set; }
        public virtual List<InventoryPrinter> InventoryPrinters { get; set; }
        public virtual List<InventoryRadio> InventoryRadios { get; set; }
        public virtual List<InventoryServer> InventoryServers { get; set; }
        public virtual List<InventoryToken> InventoryTokens { get; set; }
    }
}
