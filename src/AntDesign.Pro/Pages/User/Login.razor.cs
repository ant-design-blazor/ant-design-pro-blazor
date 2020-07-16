using System.ComponentModel.DataAnnotations;
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

        public void HandleSubmit()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}