namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class RquestAbsenceHistory
    {
        public int ID { get; set; }
        public string comment { get; set; }
        public string CreatedByAccount { get; set; }
    }
}