namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        public string Room { get; set; }
        public string BadgeNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? OutDate { get; set; }
        public string Remark { get; set; }
        public virtual List<AccommodationHistory> AccommodationHistories { get; set; }
    }
}