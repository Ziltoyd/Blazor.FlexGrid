using Blazor.FlexGrid.Components.Configuration;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Blazor.FlexGrid.DataSet.Options
{
    public class ColumnsOptions : IColumnsOptions
    {
        public IList<PropertyInfo> ExcludedColumns { get; set; } = new List<PropertyInfo>();

        public bool IsCollapsed { get; set; } = true;

        public void ClearExcludedColumnsList()
        {
            ExcludedColumns = new List<PropertyInfo>();
        }
    }
}
