using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class GridContent
    {
        private string _prefixCls = "ant-pro";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        // protected void SetClassMap()
        // {
        //     ClassMapper.Clear().Add($"{_prefixCls}-page-container");
        // }
        //
        // protected override void OnInitialized()
        // {
        //     base.OnInitialized();
        //     SetClassMap();
        // }
    }
}