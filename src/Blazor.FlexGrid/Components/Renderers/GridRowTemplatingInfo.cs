using Blazor.FlexGrid.Components.Configuration;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blazor.FlexGrid.Components.Renderers
{
    public class GridRowTemplatingInfo<TItem> : GridRowTemplatingInfo
    {
        //public Dictionary<Expression<Func<TItem, object>>, RenderFragment<TItem>> ColumnsRenderers { get; set; }

        public BlazorComponentColumnCollection<TItem> Collection
        {
            get; set;
        }

        public GridRowTemplatingInfo(BlazorComponentColumnCollection<TItem> collection)
        {
            this.Collection = collection;
        }

        public override void AddToCollection(LambdaExpression expression, RenderFragment renderFragment)
        {
            Collection.AddColumnValueRenderFunction((Expression<Func<TItem, object>>)expression, (item) => renderFragment);

        }
    }

    public class GridRowTemplatingInfo
    {

        public virtual void AddToCollection(LambdaExpression expression, RenderFragment renderFragment)
        {

        }

        protected Dictionary<LambdaExpression, RenderFragment> ColumnsRenderers { get; set; }

        public Type ItemType { get; set; }

    }
}
