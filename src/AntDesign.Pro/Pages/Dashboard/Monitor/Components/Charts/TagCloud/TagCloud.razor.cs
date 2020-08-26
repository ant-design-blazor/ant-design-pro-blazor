using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Monitor.Components
{
    public partial class TagCloud
    {
        [Parameter]
        public object[] Data { get; set; }

        [Parameter]
        public int? Height { get; set; }
    }
}