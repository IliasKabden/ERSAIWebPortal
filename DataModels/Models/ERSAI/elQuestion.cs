namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class elQuestion
    {
        public int ID { get; set; }        [Required]
        [StringLength(1024)]
        public string Question { get; set; }        public int TestID { get; set; }
    }
}
