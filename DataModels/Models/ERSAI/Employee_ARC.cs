namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string BadgeNumber { get; set; }
        public string EmployeeID { get; set; }
        [Column(Order = 1)]
        [StringLength(32)]
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        [Column(Order = 2)]
        [StringLength(32)]
        public string Lastname { get; set; }
        [Column(Order = 3)]
        [StringLength(10)]
        public string Company { get; set; }
        public string Department { get; set; }
        public string DepartmentDescription { get; set; }
        public string Section { get; set; }
        [Column(Order = 4)]
        [StringLength(100)]
        public string Position { get; set; }
        public string CostCenter { get; set; }
        [Column(Order = 5)]
        [StringLength(50)]
        public string WorkLocation { get; set; }
        public DateTime? ReleaseDate { get; set; }
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Status { get; set; }
        public string Category { get; set; }
        public string TipoTerzi { get; set; }
        public string TipoTerziDescription { get; set; }
        public string Project { get; set; }
        public string ProfessionalRole { get; set; }
        public DateTime? ContractDate { get; set; }
        public string LeaveReason { get; set; }
        public string SupervisorBadgeNumber { get; set; }
        public string ManagerBadgeNumber { get; set; }
        public string Nationality { get; set; }
        public string Group { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Vendor { get; set; }
        [Column(Order = 7)]
        public DateTime InsertedDate { get; set; }
        public string AssignedProject { get; set; }
        public string ApprovalManager_BadgeNumber { get; set; }
        public string Phone_extension { get; set; }
    }
}