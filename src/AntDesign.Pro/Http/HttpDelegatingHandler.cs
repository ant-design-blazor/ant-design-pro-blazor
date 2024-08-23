using Microsoft.AspNetCore.Components;
using System.Net;

namespace AntDesign.Pro.Template
{
    public class HttpDelegatingHandler : DelegatingHandler
    {
        private readonly IMessageService _messageService;
        private readonly NavigationManager _navigationManager;

        public HttpDelegatingHandler(IMessageService messageService, NavigationManager navigationManager)
        {
            _messageService = messageService;
            _navigationManager = navigationManager;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await base.SendAsync(request, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.Unauthorized:
                            _navigationManager.NavigateTo("/user/login");
                            break;
                        case HttpStatusCode.Forbidden:
                            _ = _messageService.Error("Forbidden");
                            break;
                        case HttpStatusCode.BadRequest:
                            _ = _messageService.Error("BadRequest");
                            break;
                        default:
                            _ = _messageService.Error(response.ReasonPhrase);
                            break;
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                _ = _messageService.Error(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
