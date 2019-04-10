using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Blazor.FlexGrid.DataSet;
using Blazor.FlexGrid.Permission;
using Microsoft.AspNetCore.Components;

namespace Blazor.FlexGrid.Components.Renderers
{
    public class GridColumnSelectorRenderer : GridPartRenderer
    {
        public string _placeholderToggler = "Select columns";
        private string _placeholderCheckAll = "Select all columns";

        protected bool IsCollapsed { get; set; }
            

        public override bool CanRender(GridRendererContext rendererContext)
        {
            return rendererContext.TableDataSet.HasItems();
        }

        protected override void BuildRendererTreeInternal(GridRendererContext rendererContext, PermissionContext permissionContext)
        {
            
            IsCollapsed = rendererContext.TableDataSet.ColumnsOptions.IsCollapsed;

            if (IsCollapsed)
                RenderColumnSelectorToggler(rendererContext);
            else
            {
                rendererContext.OpenElement(HtmlTagNames.Table, IsCollapsed ? "table-column-selector-collapsed" : "table-column-selector");
                rendererContext.OpenElement(HtmlTagNames.TableHead);
                rendererContext.OpenElement(HtmlTagNames.TableHeadCell);
                RenderColumnSelectorToggler(rendererContext);
                rendererContext.CloseElement();
                rendererContext.CloseElement();
                rendererContext.OpenElement(HtmlTagNames.TableBody);

                bool allColumnsDisplayed = rendererContext.TableDataSet.ColumnsOptions.ExcludedColumns.Count == 0;
                RenderColumnSelectorRow(rendererContext,
                        isChecked: allColumnsDisplayed,
                        isDisabled: false,
                        onCheckboxChange: (UIChangeEventArgs e) =>
                        {
                            rendererContext.TableDataSet.ColumnsOptions.ClearExcludedColumnsList();
                            rendererContext.RequestRerenderNotification?.Invoke();
                        },
                        text: _placeholderCheckAll,
                        rowClass: !allColumnsDisplayed
                                ? "table-column-selector-checkallrow"
                                : "table-column-selector-checkallrow column-selector-collapsed");
                

                foreach (var column in rendererContext.GridItemDisplayableProperties)
                {
                    bool isColumnDisplayed = !rendererContext.TableDataSet.ColumnsOptions.ExcludedColumns.Contains(column);
                    bool isCheckboxDisabled = isColumnDisplayed && rendererContext.GridItemProperties.Count() == 1;

                    rendererContext.ActualColumnName = column.Name;
                    var displayedColumnName = rendererContext.ActualColumnConfiguration?.Caption ?? column.Name;


                    RenderColumnSelectorRow(rendererContext,
                        isChecked: isColumnDisplayed,
                        isDisabled: isCheckboxDisabled,
                        onCheckboxChange: (UIChangeEventArgs e) =>
                        {
                            if (rendererContext.TableDataSet.ColumnsOptions.ExcludedColumns.Contains(column))
                                rendererContext.TableDataSet.ColumnsOptions.ExcludedColumns.Remove(column);
                            else
                                rendererContext.TableDataSet.ColumnsOptions.ExcludedColumns.Add(column);
                            rendererContext.RequestRerenderNotification?.Invoke();
                        },
                        text: displayedColumnName,
                        rowClass: string.Empty);

                }
                rendererContext.CloseElement();

                rendererContext.CloseElement();
            }
            
        }

        private void RenderColumnSelectorRow(GridRendererContext rendererContext, bool isChecked, bool isDisabled, 
            Action<UIChangeEventArgs> onCheckboxChange, string text, string rowClass)
        {

            rendererContext.OpenElement(HtmlTagNames.TableRow, rowClass);
            rendererContext.OpenElement(HtmlTagNames.TableColumn);
            rendererContext.OpenElement(HtmlTagNames.Input);
            rendererContext.AddAttribute(HtmlAttributes.Type, "checkbox");
            rendererContext.AddAttribute(HtmlAttributes.Checked, isChecked);
            rendererContext.AddAttribute(HtmlAttributes.Disabled, isDisabled);
            rendererContext.AddOnChangeEvent(() =>
                BindMethods.GetEventHandlerValue((UIChangeEventArgs e) => onCheckboxChange(e)));

            rendererContext.CloseElement();
            rendererContext.OpenElement(HtmlTagNames.Span);
            rendererContext.AddContent(text);
            rendererContext.CloseElement();
            rendererContext.CloseElement();
            rendererContext.CloseElement();
        }

        private void RenderColumnSelectorToggler(GridRendererContext rendererContext)
        {
            

            rendererContext.OpenElement(HtmlTagNames.Button, IsCollapsed ? "button-column-selector-collapsed" : "button-column-selector");
            rendererContext.AddOnClickEvent(() =>
            BindMethods.GetEventHandlerValue((UIMouseEventArgs e) =>
            {
                rendererContext.TableDataSet.ColumnsOptions.IsCollapsed = !rendererContext.TableDataSet.ColumnsOptions.IsCollapsed;
                rendererContext.RequestRerenderNotification?.Invoke();
            }));

            
            rendererContext.OpenElement(HtmlTagNames.I, !IsCollapsed ? "fas fa-angle-down" : "fas fa-angle-right");
            rendererContext.CloseElement();

            rendererContext.OpenElement(HtmlTagNames.Span);
            rendererContext.AddContent(_placeholderToggler);
            rendererContext.CloseElement();

            rendererContext.CloseElement();
        }
    }
}
