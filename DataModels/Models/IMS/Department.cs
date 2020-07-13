namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_Department")]
    public partial class Department
    {
        [Key, StringLength(6)]
        public string Code { get; set; }
        [StringLength(60)]
        public string Descr { get; set; }
        [StringLength(10)]
        public string HOD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> tb_Employee { get; set; }
    }
}