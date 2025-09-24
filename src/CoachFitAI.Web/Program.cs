using CoachFitAI.Web;
using CoachFitAI.Web.Services;
using CoachFitAI.Web.Services.Mock;
using CoachFitAI.Web.State;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AppState>();
builder.Services.AddScoped<IPaymentService, MockPaymentService>();
builder.Services.AddScoped<IPlanService, MockPlanService>();

await builder.Build().RunAsync();
