namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class RequestInfrastructureComment
    {
        public int ID { get; set; }        public int RequestID { get; set; }        [Required]
        [StringLength(16)]
        public string AuthorAccount { get; set; }        public DateTime CreatedDate { get; set; }        [Required]
        [StringLength(255)]
        public string Comment { get; set; }        public virtual RequestInfrastructure RequestInfrastructure { get; set; }
    }
}
