namespace DataModels.Models.Payslip
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_MonthDesc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string MonthNameEng { get; set; }

        [Required]
        [StringLength(20)]
        public string MonthNameRus { get; set; }

        [Required]
        [StringLength(20)]
        public string MonthNameKaz { get; set; }
    }
}
