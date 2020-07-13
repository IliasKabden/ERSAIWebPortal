namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class elTraining
    {
        public int ID { get; set; }        [Required]
        [StringLength(255)]
        public string TrainingName { get; set; }        [Required]
        [StringLength(512)]
        public string TrainingDescription { get; set; }        [Required]
        [StringLength(50)]
        public string DepartmentID { get; set; }        [Required]
        [StringLength(255)]
        public string TrainerAccount { get; set; }        public DateTime CreatedDate { get; set; }
    }
}
