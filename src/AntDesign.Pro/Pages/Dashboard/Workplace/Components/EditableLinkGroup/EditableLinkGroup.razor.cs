using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Workplace
{
    public class EditableLink
    {
        public string Title { get; set; }
        public string Href { get; set; }
        public string Id { get; set; }
    }

    public partial class EditableLinkGroup
    {
        [Parameter] public EditableLink[] Links { get; set; }
    }
}