namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class RequestSimCardAndMobilePhoneTariffPlan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required]
        [StringLength(32)]
        public string TariffPlan { get; set; }

        public virtual List<RequestSimCardAndMobilePhone> RequestSimCardAndMobilePhones { get; set; }
    }
}
