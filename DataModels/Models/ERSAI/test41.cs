namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int task_id { get; set; }
        [StringLength(20)]
        public string descr { get; set; }
    }
}