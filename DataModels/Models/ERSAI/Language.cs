namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class Language
    {
        public int ID { get; set; }
        [Column("Language"), Required, StringLength(255)]
        public string Language1 { get; set; }
        [StringLength(20)]
        public string Code { get; set; }
        public int? Sort_Num { get; set; }
    }
}