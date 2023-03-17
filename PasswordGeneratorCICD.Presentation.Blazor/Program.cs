using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using PasswordGeneratorCICD.Application;
using PasswordGeneratorCICD.Application.Dtos;
using PasswordGeneratorCICD.Application.Services.Interfaces;
using PasswordGeneratorCICD.Presentation.Blazor;
using PasswordGeneratorCICD.Presentation.Blazor.Services.Mappers;
using PasswordGeneratorCICD.Presentation.Blazor.ViewModels;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
IConfiguration configuration = builder.Configuration;
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("", client =>
{
    client.BaseAddress = new Uri(configuration["ApiBaseAddress"], UriKind.Absolute);
});
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

builder.Services.AddApplicationServices();
builder.Services.AddScoped<IMapper<PasswordOptionsViewModel, PasswordOptionsDto>, PasswordOptionsViewModelToPasswordOptionsDtoMapper>();

await builder.Build().RunAsync();
