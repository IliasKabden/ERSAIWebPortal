namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("EmployeesMobilePhones")]
    public partial class EmployeesMobilePhone
    {
        [Key, StringLength(10), ForeignKey(nameof(Employee))]
        public string BadgeNumber { get; set; }
        public virtual Employee Employee { get; set; }
        [StringLength(20)]
        public string Num1 { get; set; }
        [StringLength(20)]
        public string Num2 { get; set; }
        [StringLength(20)]
        public string Num3 { get; set; }
        [StringLength(15)]
        public string Primary_MobilePhone { get; set; }
    }
}