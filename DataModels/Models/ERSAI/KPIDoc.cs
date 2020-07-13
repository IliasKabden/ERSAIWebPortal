namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("KPI_Docs")]
    public partial class KPIDoc
    {
        public int ID { get; set; }
        [Required, StringLength(10), Column("Employer_BadgeNumber"), ForeignKey(nameof(Employee))]
        public string Employee_BadgeNumber { get; set; }
        public virtual Employee Employee { get; set; }
        [Required, StringLength(255)]
        public string Doc_Label { get; set; }
        [Required, StringLength(255)]
        public string Description { get; set; }
        [Required, StringLength(255)]
        public string Doc_Period { get; set; }
        public short Period_Year { get; set; }
        [Required]
        [StringLength(255)]
        public string FileName { get; set; }
        [Required, StringLength(255), Column("File_Path")]
        public string FileDir { get; set; }
    }
}