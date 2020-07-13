namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("RequestPublicACLDistributionList")]
    public partial class RequestPublicACLDistributionList
    {
        public int ID { get; set; }        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}
