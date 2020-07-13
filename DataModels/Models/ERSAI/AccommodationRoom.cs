namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class AccommodationRoom
    {        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]        public int? ID { get; set; }        [Required, StringLength(32)]
        public string Room { get; set; }        public int BuildingID { get; set; }        public int? TypeID { get; set; }        public int? RoomStatusID { get; set; }        public int? LiveTypeID { get; set; }        [StringLength(10)]
        public string BadgeNumber { get; set; }        [StringLength(32)]
        public string Firstname { get; set; }        [StringLength(32)]
        public string Lastname { get; set; }        public int? NationalityID { get; set; }        [StringLength(50)]
        public string Company { get; set; }        [StringLength(100)]
        public string Position { get; set; }        [Column(TypeName = "date")]
        public DateTime? EntryDate { get; set; }        [Column(TypeName = "date")]
        public DateTime? OutDate { get; set; }        [StringLength(255)]
        public string Remark { get; set; }        public virtual AccommodationBuilding AccommodationBuilding { get; set; }
        public virtual List<AccommodationHistory> AccommodationHistories { get; set; }        public virtual AccommodationLiveType AccommodationLiveType { get; set; }        public virtual AccommodationRoomStatus AccommodationRoomStatus { get; set; }        public virtual AccommodationRoomType AccommodationRoomType { get; set; }        public virtual Nationality Nationality { get; set; }
    }
}
