namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_DeathInsurance")]
    public partial class DeathInsuranceType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Code { get; set; }
        public double? Amount { get; set; }
        public double? Premium { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}