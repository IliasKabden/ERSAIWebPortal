namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class AccommodationBuilding
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }        [Required, StringLength(32)]
        public string Building { get; set; }        [StringLength(255)]
        public string Description { get; set; }
        public virtual List<AccommodationRoom> AccommodationRooms { get; set; }
    }
}
