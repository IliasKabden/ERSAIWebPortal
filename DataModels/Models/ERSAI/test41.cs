namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class test41
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int task_id { get; set; }        [Required]
        [StringLength(20)]
        public string descr { get; set; }
    }
}
