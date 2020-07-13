namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("RequestInfrastructure")]
    public partial class RequestInfrastructure
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int Progress { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(16)]
        public string CreatedByAccount { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(16)]
        public string ICTDepartmentHeadAccount { get; set; }
        public bool IsAuthorizedToTest { get; set; }
        public bool IsAuthorizedToImplement { get; set; }
        public bool IsRejected { get; set; }

        public virtual List<RequestInfrastructureComment> RequestInfrastructureComments { get; set; }
    }
}
