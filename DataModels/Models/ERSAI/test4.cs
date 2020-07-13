namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class test4
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int emp_id { get; set; }        [Required]
        [StringLength(20)]
        public string fio { get; set; }        public bool is_enabled { get; set; }
    }
}
