using System.Collections.Generic;
using System.Threading.Tasks;
using AntDesign.Pro.Services;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Account.Center
{
    public class CurrentUser
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Signature { get; set; }
        public string Title { get; set; }
        public string Group { get; set; }
        public string Geographic { get; set; }
    }

    public partial class Index
    {
        private CurrentUser currentUser = new CurrentUser
        {
            Avatar = "https://gw.alipayobjects.com/zos/antfincdn/XAosXuNZyF/BiazfanxmamNRoxxVxka.png",
            Name = "Serati Ma",
            Signature = "海纳百川，有容乃大",
            Title = "交互专家",
            Group = "蚂蚁金服－某某某事业群－某某平台部－某某技术部－UED",
            Geographic = "浙江省杭州市"
        };
        private bool inputVisible = false;
        private string inputValue = string.Empty;

        private string[] lstTags = new string[]
        {
            "很有想法的",
            "专注设计",
            "辣~",
            "大长腿",
            "川妹子",
            "海纳百川"
        };

        private IList<ListItemDataType> _fakeList = new List<ListItemDataType>();

        private void ShowInput()
        {

        }

        [Inject] public ProjectService ProjectService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _fakeList = await ProjectService.GetFakeListAsync();
        }
    }
}