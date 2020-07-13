namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("TestHistory")]
    public partial class TestHistory
    {
        public int ID { get; set; }        public int TestID { get; set; }        [Required]
        [StringLength(16)]
        public string AssignedByAccount { get; set; }        [Required]
        [StringLength(16)]
        public string AssignedToAccount { get; set; }        public DateTime? AssignedDate { get; set; }        public int? Result { get; set; }        public DateTime? PassedDate { get; set; }        public virtual Test Test { get; set; }
    }
}
