namespace DataModels.Models.Travel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Users")]
    public partial class Users
    {
        public int id { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }

        [Required, StringLength(50)]
        public string Alias { get; set; }

        public short Level { get; set; }

        [Required, StringLength(50)]
        public string Salutation { get; set; }

        [Required, StringLength(50)]
        public string Description { get; set; }

        [Required, StringLength(50)]
        public string DeptCode { get; set; }

        [Required, StringLength(10)]
        public string Email { get; set; }

        public bool HRUser { get; set; }

        [Required, StringLength(100)]
        public string Account { get; set; }

        [Required, StringLength(1)]
        public string EL { get; set; }

        public bool ApprvMgr { get; set; }

        public bool? CanApprove { get; set; }

        public bool? Supplementary { get; set; }

        public bool? VerifierLocal { get; set; }

        public bool? VerifierExpat { get; set; }

        public bool? ApproverLocal { get; set; }

        public bool? ApproverExpat { get; set; }

        public bool? PayrollLocal { get; set; }

        public bool? PayrollExpat { get; set; }

        public bool? TravelLocal { get; set; }

        public int WorkLocation { get; set; }

        [Required, StringLength(50)]
        public string SuppID { get; set; }

        [Required, StringLength(50)]
        public string SupervisorID { get; set; }

        public short ApproveLevel { get; set; }

        public bool? AreaPersonnel { get; set; }

        public bool? AreaManager { get; set; }

        [Required, StringLength(50)]
        public string Company { get; set; }

        public short PasswordTry { get; set; }

        public bool? Locked { get; set; }

        public int ApproverMatrix { get; set; }

        public bool? DualApprover { get; set; }

        public int? Position { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? LastUpdate { get; set; }
    }
}