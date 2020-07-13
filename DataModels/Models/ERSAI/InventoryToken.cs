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
        public string TokenID { get; set; }
        public string OwnerBadge { get; set; }
        [StringLength(32)]
        public string Location { get; set; }
        public DateTime ExpireDate { get; set; }
        [StringLength(16)]
        public string CreatedByAccount { get; set; }
        public string ModifiedByAccount { get; set; }
        public string Remark { get; set; }
        public string pid { get; set; }
    }
}