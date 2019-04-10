using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Blazor.FlexGrid.DataSet.Options
{
    public interface IColumnsOptions
    {
        IList<PropertyInfo> ExcludedColumns { get; set; }

        bool IsCollapsed { get; set; }

        void ClearExcludedColumnsList();
    }
}
