using AntDesign.Pro.Pages.Account.Center;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AntDesign.Pro.Services
{
    public class NoticeType
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string UpdatedAt { get; set; }
        public string Member { get; set; }
        public string Href { get; set; }
        public string MemberLink { get; set; }
    }

    public class ActivityUser
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
    }

    public class ActivityGroup
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }

    public class ActivityProject
    {
        public string Name { get; set; }
        public string Link { get; set; }
    }

    public class ActivitiesType
    {
        public string Id { get; set; }
        public string UpdatedAt { get; set; }
        public ActivityUser User { get; set; }
        public ActivityGroup Group { get; set; }
        public ActivityProject Project { get; set; }
        public string Template { get; set; }
    }

    public class ProjectService
    {
        private readonly HttpClient _httpClient;

        public ProjectService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NoticeType[]> GetProjectNoticeAsync()
        {
            return await _httpClient.GetFromJsonAsync<NoticeType[]>("data/notice.json");
        }

        public async Task<ActivitiesType[]> GetActivitiesAsync()
        {
            return await _httpClient.GetFromJsonAsync<ActivitiesType[]>("data/activities.json");
        }

        public async Task<ListItemDataType[]> GetFakeListAsync()
        {
            return await _httpClient.GetFromJsonAsync<ListItemDataType[]>("data/fake_list.json");
        }
    }
}