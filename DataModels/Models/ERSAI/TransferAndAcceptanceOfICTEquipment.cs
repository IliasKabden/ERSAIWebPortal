namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class TransferAndAcceptanceOfICTEquipment
    {
        public int ID { get; set; }
        [StringLength(16)]
        public string BadgeNumber { get; set; }
        [StringLength(20)]
        public string ModifiedByAccount { get; set; }
    }
}