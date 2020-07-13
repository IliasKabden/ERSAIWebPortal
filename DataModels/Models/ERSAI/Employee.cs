namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Employee")]
    public partial class Employee
    {
        [Key, StringLength(10)]
        public string BadgeNumber { get; set; }
        [StringLength(15)]
        public string EmployeeID { get; set; }
        [Required, StringLength(32)]
        public string Firstname { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{Firstname} {Middlename} {Lastname}".Replace("  ", " ");
            }
        }

        public virtual EmployeesMobilePhone PhoneNumberEntity { get; set; }

        [StringLength(32)]
        public string Middlename { get; set; }
        [Required]
        [StringLength(32)]
        public string Lastname { get; set; }
        [Required]
        [StringLength(10)]
        public string Company { get; set; }
        [StringLength(32)]
        public string Department { get; set; }
        [StringLength(100)]
        public string DepartmentDescription { get; set; }
        [StringLength(30)]
        public string Section { get; set; }
        [Required]
        [StringLength(100)]
        public string Position { get; set; }
        [StringLength(6)]
        public string CostCenter { get; set; }
        [Required]
        [StringLength(50)]
        public string WorkLocation { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }
        public int Status { get; set; }
        [StringLength(1)]
        public string Category { get; set; }
        [StringLength(5)]
        public string TipoTerzi { get; set; }
        [StringLength(30)]
        public string TipoTerziDescription { get; set; }
        [StringLength(8)]
        public string Project { get; set; }
        [StringLength(6)]
        public string ProfessionalRole { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ContractDate { get; set; }
        [StringLength(50)]
        public string LeaveReason { get; set; }
        [StringLength(10)]
        public string SupervisorBadgeNumber { get; set; }
        [StringLength(10)]
        public string ManagerBadgeNumber { get; set; }
        [StringLength(5)]
        public string Nationality { get; set; }
        [StringLength(3)]
        public string Group { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [StringLength(7)]
        public string Vendor { get; set; }
        public byte? IsActual { get; set; }
        public DateTime InsertedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [StringLength(100)]
        public string AssignedProject { get; set; }
        public int? Company_ID { get; set; }
        [StringLength(20)]
        public string ApprovalManager_BadgeNumber { get; set; }
        [StringLength(20)]
        public string Phone_extension { get; set; }
        [StringLength(20)]
        public string ApprovalB2BManager_BadgeNumber { get; set; }
    }
}