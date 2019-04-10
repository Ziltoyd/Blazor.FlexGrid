using System;
using System.Collections.Generic;
using System.Text;
using Blazor.FlexGrid.Components.Configuration;
using Blazor.FlexGrid.Permission;
using Microsoft.AspNetCore.Components;

namespace Blazor.FlexGrid.Components.Renderers
{
    //public class GridRowTemplatesRenderer : GridPartRenderer
    //{
    //    [Inject]
    //    protected BlazorComponentColumnCollection<TItem> Collection { get; set; }


    //    public override bool CanRender(GridRendererContext rendererContext)
    //    {
    //        return true;
    //    }

    //    protected override void BuildRendererTreeInternal(GridRendererContext rendererContext, PermissionContext permissionContext)
    //    {
    //        rendererContext.RendererTreeBuilder.OpenComponent(typeof(CascadingValue<GridRowTemplatingInfo<TItem>>));
    //        rendererContext.AddAttribute("Value", rendererContext.GridRowTemplatingInfo);
    //        rendererContext.AddAttribute("ChildContent", rendererContext.GridRowTemplates);
    //        rendererContext.RendererTreeBuilder.CloseComponent();
    //    }
    //}
}
