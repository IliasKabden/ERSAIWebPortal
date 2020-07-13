namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class Project
    {
        public int ID { get; set; }
        [StringLength(10)]
        public string CodeName { get; set; }
        [StringLength(62)]
        public string ProjectName { get; set; }
    }
}