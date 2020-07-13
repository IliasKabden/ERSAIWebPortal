namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class TestAdmin
    {
        public int ID { get; set; }        public int TestID { get; set; }        [Required]
        [StringLength(16)]
        public string AdminAccount { get; set; }        public virtual Test Test { get; set; }
    }
}
