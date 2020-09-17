using System.Collections.Generic;
using System.Threading.Tasks;
using AntDesign.Pro.Models;
using AntDesign.Pro.Services;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Lists
{
    public partial class Applications
    {
        private readonly ListGridType _listGridType = new ListGridType
        {
            Gutter = 24,
            Column = 4
        };

        private readonly ListFormModel _model = new ListFormModel();
        private IList<string> _selectCategories = new List<string>();

        private IList<ListItemDataType> _fakeList = new List<ListItemDataType>();


        [Inject] public IProjectService ProjectService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _fakeList = await ProjectService.GetFakeListAsync(8);
        }
    }
}