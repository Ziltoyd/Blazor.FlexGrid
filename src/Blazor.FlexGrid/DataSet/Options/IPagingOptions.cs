using System.Collections.Generic;
using System.Linq;

namespace Blazor.FlexGrid.DataSet.Options
{
    public interface IPagingOptions
    {
        int PageSize { get; set; }

        int TotalItemsCount { get; set; }

        int PagesCount { get; }

        int CurrentPage { get; set; }

        bool IsFirstPage { get; }

        bool IsLastPage { get; }

        bool IsPageSizeEditable { get; set; }

        IEnumerable<int> PageSizeOptions { get; set; } 
    }
}
