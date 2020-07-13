namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_Relationship")]
    public partial class RelationshipType
    {
        [Key]
        public byte Code { get; set; }
        [Required, StringLength(30)]
        public string Descr { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
    }
}