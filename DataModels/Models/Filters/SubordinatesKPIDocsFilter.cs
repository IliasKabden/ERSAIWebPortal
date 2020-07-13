using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Models.Filters
{
    public class SubordinatesKPIDocsFilter
    {
        public string BadgeNumberLike { get; set; }
        public void ClearEmptyProps()
        {
            if (string.IsNullOrWhiteSpace(BadgeNumberLike))
                BadgeNumberLike = null;
        }
    }
}