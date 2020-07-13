namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class PermissionLevel
    {
        public int ID { get; set; }        [Required]
        [StringLength(256)]
        public string LevelDescription { get; set; }
    }
}
