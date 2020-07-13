namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class approval
    {
        public int id { get; set; }        [StringLength(20)]
        public string EmployerBadgeNumber { get; set; }        [StringLength(20)]
        public string ApprovalBadgeNumber1 { get; set; }        [StringLength(20)]
        public string ApprovalBadgeNumber2 { get; set; }
    }
}
