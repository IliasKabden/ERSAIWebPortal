namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Holiday")]
    public partial class Holiday
    {
        public int ID { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }
}