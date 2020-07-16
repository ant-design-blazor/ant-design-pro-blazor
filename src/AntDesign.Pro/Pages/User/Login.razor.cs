using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Mobile { get; set; }

        public string Captcha { get; set; }

        public bool AutoLogin { get; set; } = true;

        public string LoginType { get; set; }
    }

    public partial class Login
    {
        private readonly LoginModel _model = new LoginModel();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILocalStorageService LocalStorageService { get; set; }

        public async Task HandleSubmit()
        {
            if (_model.UserName == "admin" && _model.Password == "ant.design")
            {
                await LocalStorageService.SetItemAsync("token", _model.UserName);
                NavigationManager.NavigateTo("/");
                return;
            }

            if (_model.UserName == "user" && _model.Password == "ant.design")
            {
                await LocalStorageService.SetItemAsync("token", _model.UserName);
                NavigationManager.NavigateTo("/");
                return;
            }

            await LocalStorageService.RemoveItemAsync("token");
        }
    }
}