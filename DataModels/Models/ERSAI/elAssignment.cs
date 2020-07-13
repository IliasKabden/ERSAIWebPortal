namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class elAssignment
    {
        public int ID { get; set; }        public int TrainingID { get; set; }        [Required]
        [StringLength(255)]
        public string AssignedTo { get; set; }        public int? StatusID { get; set; }        public int? ResultPercent { get; set; }        public int AttemptsLeft { get; set; }        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }        public DateTime AssignedDate { get; set; }        public int? TestID { get; set; }        public DateTime? CompletedDate { get; set; }        [StringLength(500)]
        public string Author_ID { get; set; }
    }
}
