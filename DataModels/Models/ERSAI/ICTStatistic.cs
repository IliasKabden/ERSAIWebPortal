namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        public int ID { get; set; }
        public string HelpdeskStats { get; set; }
        public string FacilityStats { get; set; }
        public string FacilityThirdPartyStats { get; set; }
        public string SimCardAndMobilePhoneStats { get; set; }
    }
}