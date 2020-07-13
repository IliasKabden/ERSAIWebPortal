namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class ICTOperator
    {
        public int ID { get; set; }        [Required]
        [StringLength(20)]
        public string OperatorAccount { get; set; }        [Required]
        [StringLength(20)]
        public string AssignedByAccount { get; set; }        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
    }
}
