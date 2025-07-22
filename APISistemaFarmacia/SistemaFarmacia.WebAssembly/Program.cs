using Blazored.SessionStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SistemaFarmacia.WebAssembly;
using SistemaFarmacia.WebAssembly.Servicios.Contrato;
using SistemaFarmacia.WebAssembly.Servicios.Implementacion;
using SistemaFarmacia.WebAssembly.Utilidades;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5019/") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://apifatosamist.us-east-2.elasticbeanstalk.com/") });
                                                                         

builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IVentaService, VentaService>();
builder.Services.AddScoped<IDashBoardService, DashBoardService>();
builder.Services.AddScoped<IPresentacionService, PresentacionService>();
builder.Services.AddScoped<IProdpresentacionService, ProdpresentacionService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProveedorService, ProveedorService>();
builder.Services.AddScoped<ICompraService, CompraService>();
builder.Services.AddScoped<ICotizacionService, CotizacionService>();



builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddAuthorizationCore();

builder.Services.AddMudServices();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();





