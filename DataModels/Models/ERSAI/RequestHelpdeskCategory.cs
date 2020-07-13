namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class RequestHelpdeskCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        [Required]
        [StringLength(70)]
        public string Category { get; set; }
        public short? Order { get; set; }
        [StringLength(140)]
        public string Short_Label { get; set; }
        public virtual List<RequestHelpdesk> RequestHelpdesks { get; set; }
    }
}