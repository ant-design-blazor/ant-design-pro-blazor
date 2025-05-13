using AntDesign.Pro.Template.Models;
using AntDesign.Pro.Template.Services;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using AntDesign.Extensions.Localization;
using System.Globalization;
using System;
using AntDesign;

namespace AntDesign.Pro.Template.Components
{
    public partial class RightContent
    {
        private CurrentUser _currentUser = new CurrentUser();
        private NoticeIconData[] _notifications = { };
        private NoticeIconData[] _messages = { };
        private NoticeIconData[] _events = { };
        private int _count = 0;

        private List<AutoCompleteDataItem<string>> DefaultOptions { get; set; } = new List<AutoCompleteDataItem<string>>
        {
            new AutoCompleteDataItem<string>
            {
                Label = "umi ui",
                Value = "umi ui"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Table",
                Value = "Pro Table"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Layout",
                Value = "Pro Layout"
            }
        };

        private AvatarMenuItem[] AvatarMenuItems =>
            [
                new() { Key = "center", IconType = "user", Option = L["menu.account.center"]},
                new() { Key = "setting", IconType = "setting", Option = L["menu.account.settings"] },
                new() { IsDivider = true },
                new() { Key = "logout", IconType = "logout", Option = L["menu.account.logout"]}
            ];

        [Inject] protected NavigationManager NavigationManager { get; set; }

        [Inject] protected IUserService UserService { get; set; }
        [Inject] protected IProjectService ProjectService { get; set; }
        [Inject] protected MessageService MessageService { get; set; }

        [Inject] private IStringLocalizer<I18n> L { get; set; }
        [Inject] private ILocalizationService LocalizationService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            SetClassMap();
            _currentUser = await UserService.GetCurrentUserAsync();
            var notices = await ProjectService.GetNoticesAsync();
            _notifications = notices.Where(x => x.Type == "notification").Cast<NoticeIconData>().ToArray();
            _messages = notices.Where(x => x.Type == "message").Cast<NoticeIconData>().ToArray();
            _events = notices.Where(x => x.Type == "event").Cast<NoticeIconData>().ToArray();
            _count = notices.Length;
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add("right");
        }

        public void HandleSelectUser(MenuItem item)
        {
            switch (item.Key)
            {
                case "center":
                    NavigationManager.NavigateTo("/account/center");
                    break;
                case "setting":
                    NavigationManager.NavigateTo("/account/settings");
                    break;
                case "logout":
                    NavigationManager.NavigateTo("/user/login");
                    break;
            }
        }

        public void HandleSelectLang(MenuItem item)
        {
            LocalizationService.SetLanguage(CultureInfo.GetCultureInfo(item.Key));
        }

        public async Task HandleClear(string key)
        {
            switch (key)
            {
                case "notification":
                    _notifications = new NoticeIconData[] { };
                    break;
                case "message":
                    _messages = new NoticeIconData[] { };
                    break;
                case "event":
                    _events = new NoticeIconData[] { };
                    break;
            }
            MessageService.Success($"清空了{key}");
        }

        public async Task HandleViewMore(string key)
        {
            MessageService.Info("Click on view more");
        }
    }
}