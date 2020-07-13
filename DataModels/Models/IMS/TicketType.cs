namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_TicketType")]
    public partial class TicketType
    {
        [Key]
        public byte Code { get; set; }
        [StringLength(20)]
        public string Descr { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}