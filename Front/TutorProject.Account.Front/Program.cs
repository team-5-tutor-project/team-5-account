using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TutorProject.Account.Front;
using TutorProject.Account.Front.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:4000") });
builder.Services.AddTransient<HttpService>();
builder.Services.AddTransient<AuthorizationService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);

await builder.Build().RunAsync();