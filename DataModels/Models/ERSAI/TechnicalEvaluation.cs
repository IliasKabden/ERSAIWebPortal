namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class TechnicalEvaluation
    {
        public int ID { get; set; }
        public string XML { get; set; }
    }
}