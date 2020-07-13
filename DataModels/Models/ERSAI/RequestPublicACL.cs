namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    [Table("RequestPublicACL")]
    public partial class RequestPublicACL
    {
        public int ID { get; set; }        public int RequestType { get; set; }        [StringLength(32)]
        public string RequestorAccount { get; set; }        [StringLength(32)]
        public string CreatedByAccount { get; set; }        [StringLength(256)]
        public string Folder { get; set; }        public int? AccessID { get; set; }        public int? DistributionListID { get; set; }        [StringLength(50)]
        public string FtpInternalLink { get; set; }        [StringLength(50)]
        public string FtpExternalLink { get; set; }        public bool? FtpIsExternal { get; set; }        [StringLength(32)]
        public string FtpUsername { get; set; }        [StringLength(16)]
        public string FtpPassword { get; set; }        public DateTime? FtpExpiredDate { get; set; }        [StringLength(50)]
        public string OperatorAccount { get; set; }        [StringLength(50)]
        public string MyDepartmentHeadAccount { get; set; }        [StringLength(50)]
        public string PerformerAccount { get; set; }        public int? OperatorStatusID { get; set; }        public int? MyDepartmentHeadStatusID { get; set; }        public int? PerformerStatusID { get; set; }        [StringLength(2048)]
        public string Comment { get; set; }        public DateTime? CreatedDate { get; set; }        public DateTime? OperatoredDate { get; set; }        public DateTime? MyDepartmentHeadedDate { get; set; }        public DateTime? PerformeredDate { get; set; }        [StringLength(2048)]
        public string Description { get; set; }        [StringLength(128)]
        public string AreaName { get; set; }        [StringLength(50)]
        public string Extension { get; set; }        [StringLength(255)]
        public string Emails { get; set; }
    }
}
