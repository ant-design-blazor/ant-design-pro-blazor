using AntDesign.Extensions.Localization;
using AntDesign.ProLayout;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using System.Net.Http.Json;

namespace AntDesign.Pro.Template.Layouts
{
    public partial class BasicLayout : LayoutComponentBase, IDisposable
    {
        private MenuDataItem[] _menuData;

        [Inject] private ReuseTabsService TabService { get; set; }
        //#if (full)

        [Inject] private HttpClient HttpClient { get; set; }

        [Inject] private ILocalizationService LocalizationService { get; set; }

        private EventHandler<CultureInfo> _localizationChanged;

        //#endif

        protected override async Task OnInitializedAsync()
        {
#if IsNotFull
            _menuData = new[] {
                new MenuDataItem
                {
                    Path = "/",
                    Name = "welcome",
                    Key = "welcome",
                    Icon = "smile",
                }
            };
#else
            _localizationChanged = (sender, args) => InvokeAsync(StateHasChanged);
            LocalizationService.LanguageChanged += _localizationChanged;
            _menuData = await HttpClient.GetFromJsonAsync<MenuDataItem[]>("data/menu.json");
#endif
        }

        void Reload()
        {
            TabService.ReloadPage();
        }

        public void Dispose()
        {
#if IsNotFull
            
#else
            LocalizationService.LanguageChanged -= _localizationChanged;
#endif
        }

    }
}
