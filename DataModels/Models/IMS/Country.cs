namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_Nationality")]
    public partial class Country
    {
        [Key, StringLength(3)]
        public string Code { get; set; }
        [StringLength(50)]
        public string Descr { get; set; }
        [StringLength(30)]
        public string DescrLoc { get; set; }
        [StringLength(50), Column("Alias")]
        public string NationalityName { get; set; }
        public short? NatGroup { get; set; }
        [StringLength(5)]
        public string SIDAC { get; set; }
        [StringLength(10)]
        public string BCClass { get; set; }
        [StringLength(10)]
        public string BFClass { get; set; }
        [StringLength(10)]
        public string WCClass { get; set; }
        [StringLength(10)]
        public string MMClass { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
        public virtual ICollection<Employee> tb_Employee1 { get; set; }
        public virtual ICollection<Employee> tb_Employee2 { get; set; }
        public virtual Continent Continent { get; set; }
    }
}