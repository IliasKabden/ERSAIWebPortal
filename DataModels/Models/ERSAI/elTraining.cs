namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string TrainingName { get; set; }
        [StringLength(512)]
        public string TrainingDescription { get; set; }
        [StringLength(50)]
        public string DepartmentID { get; set; }
        [StringLength(255)]
        public string TrainerAccount { get; set; }
    }
}