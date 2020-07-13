namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("AccommodationRoomStatuses")]
    public partial class AccommodationRoomStatus
    {
        public int ID { get; set; }
        [Required, StringLength(32)]
        public string Status { get; set; }
        public virtual List<AccommodationRoom> AccommodationRooms { get; set; }
    }
}