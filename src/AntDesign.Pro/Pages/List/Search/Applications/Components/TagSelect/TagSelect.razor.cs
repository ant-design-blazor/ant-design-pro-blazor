using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Lists
{
    public partial class TagSelect
    {
        private bool _expand = false;
        [Parameter] public bool Expandable { get; set; }

        [Parameter] public bool HideCheckAll { get; set; }

        [Parameter] public string SelectAllText { get; set; } = "全部";

        [Parameter] public string CollapseText { get; set; } = "收起";

        [Parameter] public string ExpandText { get; set; } = "展开";

        [Parameter] public string Value { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            SetClassMap();
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add("tagSelect")
                .If("hasExpandTag", () => Expandable)
                .If("expanded", () => _expand);
        }

        private void HandleExpand()
        {

        }
    }
}