namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("Project")]
    public partial class Project
    {
        public int ID { get; set; }        [Required]
        [StringLength(10)]
        public string CodeName { get; set; }        [Required]
        [StringLength(62)]
        public string ProjectName { get; set; }
    }
}
