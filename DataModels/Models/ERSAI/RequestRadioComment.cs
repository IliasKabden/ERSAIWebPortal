namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class RequestRadioComment
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestID { get; set; }        [Key]
        [Column(Order = 1)]
        [StringLength(16)]
        public string AuthorAccount { get; set; }        [Key]
        [Column(Order = 2)]
        public DateTime CreatedDate { get; set; }        [Key]
        [Column(Order = 3)]
        [StringLength(255)]
        public string Comment { get; set; }        public virtual RequestRadio RequestRadio { get; set; }
    }
}
