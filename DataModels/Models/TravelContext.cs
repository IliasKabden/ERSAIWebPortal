namespace DataModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models.Travel;

    public partial class TravelContext : DbContext
    {
        public TravelContext()
            : base("name=TravelConnectionString")
        {
        }

        public virtual DbSet<LeaveRequest> LeaveRequest { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
