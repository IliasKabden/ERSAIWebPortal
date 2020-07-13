namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class RequestHelpdeskPriority
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Priority { get; set; }

        public virtual List<RequestHelpdesk> RequestHelpdesks { get; set; }
    }
}
