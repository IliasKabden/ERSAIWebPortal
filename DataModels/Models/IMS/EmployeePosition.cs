namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_Position")]
    public partial class EmployeePosition
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Code { get; set; }
        [StringLength(100), Column("Descr")]
        public string Name { get; set; }
        [StringLength(100)]
        public string DescrLoc { get; set; }
        [StringLength(100)]
        public string DescrKaz { get; set; }
        [StringLength(2)]
        public string CREA { get; set; }
        [StringLength(1)]
        public string Class { get; set; }
        public virtual CREA tb_CREA { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
        public virtual ICollection<Employee> tb_Employee1 { get; set; }
        public virtual EmployeePositionClass tb_PosClass { get; set; }
    }
}