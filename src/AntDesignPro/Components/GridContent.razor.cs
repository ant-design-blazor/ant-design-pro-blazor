using Microsoft.AspNetCore.Components;

namespace AntDesignPro.Layout
{
    public partial class GridContent
    {
        private string _prefixCls = "ant-pro";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected void SetClassMap()
        {
        }
    }
}