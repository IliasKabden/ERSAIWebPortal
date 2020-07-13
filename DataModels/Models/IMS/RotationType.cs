namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("tb_Rotation")]
    public partial class RotationType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Code { get; set; }
        [StringLength(20)]
        public string Descr { get; set; }
        public short? DayOn { get; set; }
        public short? DayOff { get; set; }
        public byte? HL { get; set; }
        public double? RotHour { get; set; }
        public double? RotDay { get; set; }
        public int? Coeff { get; set; }
        public double? CalHour { get; set; }
        public double? CalHourArr { get; set; }
        public double? HourDay { get; set; }
        public double? CalDaysMonth { get; set; }
        public double? CalDaysYear { get; set; }
        public double? HoursYear { get; set; }
        public double? AveDaysMonth { get; set; }
        public double? AveHoursMonth { get; set; }
        public short? ADayOn { get; set; }
        public short? ADayOff { get; set; }
        public virtual ICollection<Employee> tb_Employee { get; set; }
        public virtual ICollection<Employee> tb_Employee1 { get; set; }
    }
}