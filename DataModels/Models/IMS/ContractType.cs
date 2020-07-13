namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_ContractType")]
    public partial class ContractType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Code { get; set; }
        [StringLength(30)]
        public string Descr { get; set; }
        [StringLength(30)]
        public string DescrLoc { get; set; }
        [StringLength(30)]
        public string DescrKaz { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
        public virtual ICollection<Employee> tb_Employee1 { get; set; }
    }
}