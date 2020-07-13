namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class RequestWifiGroup
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required]
        [StringLength(15)]
        public string Group { get; set; }
        [Required]
        [StringLength(6)]
        public string LinkName { get; set; }
        public short Order { get; set; }
        [StringLength(50)]
        public string WifiName { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        public virtual List<RequestWifi> RequestWifis { get; set; }
    }
}
