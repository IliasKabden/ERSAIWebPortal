namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("TransferAndAcceptanceOfICTEquipment")]
    public partial class TransferAndAcceptanceOfICTEquipment
    {
        public int ID { get; set; }        [Required]
        [StringLength(16)]
        public string BadgeNumber { get; set; }        public bool? Form017 { get; set; }        public bool? Form004 { get; set; }        public DateTime ModifiedDate { get; set; }        [Required]
        [StringLength(20)]
        public string ModifiedByAccount { get; set; }
    }
}
