using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Lists
{
    public partial class TagSelectOption
    {
        [Parameter] public string Value { get; set; }

        [Parameter] public bool Checked { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}