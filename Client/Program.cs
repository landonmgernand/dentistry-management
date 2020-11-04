using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;
using Blazored.Modal;

namespace DentistryManagement.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQyMTY5QDMxMzgyZTMzMmUzMEs0R2RoQ29vMW5Pc0h1VG0vblJjTjZnNCtGTUV4d2ZaclQ3d2VQaVNDbVk9;MzQyMTcwQDMxMzgyZTMzMmUzMGVYQjBxQzVER2FoSHB2azZmdXJQWDFnSElrbUJsYkgxamdiSUI0WFFRSmc9;MzQyMTcxQDMxMzgyZTMzMmUzMEQ4ZlBBa2prcWo2V3BvT3pGa21QSnBXRm50QUdwOVIza0h3NGRTK0wvMTg9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("DentistryManagement.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("DentistryManagement.ServerAPI"));

            builder.Services.AddApiAuthorization();
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddBlazoredModal();

            await builder.Build().RunAsync();
        }
    }
}
