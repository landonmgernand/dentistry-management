using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Blazor;
using Blazored.Modal;
using Tewr.Blazor.FileReader;

namespace DentistryManagement.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzY4NTE3QDMxMzgyZTM0MmUzMGFVa0tWeWtTazFOQ0lTQ3E4YVVISEJZUUQyeUprQ09LdFQzVE50Y2w3bTQ9;MzY4NTE4QDMxMzgyZTM0MmUzMEFXZVdZR1lSVmVVRjJpUzdYK0hlNW1sUnlRRW54aWVOWTg1bnZrNG1sUWc9;MzY4NTE5QDMxMzgyZTM0MmUzMFlDMGRBd0R6Ylc0MXllZkxzMzZ6ZmZ1NmloS3FKMndvR1paSndIREl2a2s9;MzY4NTIwQDMxMzgyZTM0MmUzMGJYMzlLbFQ0NzFqWVBIcnRPZ0V1bHM2Q1cxRHFHM29PRnkxYmMrZDBBQ0k9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("DentistryManagement.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("DentistryManagement.ServerAPI"));
            builder.Services.AddApiAuthorization();
            builder.Services.AddSyncfusionBlazor();
            builder.Services.AddBlazoredModal();
            builder.Services.AddFileReaderService(options => options.UseWasmSharedBuffer = true);
            await builder.Build().RunAsync();
        }
    }
}
