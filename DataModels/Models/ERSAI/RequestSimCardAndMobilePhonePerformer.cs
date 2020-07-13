namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class RequestSimCardAndMobilePhonePerformer
    {
        public int ID { get; set; }        [Required]
        [StringLength(16)]
        public string AccountName { get; set; }        [Required]
        [StringLength(10)]
        public string Company { get; set; }
    }
}
