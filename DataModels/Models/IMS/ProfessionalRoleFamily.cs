namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_RoleFamily")]
    public partial class ProfessionalRoleFamily
    {
        [Key,StringLength(4)]
        public string Code { get; set; }
        [StringLength(40)]
        public string Descr { get; set; }
        public virtual ICollection<ProfessionalRole> Roles { get; set; }
    }
}