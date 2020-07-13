namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }
        [Column(Order = 1)]
        [StringLength(50)]
        public string RequestType { get; set; }
    }
}