using Blazor.FlexGrid.Components.Events;
using Blazor.FlexGrid.Components.Renderers;
using Blazor.FlexGrid.DataSet.Options;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Blazor.FlexGrid.DataSet
{

    /// <summary>
    /// Represents a collection of Items with paging, sorting and inline editation
    /// </summary>
    public interface ITableDataSet : IPageableTableDataSet, ISortableTableDataSet, ISelectableDataSet, IRowEditableDataSet, IGroupableTableDataSet
    {
        GridViewEvents GridViewEvents { get; }

        IColumnsOptions ColumnsOptions { get; set; }

        ISearchOptions SearchOptions { get; set; }

    }
}
