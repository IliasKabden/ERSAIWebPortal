namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("RquestAbsenceHistory")]
    public partial class RquestAbsenceHistory
    {
        public int ID { get; set; }        public int? RequestID { get; set; }        [StringLength(255)]
        public string comment { get; set; }        [StringLength(50)]
        public string CreatedByAccount { get; set; }        public DateTime? CreatedDate { get; set; }
    }
}
