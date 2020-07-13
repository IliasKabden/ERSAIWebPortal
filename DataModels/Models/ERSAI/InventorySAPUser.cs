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
        public string SAPAccount { get; set; }
        [StringLength(10)]
        public string OwnerBadge { get; set; }
        [StringLength(12)]
        public string CreatedByAccount { get; set; }
    }
}