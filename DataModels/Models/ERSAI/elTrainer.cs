namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class elTrainer
    {
        public int ID { get; set; }        [Required]
        [StringLength(255)]
        public string TrainerAccount { get; set; }        public int? Department_ID { get; set; }
    }
}
