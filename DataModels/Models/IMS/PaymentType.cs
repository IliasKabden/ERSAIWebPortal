namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_PayType")]
    public partial class PaymentType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Code { get; set; }
        [StringLength(20)]
        public string Descr { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
    }
}