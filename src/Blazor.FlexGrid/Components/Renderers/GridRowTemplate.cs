using Blazor.FlexGrid.Components.Configuration;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Blazor.FlexGrid.Components.Renderers
{


     public class GridRowTemplate<TItem> : ComponentBase
     {


            [Inject]
            protected BlazorComponentColumnCollection<TItem> Collection { get; set; }

            [Parameter]
            protected Expression<Func<TItem, object>> Path { get; set; }

            [Parameter]
            protected RenderFragment<TItem> ChildContent { get; set; }

            [CascadingParameter]
            protected GridRowTemplatingInfo GridRowTemplatingInfo { get; set; }

            protected override void OnInit()
            {
                base.OnInit();
            }

            protected override void OnParametersSet()
            {
                base.OnParametersSet();

                //var gridRowTempaltingInfo = (GridRowTemplatingInfo<TItem>)GridRowTemplatingInfo;

                //if (gridRowTemplatingInfo == null)
                //    return;

                //if (gridRowTemplatingInfo.ItemType != null)
                //{
                //    var param = Expression.Parameter(GridRowTemplatingInfo.ItemType);

                    Collection.AddColumnValueRenderFunction<object>(Path, ChildContent);
                //}

            }

     }
    
}
