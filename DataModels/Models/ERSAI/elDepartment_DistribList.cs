namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class elDepartment_DistribList
    {
        public int ID { get; set; }        public int Department_ID { get; set; }        [Required]
        [StringLength(255)]
        public string CC_senders { get; set; }
    }
}
