namespace DataModels.ERSAI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;    public partial class MonthName
    {
        public int ID { get; set; }        public string MonthNameEng { get; set; }        public string MonthNameRus { get; set; }        public string MonthNameKaz { get; set; }
    }
}
