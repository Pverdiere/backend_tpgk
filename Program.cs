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
global using backend_tpgk.Services.PaysService;
global using backend_tpgk.Services.ProduitService;
global using backend_tpgk.Services.RueService;
global using backend_tpgk.Services.UtilisateurService;
global using backend_tpgk.Services.VilleService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using backend_tpgk.Helper;

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
builder.Services.AddScoped<IPaysService, PaysService>();
builder.Services.AddScoped<IProduitService, ProduitService>();
builder.Services.AddScoped<IRueService, RueService>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();
builder.Services.AddScoped<IVilleService, VilleService>();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", builder => 
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddTransient<CustomJwtBearerHandler>();
builder.Services.AddHttpClient();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddScheme<JwtBearerOptions, CustomJwtBearerHandler>(JwtBearerDefaults.AuthenticationScheme, options => { });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
