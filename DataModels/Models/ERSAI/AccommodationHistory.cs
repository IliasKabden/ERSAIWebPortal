namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("AccommodationHistory")]
    public partial class AccommodationHistory
    {
        public int ID { get; set; }        public int RoomID { get; set; }        [StringLength(32)]
        public string Firstname { get; set; }        [StringLength(32)]
        public string Lastname { get; set; }        public int? NationalityID { get; set; }        [StringLength(50)]
        public string Company { get; set; }        [Column(TypeName = "date")]
        public DateTime? EntryDate { get; set; }        [Column(TypeName = "date")]
        public DateTime? OutDate { get; set; }        public DateTime CreatedDate { get; set; }        [Required, StringLength(16)]
        public string CreatedByAccount { get; set; }        public virtual AccommodationRoom AccommodationRoom { get; set; }        public virtual Nationality Nationality { get; set; }
    }
}
