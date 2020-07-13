namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Nationality")]
    public partial class Nationality
    {
        public int ID { get; set; }
        [Required, StringLength(3)]
        public string Abbreviation { get; set; }
        [Required, StringLength(32)]
        public string Country { get; set; }
        public virtual List<AccommodationHistory> AccommodationHistories { get; set; }
        public virtual List<AccommodationRoom> AccommodationRooms { get; set; }
    }
}