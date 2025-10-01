using CoachFitAI.Web;
using CoachFitAI.Web.Pages.Shared.Web3Components;
using CoachFitAI.Web.Services;
using CoachFitAI.Web.Services.Mock;
using CoachFitAI.Web.State;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


// Explicitly load tokens.json from app root (tokens.json must be copied to output)
try
{
    var http = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
    using var stream = await http.GetStreamAsync("web3config.json");
    builder.Configuration.AddJsonStream(stream);
}
catch (Exception ex)
{
    Console.WriteLine($"Warning: could not load web3config.json: {ex.Message}");
}

builder.Services.AddScoped<IPaymentValidator, EvmPaymentValidator>();


// Bind PaymentConfig from loaded JSON and register singleton
var paymentConfig = new Web3PaymentConfig();
builder.Configuration.GetSection("PaymentConfig").Bind(paymentConfig);
builder.Services.AddSingleton(paymentConfig);

builder.Services.AddScoped<AppState>();
builder.Services.AddScoped<IPaymentService, MockPaymentService>();
builder.Services.AddScoped<IPlanService, MockPlanService>();

await builder.Build().RunAsync();
