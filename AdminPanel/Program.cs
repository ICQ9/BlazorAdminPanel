using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using AdminPanel;
using AdminPanel.Services;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;


namespace AdminPanel
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://api.stacksandbox.com/") });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5010") });

            builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();

            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

            builder.Services.AddAuthorizationCore();

            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}
