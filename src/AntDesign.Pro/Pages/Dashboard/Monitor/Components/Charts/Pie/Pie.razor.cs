using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Monitor.Components
{
    public partial class Pie
    {
        [Parameter]
        public bool? Animate { get; set; }

        [Parameter]
        public int? LineWidth { get; set; }
    }
}