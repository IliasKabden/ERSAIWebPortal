namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class Signature
    {
        public int ID { get; set; }
        [StringLength(16)]
        public string Company { get; set; }
        [StringLength(16)]
        public string WorkLocation { get; set; }
        [Required]
        public string Template { get; set; }
    }
}