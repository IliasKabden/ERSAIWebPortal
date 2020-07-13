namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_WorkLocation")]
    public partial class WorkLocation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Code { get; set; }
        [Required, StringLength(50)]
        public string Descr { get; set; }
        public byte? WGroup { get; set; }
        [StringLength(8)]
        public string WArea { get; set; }
        [StringLength(150)]
        public string Address { get; set; }
        [StringLength(150)]
        public string AddressLoc { get; set; }
        [StringLength(150)]
        public string AddressKaz { get; set; }
        [StringLength(6)]
        public string SIDAC { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        [Column("ProjType")]
        public short? ProjectTypeID { get; set; }
        public virtual ProjectType ProjectType { get; set; }
    }
}