namespace DataModels.Models.IMS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tb_AmendmentCode")]
    public partial class ContractAmendmentType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Code { get; set; }
        [StringLength(50)]
        public string Descr { get; set; }
        public short? IFFactor { get; set; }
    }
}