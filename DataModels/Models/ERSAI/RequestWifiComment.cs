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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestID { get; set; }
        [Column(Order = 1)]
        [StringLength(12)]
        public string AuthorAccount { get; set; }
        [Column(Order = 2)]
        public DateTime CreatedDate { get; set; }
        [Column(Order = 3)]
        [StringLength(255)]
        public string Comment { get; set; }
    }
}