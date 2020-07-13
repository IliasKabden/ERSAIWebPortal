namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class TestAnswer
    {
        public int ID { get; set; }        public int QuestionID { get; set; }        [Required]
        [StringLength(255)]
        public string Answer { get; set; }        public bool IsRight { get; set; }        public virtual TestQuestion TestQuestion { get; set; }
    }
}
