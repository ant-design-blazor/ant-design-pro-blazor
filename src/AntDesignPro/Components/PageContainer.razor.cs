using Microsoft.AspNetCore.Components;

namespace AntDesignPro.Layout
{
    public partial class PageContainer
    {
        private const string prefixCls = "ant-pro";
        private string prefixedClassName = $"{prefixCls}-page-container";

        [Parameter]
        public RenderFragment ExtraContent { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected void SetClassMap()
        {
        }
    }
}