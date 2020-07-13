namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class RequestWifiDevice
    {
        public int ID { get; set; }        public int RequestID { get; set; }        public int DeviceTypeID { get; set; }        [Required]
        [StringLength(12)]
        public string MACAddress { get; set; }        public virtual RequestWifi RequestWifi { get; set; }        public virtual RequestWifiDeviceType RequestWifiDeviceType { get; set; }
    }
}
