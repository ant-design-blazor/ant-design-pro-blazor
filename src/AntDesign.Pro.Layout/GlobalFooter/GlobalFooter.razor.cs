using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Layout
{
    public partial class GlobalFooter
    {
        private const string PrefixCls = "ant-pro";
        private const string BaseClassName = PrefixCls + "-global-footer";

        [Parameter]
        public RenderFragment Copyright { get; set; }

        [Parameter]
        public LinkItem[] Links { get; set; }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add(BaseClassName);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }
    }
}