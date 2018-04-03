using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webdev.Models
{
    public class PageableResult<Result>
    {
        public PageableResult(IEnumerable<Result> data, int currentPage,int maxPage)
        {
            Data = data;
            PageInfo = new PageInfo(currentPage, maxPage);
        }

        public IEnumerable<Result> Data { get;}
        public PageInfo PageInfo {get;}
    }

    public class PageInfo
    {
        public PageInfo(int currentPageNumber, int maxPageNumber)
        {
            CurrentPageNumber = currentPageNumber;
            MaxPageNumber = maxPageNumber;
        }

        public int CurrentPageNumber { get; }
        public int MaxPageNumber { get; }
    }
}
