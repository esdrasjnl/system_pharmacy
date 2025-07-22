using QuestPDF.Infrastructure;
using SistemaFarmacia.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.InyectarDependencias(builder.Configuration);

builder.Services.AddCors(options =>
{
options.AddPolicy("NuevaPolitica",app =>
{
    app.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
  });
});
QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("NuevaPolitica");

app.UseRouting();
app.UseStaticFiles();
app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
