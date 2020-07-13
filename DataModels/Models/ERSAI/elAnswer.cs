namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class elAnswer
    {
        public int ID { get; set; }        [Required]
        [StringLength(1024)]
        public string Answer { get; set; }        public int QuestionID { get; set; }        public bool isCorrect { get; set; }
    }
}
