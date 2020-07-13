using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERSAI_Web_Portal.Models.DTO
{
    public abstract class PaginatedFilterBase<InputItemType>
    {
        public int? ItemsPerPage { get; set; }
        public int? PageNumber { get; set; }

        public PaginatedResults<InputItemType> ApplyPagination(IQueryable<InputItemType> query)
        {
            var pagesCount = (int)Math.Ceiling((double)query.Count() / ItemsPerPage.Value);
            if (pagesCount < PageNumber)
                PageNumber = pagesCount;

            return new PaginatedResults<InputItemType>()
            {
                CurrentPage = PageNumber,
                ResultsCount = query.Count(),
                PagesCount = pagesCount,
                Results = query.Any() ? query.Skip((PageNumber.Value - 1) * ItemsPerPage.Value).Take(ItemsPerPage.Value) : null
            };
        }
        public PaginatedResults<OutputItemType> ApplyPagination<OutputItemType>(IQueryable<InputItemType> query, Func<InputItemType, OutputItemType> itemSelector)
        {
            var origResults = ApplyPagination(query);
            return new PaginatedResults<OutputItemType>()
            {
                CurrentPage = PageNumber,
                ResultsCount = origResults.ResultsCount,
                PagesCount = origResults.PagesCount,
                Results = origResults.Results
                    ?.Select(x => itemSelector(x))
            };
        }
        public abstract IQueryable<InputItemType> Apply(IQueryable<InputItemType> query);
        public virtual void NormalizeValues()
        {
            PageNumber = PageNumber > 0 ? PageNumber : 1;
            ItemsPerPage = ItemsPerPage > 5 ? ItemsPerPage : 5;
        }
    }
}