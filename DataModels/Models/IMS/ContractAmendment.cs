namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_Amendment")]
    public partial class ContractAmendment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("RefNo")]
        public int? RefNo { get; set; }
        [Key, Column("BadgeNo", Order = 0), StringLength(10)]
        public string BadgeNo { get; set; }
        [Key, Column("EffDate", Order = 1, TypeName = "date")]
        public DateTime EffDate { get; set; }
        [Key, Column("TypeCode", Order = 2), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? TypeID { get; set; }
        [Key, Column("Remarks", Order = 3), StringLength(100)]
        public string Comments { get; set; }
        [Column("Expiry", TypeName = "date")]
        public DateTime? ExpirationDate { get; set; }
        [StringLength(30), Column("ContrRef")]
        public string Number { get; set; }
        [Column("pFlag")]
        public bool? pFlag { get; set; }
        [Column("OldPost")]
        public int? OldPositionID { get; set; }
        [Column("NewPost")]
        public int? NewPositionID { get; set; }
        [StringLength(15), Column("OldPRole")]
        public string OldProfessionalRoleID { get; set; }
        [StringLength(15), Column("NewPRole")]
        public string NewProfessionalRoleID { get; set; }
        [Column("OldSal")]
        public double? OldSalary { get; set; }
        [Column("NewSal")]
        public double? NewSalary { get; set; }
        [Column("OldOT")]
        public double? OldOvertimeRate { get; set; }
        [Column("NewOT")]
        public double? NewOvertimeRate { get; set; }
        [Column("OldOTLump")]
        public double? OldOvertimeLump { get; set; }
        [Column("NewOTLump")]
        public double? NewOvertimeLump { get; set; }
        [Column("BonusAmt")]
        public double? BonusAmount { get; set; }
        [StringLength(6), Column("OldCREA")]
        public string OldCREA_ID { get; set; }
        [StringLength(6), Column("NewCREA")]
        public string NewCREA_ID { get; set; }
        [Column("OldLevel")]
        public short? OldEmployeeLevelID { get; set; }
        [Column("NewLevel")]
        public short? NewLevelID { get; set; }
        [Column("OldRotation")]
        public int? OldRotationTypeID { get; set; }
        [Column("NewRotation")]
        public int? NewRotationTypeID { get; set; }
        [Column("OldAnnualSal")]
        public double? OldAnnualSalary { get; set; }
        [Column("NewAnnualSal")]
        public double? NewAnnualSalary { get; set; }
        [Column("OldAnnualOT")]
        public double? OldAnnualOvertime { get; set; }
        [Column("NewAnnualOT")]
        public double? NewAnnualOvertime { get; set; }
        [Column("OldAnnualRotAllow")]
        public double? OldAnnualRotationAllowance { get; set; }
        [Column("NewAnnualRotAllow")]
        public double? NewAnnualRotationAllowance { get; set; }
        [Column("OldAnnualOverseasAllow")]
        public double? OldAnnualOverseasAllowance { get; set; }
        [Column("NewAnnualOverseasAllow")]
        public double? NewAnnualOverseasAllowance { get; set; }
        [Column("IFFactor")]
        public double? IFFactor { get; set; }
        [StringLength(10), Column("UserID")]
        public string LastEditorID { get; set; }
        [Column("LastUpdate")]
        public DateTime? LastUpdateTime { get; set; }
        public virtual Employee Employee { get; set; }
    }
}