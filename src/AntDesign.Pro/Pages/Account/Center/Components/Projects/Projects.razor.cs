using System.Collections.Generic;
using AntDesign.Pro.Models;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Account.Center
{
    public partial class Projects
    {
        private readonly ListGridType _listGridType = new ListGridType
        {
            Gutter = 24,
            Xs = 24,
            Sm = 12,
            Md = 12,
            Lg = 12,
            Xl = 6,
            Xxl = 6
        };

        [Parameter]
        public IList<ListItemDataType> List { get; set; }
    }
}