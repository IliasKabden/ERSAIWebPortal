namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class TestHistory
    {
        public int ID { get; set; }
        [StringLength(16)]
        public string AssignedByAccount { get; set; }
        [StringLength(16)]
        public string AssignedToAccount { get; set; }
    }
}