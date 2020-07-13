namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("UserPermission")]
    public partial class UserPermission
    {
        public int ID { get; set; }        [Required]
        [StringLength(256)]
        public string Account { get; set; }        public int LevelID { get; set; }
    }
}
