namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("TechnicalEvaluation")]
    public partial class TechnicalEvaluation
    {
        public int ID { get; set; }        [Column(TypeName = "xml")]
        public string XML { get; set; }
    }
}
