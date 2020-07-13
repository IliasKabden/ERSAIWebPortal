namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("Account")]
    public partial class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }        [Required, StringLength(12)]
        public string AccountName { get; set; }        [StringLength(16)]
        public string EmployeeID { get; set; }        [StringLength(255)]
        public string DisplayName { get; set; }        [StringLength(100)]
        public string Mail { get; set; }        public DateTime? WhenCreated { get; set; }        public DateTime? WhenChanged { get; set; }        public bool Disabled { get; set; }
    }
}
