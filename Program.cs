using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EventEase;
using EventEase.Models;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<EventService>();
builder.Services.AddScoped<EventEase.Services.SessionService>(); // Update namespace to Services
builder.Services.AddBlazoredLocalStorage(); // Register Blazored.LocalStorage

await builder.Build().RunAsync();
