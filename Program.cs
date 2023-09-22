global using Microsoft.EntityFrameworkCore;
global using backend_tpgk.Data;
global using backend_tpgk.Models;
global using backend_tpgk.Services.RoleService;
global using backend_tpgk.Services.StatusService;
global using backend_tpgk.Services.AdresseService;
global using backend_tpgk.Services.AvisService;
global using backend_tpgk.Services.CommandeService;
global using backend_tpgk.Services.CommandeProduitService;
global using backend_tpgk.Services.FabricantService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IAdresseService, AdresseService>();
builder.Services.AddScoped<IAvisService, AvisService>();
builder.Services.AddScoped<ICommandeService, CommandeService>();
builder.Services.AddScoped<ICommandeProduitService, CommandeProduitService>();
builder.Services.AddScoped<IFabricantService, FabricantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
