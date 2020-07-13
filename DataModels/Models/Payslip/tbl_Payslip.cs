namespace DataModels.Models.Payslip
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Payslip
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string payBadge { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime payMonth { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PayCode { get; set; }

        [StringLength(100)]
        public string PayRemarks { get; set; }

        public double? PayRate { get; set; }

        public double? PayUnit { get; set; }

        public double? PayAmount { get; set; }

        public int? payType { get; set; }

        public int? payDisplay { get; set; }
    }
}
