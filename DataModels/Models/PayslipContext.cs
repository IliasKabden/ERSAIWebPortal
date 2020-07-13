namespace DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models.Payslip;

    public partial class PayslipContext : DbContext
    {
        public PayslipContext()
            : base("name=PayslipConnectionString")
        {
        }

        public virtual DbSet<tbl_Employee> tbl_Employee { get; set; }
        public virtual DbSet<tbl_MonthDesc> tbl_MonthDesc { get; set; }
        public virtual DbSet<tbl_Payslip> tbl_Payslip { get; set; }
    }
}