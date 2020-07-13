namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class RequestFacilityPhoneAccess
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required, StringLength(32)]
        public string PhoneAccess { get; set; }
        public virtual List<RequestFacility> RequestFacilities { get; set; }
    }
}