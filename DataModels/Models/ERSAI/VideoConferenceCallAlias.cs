namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("VideoConferenceCallAliases")]
    public partial class VideoConferenceCallAlias
    {
        public int ID { get; set; }        public int SiteID { get; set; }        [Required]
        [StringLength(100)]
        public string RoomName { get; set; }        [Required]
        [StringLength(32)]
        public string Alias { get; set; }        public virtual Site Site { get; set; }
    }
}
