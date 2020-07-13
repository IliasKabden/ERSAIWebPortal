namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        public int ID { get; set; }
        [StringLength(16)]
        public string AuthorAccount { get; set; }
        [StringLength(255)]
        public string Comment { get; set; }
    }
}