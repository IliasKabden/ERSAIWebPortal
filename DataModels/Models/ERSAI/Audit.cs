namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        public int ID { get; set; }
        [StringLength(255)]
        public string Audit_Name { get; set; }
        [StringLength(255)]
        public string Audit_Description { get; set; }
        public DateTime Audit_StartDate { get; set; }
        public DateTime Audit_EndDate { get; set; }
        [StringLength(255)]
        public string Audit_Data { get; set; }
    }
}