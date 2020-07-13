namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Test")]
    public partial class Test
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Department { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        [StringLength(32)]
        public string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [StringLength(255)]
        public string VideoURL { get; set; }
        public int PassResult { get; set; }

        public virtual List<TestAdmin> TestAdmins { get; set; }

        public virtual List<TestHistory> TestHistories { get; set; }

        public virtual List<TestHistory_ARC> TestHistory_ARC { get; set; }

        public virtual List<TestQuestion> TestQuestions { get; set; }
    }
}
