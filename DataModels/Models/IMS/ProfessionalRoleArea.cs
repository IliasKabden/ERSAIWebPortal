namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_ProfRoleArea")]
    public partial class ProfessionalRoleArea
    {
        [Key,StringLength(2)]
        public string Code { get; set; }
        [StringLength(40)]
        public string Descr { get; set; }
        public virtual ICollection<ProfessionalRole> Roles { get; set; }
    }
}