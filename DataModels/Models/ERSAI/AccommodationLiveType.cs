namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class AccommodationLiveType
    {
        public int ID { get; set; }
        [Required, StringLength(32)]
        public string Type { get; set; }
        public virtual List<AccommodationRoom> AccommodationRooms { get; set; }
    }
}