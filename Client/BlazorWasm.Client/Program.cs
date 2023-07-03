using BlazorWasm.Client.Birthdays;
using BlazorWasm.Client.Posts;
using BlazorWasm.Client.Ui;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services
    .ConfigurePostServices()
    .ConfigureBirthdayServices();

await builder.Build().RunAsync();
