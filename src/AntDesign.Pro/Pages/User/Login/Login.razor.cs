using System.Threading.Tasks;
using AntDesign.Pro.Template.Models;
using AntDesign.Pro.Template.Services;
using Microsoft.AspNetCore.Components;
using AntDesign;
using System;

namespace AntDesign.Pro.Template.Pages.User {
  public partial class Login {
    private readonly LoginParamsType _model = new LoginParamsType();

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public IAccountService AccountService { get; set; }

    [Inject] public MessageService Message { get; set; }
        [Inject] IAuthenticationService AuthenticationService { get; set; }
        public void HandleSubmit() {
            //if (_model.UserName == "admin" && _model.Password == "ant.design") {
            //  NavigationManager.NavigateTo("/");
            //  return;
            //}

            //if (_model.UserName == "user" && _model.Password == "ant.design") NavigationManager.NavigateTo("/");
            try
            {
                AuthenticationService.SignInAsync(_model.UserName, _model.Password);
                NavigationManager.NavigateTo("/", true);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    public async Task GetCaptcha() {
      var captcha = await AccountService.GetCaptchaAsync(_model.Mobile);
      await Message.Success($"Verification code validated successfully! The verification code is: {captcha}");
    }
  }
}