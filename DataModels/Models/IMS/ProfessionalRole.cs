namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_ProfRole")]
    public partial class ProfessionalRole
    {
        [Key, StringLength(8)]
        public string Code { get; set; }
        [Required, StringLength(60)]
        public string Descr { get; set; }
        public bool? Status { get; set; }
        [StringLength(2), Column("Area")]
        public string AreaID { get; set; }
        public virtual ProfessionalRoleArea Area { get; set; }
        [StringLength(4), Column("Family")]
        public string FamilyID { get; set; }
        public virtual ProfessionalRoleFamily Family { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}