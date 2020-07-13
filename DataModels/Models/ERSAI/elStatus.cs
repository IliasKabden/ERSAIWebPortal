namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("elStatuses")]
    public partial class elStatus
    {
        public int ID { get; set; }        [Required]
        [StringLength(50)]
        public string Status { get; set; }
    }
}
