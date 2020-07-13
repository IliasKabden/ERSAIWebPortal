namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class elTest
    {
        public int ID { get; set; }        [Required]
        [StringLength(255)]
        public string TestName { get; set; }        public int TestDuration { get; set; }        public int TrainingID { get; set; }        public int LanguageID { get; set; }        public int NumberOfQuestions { get; set; }        public int NumberOfAnswers { get; set; }
    }
}
