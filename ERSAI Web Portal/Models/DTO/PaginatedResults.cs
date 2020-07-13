using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERSAI_Web_Portal.Models.DTO
{
    public class PaginatedResults<ItemType>
    {
        public int? CurrentPage { get; set; }
        public int? PagesCount { get; set; }
        public int? ResultsCount { get; set; }
        public IEnumerable<ItemType> Results { get; set; }
    }
}