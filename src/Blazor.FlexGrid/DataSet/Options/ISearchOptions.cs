using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Blazor.FlexGrid.DataSet.Options
{
    public interface ISearchOptions
    {
        string Keyword { get; set; }

        IList<PropertyInfo> SearchableProperties { get; set; } 

        LambdaExpression SearchLambda { get;  }

        IQueryable<T> QuickSearchFilter<T>(IQueryable<T> queryable);
    }
}
