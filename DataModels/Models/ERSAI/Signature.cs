namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("Signature")]
    public partial class Signature
    {
        public int ID { get; set; }        [Required]
        [StringLength(16)]
        public string Company { get; set; }        [Required]
        [StringLength(16)]
        public string WorkLocation { get; set; }        [Column(TypeName = "ntext")]
        [Required]
        public string Template { get; set; }
    }
}
