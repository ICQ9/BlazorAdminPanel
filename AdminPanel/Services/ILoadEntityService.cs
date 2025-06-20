﻿using AdminPanel.Shared.Models;
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

        Task<IEnumerable<Campaign>> LoadCampaigns();
        Task<Campaign> LoadCampaignsById(int campaignId);

        Task<IEnumerable<ProductFormatResponse>> LoadProductFormat(int campaignId);
        Task<IEnumerable<ProductFeed>> LoadProductFeed(int clientId);
        Task<Advertiser> LoadAdvertiserById(int advId);
        Task<SaveProfileModel> LoadProfileById(int profileId);

        Task<IEnumerable<CampaignStats>> LoadCampaignStats(string selectedPeriod);

        Task<HttpResponseMessage> SaveCreative(SaveCreativeModel creative);
        
        Task<HttpResponseMessage> SaveTeaserFeedItem(FeedAdItem feedAdItem);
        Task<HttpResponseMessage> SaveProfile(SaveProfileModel profile);
        Task<HttpResponseMessage> SaveUser(CreateUserModel user);

        Task<UserInfo> LoadUserInfo();
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

        public async Task<IEnumerable<Campaign>> LoadCampaigns()
        {
            return await SafeApiCallAsync(async client =>
               await client.GetFromJsonAsync<IEnumerable<Campaign>>("/api/campaign/list"));

        }
        public async Task<Campaign> LoadCampaignsById(int campaignId)
        {
            return await SafeApiCallAsync(async client =>
               await client.GetFromJsonAsync<Campaign>($"/api/campaign/{campaignId}"));

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
        public async Task<SaveProfileModel> LoadProfileById(int profileId)
        {
            return await SafeApiCallAsync(async client =>
                await client.GetFromJsonAsync<SaveProfileModel>($"api/profile/{profileId}/info"));
        }

        public async Task<HttpResponseMessage> SaveCreative(SaveCreativeModel creative)
        {
            return await SafeApiCallAsync(async client =>
                await client.PostAsJsonAsync("/api/creative", creative)); 
        }

        public async Task<HttpResponseMessage> SaveTeaserFeedItem(FeedAdItem feedAdItem)
        {
            return await SafeApiCallAsync(async client =>
                await client.PostAsJsonAsync("api/teaser-ad-item",feedAdItem));
        }

        public async Task<HttpResponseMessage> SaveProfile(SaveProfileModel profile)
        {
            return await SafeApiCallAsync(async client => 
                await client.PostAsJsonAsync("api/profile", profile));
        }
        public async Task<HttpResponseMessage> SaveUser(CreateUserModel user)
        {
            return await SafeApiCallAsync(async client => 
                await client.PostAsJsonAsync("/api/trading-desk/0/user", user));
        }

        public async Task<IEnumerable<CampaignStats>> LoadCampaignStats(string selectedPeriod)
        {

            var (dateFrom, dateTo) = GetDateRangeFromPeriod(selectedPeriod, null, null);

            string dateFromParam = dateFrom.ToString("yyyy-MM-ddTHH:mm:ss");
            string dateToParam = dateTo.ToString("yyyy-MM-ddTHH:mm:ss");

            return await SafeApiCallAsync(async client =>
               await client.GetFromJsonAsync<IEnumerable<CampaignStats>>("api/campaign/stats?dateFrom=2025-05-06T00:00:00&dateTo=2025-05-12T23:59:00&currencyType=Network&timeZoneType=Network"));
        }

        public async Task<UserInfo> LoadUserInfo()
        {
            return await SafeApiCallAsync(async client =>
            await client.GetFromJsonAsync<UserInfo>("api/subscription/user-info"));
        }

        private (DateTime dateFrom, DateTime dateTo) GetDateRangeFromPeriod(string period, DateTime? customDateFrom, DateTime? customDateTo)
        {
            DateTime now = DateTime.Now;
            DateTime dateFrom;
            DateTime dateTo;

            switch (period.ToLower())
            {
                case "yesterday":
                    dateFrom = now.AddDays(-1).Date;
                    dateTo = now.AddDays(-1).Date.AddHours(23).AddMinutes(59);
                    break;

                case "last7days":
                    dateFrom = now.AddDays(-7).Date;
                    dateTo = now.Date.AddHours(23).AddMinutes(59);
                    break;

                case "last30days":
                    dateFrom = now.AddDays(-30).Date;
                    dateTo = now.Date.AddHours(23).AddMinutes(59);
                    break;

                case "thismonth":
                    dateFrom = new DateTime(now.Year, now.Month, 1);
                    dateTo = now.Date.AddHours(23).AddMinutes(59);
                    break;

                case "lastmonth":
                    var lastMonth = now.AddMonths(-1);
                    dateFrom = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                    dateTo = new DateTime(now.Year, now.Month, 1).AddDays(-1).AddHours(23).AddMinutes(59);
                    break;

                case "custom":
                    if (!customDateFrom.HasValue || !customDateTo.HasValue)
                        throw new ArgumentException("Custom date range requires both customDateFrom and customDateTo values.");

                    dateFrom = customDateFrom.Value.Date;
                    dateTo = customDateTo.Value.Date.AddHours(23).AddMinutes(59);
                    break;

                case "today":
                default:
                    dateFrom = now.Date;
                    dateTo = now.Date.AddHours(23).AddMinutes(59);
                    break;
            }

            return (dateFrom, dateTo);
        }
    }
}

