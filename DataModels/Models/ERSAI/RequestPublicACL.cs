namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public partial class RequestPublicACL
    {
        public int ID { get; set; }
        public string RequestorAccount { get; set; }
        public string CreatedByAccount { get; set; }
        public string Folder { get; set; }
        public string FtpInternalLink { get; set; }
        public string FtpExternalLink { get; set; }
        public string FtpUsername { get; set; }
        public string FtpPassword { get; set; }
        public string OperatorAccount { get; set; }
        public string MyDepartmentHeadAccount { get; set; }
        public string PerformerAccount { get; set; }
        public string Comment { get; set; }
        public string Description { get; set; }
        public string AreaName { get; set; }
        public string Extension { get; set; }
        public string Emails { get; set; }
    }
}