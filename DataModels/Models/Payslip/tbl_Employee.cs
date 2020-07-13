namespace DataModels.Models.Payslip
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Employee
    {
        [Key]
        [Column(Order = 0, TypeName = "smalldatetime")]
        public DateTime EmpTranDate { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string EmpBadge { get; set; }

        [Required]
        [StringLength(80)]
        public string EmpNameEng { get; set; }

        [StringLength(80)]
        public string EmpNameRus { get; set; }

        [StringLength(80)]
        public string EmpNameKaz { get; set; }

        [Required]
        [StringLength(100)]
        public string EmpPosEng { get; set; }

        [StringLength(100)]
        public string EmpPosRus { get; set; }

        [StringLength(100)]
        public string EmpPosKaz { get; set; }

        [Required]
        [StringLength(1)]
        public string EmpEL { get; set; }

        [Required]
        [StringLength(10)]
        public string BussUnit { get; set; }

        [Required]
        [StringLength(80)]
        public string EmpDept { get; set; }

        [StringLength(80)]
        public string EmpOCC { get; set; }

        [Required]
        [StringLength(50)]
        public string EmpWorkLoc { get; set; }

        [Required]
        [StringLength(30)]
        public string EmpContrEng { get; set; }

        [Required]
        [StringLength(30)]
        public string EmpContrRus { get; set; }

        [Required]
        [StringLength(30)]
        public string EmpContrKaz { get; set; }

        public double? EmpBasicSal { get; set; }

        public double? EmpOTRate { get; set; }

        [StringLength(5)]
        public string EmpCurr { get; set; }

        public double? EmpHFund { get; set; }

        public double? EmpYTDVac { get; set; }

        public double? EmpCredit { get; set; }

        public double? EmpDebit { get; set; }

        public double? EmpSalTotal { get; set; }
    }
}
