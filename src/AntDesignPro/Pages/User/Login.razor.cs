using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Components;

namespace AntDesignPro
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Captcha { get; set; }
    }

    public partial class Login
    {
        private readonly User _model = new User();
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public void NavLogin()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
