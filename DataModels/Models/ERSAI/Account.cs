namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class Account
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }
        public string AccountName { get; set; }
        public string EmployeeID { get; set; }
        public string DisplayName { get; set; }
        public string Mail { get; set; }
    }
}