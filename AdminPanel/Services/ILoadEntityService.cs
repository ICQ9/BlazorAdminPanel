using AdminPanel.Shared.Models;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using static AdminPanel.Pages.Home;

namespace AdminPanel.Services
{
    public interface ILoadEntityService
    {
        Task<IEnumerable<ProductFeedItem>> LoadProductFeedItems(int productFeedId);
        Task<IEnumerable<Advertiser>> LoadAdvertisers();

        Task<IEnumerable<Profile>> LoadProfiles();

        Task<IEnumerable<Shared.Models.Campaign>> LoadCampaigns();

        Task<IEnumerable<ProductFormatResponse>> LoadProductFormat(int campaignId);
        Task<IEnumerable<ProductFeed>> LoadProductFeed(int clientId);
        Task<Advertiser> LoadAdvertiserById(int advId);

        Task<HttpResponseMessage> SaveCreative(SaveCreativeModel creative);
    }

    public class LoadEntityService : ILoadEntityService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        private readonly SemaphoreSlim _semaphore = new(1, 1);
        private bool _isInitialized;

        public LoadEntityService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        private async Task InitializeIfNeededAsync()
        {
            if (_isInitialized)
                return;

            await _semaphore.WaitAsync();
            try
            {
                if (_isInitialized)
                    return;

                var authToken = await _localStorageService.GetItemAsync("access_token");
                if (!string.IsNullOrWhiteSpace(authToken))
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
                    _isInitialized = true;
                }
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private async Task<T?> SafeApiCallAsync<T>(Func<HttpClient, Task<T>> apiCall)
        {
            try
            {
                await InitializeIfNeededAsync();
                return await apiCall(_httpClient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"API error: {ex.Message}");
                return default;
            }
        }

        public async Task<IEnumerable<ProductFeedItem>> LoadProductFeedItems(int productFeedId)
        {
            return await SafeApiCallAsync(async client =>
                await client.GetFromJsonAsync<IEnumerable<ProductFeedItem>>(
                    $"api/teaser-ad-item/rule/item?ids={productFeedId}")
                ?? Enumerable.Empty<ProductFeedItem>());
        }

        public async Task<IEnumerable<Advertiser>> LoadAdvertisers()
        {
            return await SafeApiCallAsync(async client =>
                await client.GetFromJsonAsync<IEnumerable<Advertiser>>("api/advertiser/list")
                ?? Enumerable.Empty<Advertiser>());
        }

        public async Task<IEnumerable<Profile>> LoadProfiles()
        {
            return await SafeApiCallAsync(async client =>
               await client.GetFromJsonAsync<IEnumerable<Profile>>("/api/profile/list") ?? Enumerable.Empty<Profile>());

        }

        public async Task<IEnumerable<Shared.Models.Campaign>> LoadCampaigns()
        {
            return await SafeApiCallAsync(async client =>
               await client.GetFromJsonAsync<IEnumerable<Shared.Models.Campaign>>("/api/campaign/list"));

        }

        public async Task<IEnumerable<ProductFormatResponse>> LoadProductFormat(int campaignId)
        {
            return await SafeApiCallAsync(async client =>
                await client.GetFromJsonAsync<IEnumerable<ProductFormatResponse>>($"/api/campaign/{campaignId}/available-product-formats"));
        }
        public async Task<IEnumerable<ProductFeed>> LoadProductFeed(int clientId)
        {
            return await SafeApiCallAsync(async client =>
                await client.GetFromJsonAsync<List<ProductFeed>>($"api/teaser-feed/list?clientIds={clientId}"));
        }

        public async Task<Advertiser> LoadAdvertiserById(int advId)
        {
            return await SafeApiCallAsync(async client =>
                await client.GetFromJsonAsync<Advertiser>($"api/advertiser/{advId}"));
        }

        public async Task<HttpResponseMessage> SaveCreative(SaveCreativeModel creative)
        {
            return await SafeApiCallAsync(async client =>
                await client.PostAsJsonAsync("/api/creative", creative)); 
        }
    }
}

