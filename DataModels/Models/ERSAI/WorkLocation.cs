namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class WorkLocation
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string WorkLocation_Name { get; set; }
    }
}