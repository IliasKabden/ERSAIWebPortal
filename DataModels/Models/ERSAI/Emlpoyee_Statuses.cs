namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class Emlpoyee_Statuses
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }        [Required]
        [StringLength(50)]
        public string Status_Name { get; set; }
    }
}
