namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Site")]
    public partial class Site
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Column("Site")]
        [Required]
        [StringLength(32)]
        public string Site1 { get; set; }

        public virtual List<RequestHelpdesk> RequestHelpdesks { get; set; }

        public virtual List<VideoConferenceCallAlias> VideoConferenceCallAliases { get; set; }
    }
}
