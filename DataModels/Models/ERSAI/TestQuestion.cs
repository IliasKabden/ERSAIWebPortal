namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class TestQuestion
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        public int TestID { get; set; }
        [Required]
        [StringLength(255)]
        public string Question { get; set; }
        public virtual Test Test { get; set; }

        public virtual List<TestAnswer> TestAnswers { get; set; }
    }
}
