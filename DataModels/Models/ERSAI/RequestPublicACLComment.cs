namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class RequestPublicACLComment
    {
        public int ID { get; set; }
        public int RequestID { get; set; }
        [Required]
        [StringLength(32)]
        public string AuthorAccount { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Required]
        [StringLength(255)]
        public string Comment { get; set; }
    }
}
