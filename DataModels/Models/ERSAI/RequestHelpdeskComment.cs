namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class RequestHelpdeskComment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestID { get; set; }        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string AuthorAccount { get; set; }        [Key]
        [Column(Order = 2)]
        public DateTime CreatedDate { get; set; }        [StringLength(260)]
        public string Comment { get; set; }        public int? isOnHoldStatus { get; set; }        [StringLength(260)]
        public string MarkComment { get; set; }        public virtual RequestHelpdesk RequestHelpdesk { get; set; }
    }
}
