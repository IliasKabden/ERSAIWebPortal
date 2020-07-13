namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_Bank")]
    public partial class Bank
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Code { get; set; }
        [StringLength(80)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(20)]
        public string SWIFT { get; set; }
        [StringLength(20)]
        public string BankCode { get; set; }
        [StringLength(20)]
        public string BranchCode { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
