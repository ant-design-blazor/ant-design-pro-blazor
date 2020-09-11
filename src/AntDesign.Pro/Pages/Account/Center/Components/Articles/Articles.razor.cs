using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}