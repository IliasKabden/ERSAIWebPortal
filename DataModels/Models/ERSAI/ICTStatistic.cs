namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class ICTStatistic
    {
        public int ID { get; set; }        [StringLength(50)]
        public string HelpdeskStats { get; set; }        [StringLength(50)]
        public string FacilityStats { get; set; }        [StringLength(50)]
        public string FacilityThirdPartyStats { get; set; }        [StringLength(50)]
        public string SimCardAndMobilePhoneStats { get; set; }
    }
}
