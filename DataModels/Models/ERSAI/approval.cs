namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        public int id { get; set; }
        public string EmployerBadgeNumber { get; set; }
        public string ApprovalBadgeNumber1 { get; set; }
        public string ApprovalBadgeNumber2 { get; set; }
    }
}