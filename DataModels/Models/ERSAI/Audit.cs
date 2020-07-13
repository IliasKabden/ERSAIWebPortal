namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class Audit
    {
        public int ID { get; set; }        [Required]
        [StringLength(255)]
        public string Audit_Name { get; set; }        [Required]
        [StringLength(255)]
        public string Audit_Description { get; set; }        [Column(TypeName = "smalldatetime")]
        public DateTime Audit_StartDate { get; set; }        [Column(TypeName = "smalldatetime")]
        public DateTime Audit_EndDate { get; set; }        public int Audit_Duration { get; set; }        public int Audit_Type_ID { get; set; }        [Required]
        [StringLength(255)]
        public string Audit_Data { get; set; }        public int Department_ID { get; set; }        public int NCR_OpenStatus { get; set; }        public int? NCR_ClosedStatus { get; set; }        public int? OBS_OpenStatus { get; set; }        public int? OBS_ClosedStatus { get; set; }        public int? SFI_OpenStatus { get; set; }        public int? SFI_ClosedStatus { get; set; }        public virtual Department Department { get; set; }
    }
}
