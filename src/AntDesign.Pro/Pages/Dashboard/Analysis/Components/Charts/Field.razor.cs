using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Analysis.Components.Charts
{
    public partial class Field
    {
        [Parameter]
        public string Label { get; set; }

        [Parameter]
        public string Value { get; set; }
    }
}