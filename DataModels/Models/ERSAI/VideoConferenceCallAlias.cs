namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class VideoConferenceCallAlias
    {
        public int ID { get; set; }
        [StringLength(100)]
        public string RoomName { get; set; }
        [StringLength(32)]
        public string Alias { get; set; }
    }
}