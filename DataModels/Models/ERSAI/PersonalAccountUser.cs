namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("PayslipUsers")]
    public partial class PersonalAccountUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), StringLength(10), ForeignKey(nameof(ERSAIEmployee))]
        public string Badge { get; set; }
        public virtual Employee ERSAIEmployee { get; set; }
        [Required, StringLength(128), Column("Hashed")]
        public string PasswordHash { get; set; }
        [Required, StringLength(9)]
        public string Hint1 { get; set; }
        [Required, StringLength(9)]
        public string Hint2 { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual List<AppUser> _AppUser { get; set; }
        [NotMapped]
        public AppUser AppUser
        {
            get
            {
                return _AppUser?.FirstOrDefault();
            }
            set
            {
                _AppUser = value != null ? new List<AppUser> { value } : null;
            }
        }

        [NotMapped]
        public Models.IMS.Employee IMSEmployee
        {
            get
            {
                return _contextForIMSEmployeeProperty.Employees.Find(Badge);
            }
        }
        [NotMapped]
        public Account ERSAIAccount
        {
            get
            {
                var context = this.GetDbContextFromEntity() ?? new ERSAIContext();
                return ERSAIEmployee != null ? context.Set<Account>().FirstOrDefault(acc => acc.EmployeeID == ERSAIEmployee.EmployeeID) : null;
            }
        }
        [NotMapped]
        public EmployeesMobilePhone MobPhone
        {
            get
            {
                var context = this.GetDbContextFromEntity() ?? new ERSAIContext();
                return context.Set<EmployeesMobilePhone>().Find(Badge);
            }
        }
        private static IMSContext _contextForIMSEmployeeProperty = new IMSContext();
    }
}