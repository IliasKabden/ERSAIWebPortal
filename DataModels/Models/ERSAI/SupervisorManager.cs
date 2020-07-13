namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("SupervisorManager")]
    public partial class SupervisorManager
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Company { get; set; }
        [StringLength(100)]
        public string Department { get; set; }
        [Required, StringLength(10), ForeignKey(nameof(Employee))]
        public string BadgeNumber { get; set; }
        public virtual Employee Employee { get; set; }
        [StringLength(16)]
        public string Username { get; set; }
        [Required, StringLength(20)]
        public string CreatedByAccount { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool AccessToApprove { get; set; }
        public int? ActingManagerID { get; set; }
    }
}