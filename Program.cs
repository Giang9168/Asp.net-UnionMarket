using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using UnionMarket.Data;
using UnionMarket.Data.Repositories;
using UnionMarket.Service;
using System.IdentityModel.Tokens.Jwt;
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

// Cấu hình CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularClient",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // 👈 URL của Angular
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                    .AllowCredentials();
        });
});

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        RoleClaimType = ClaimTypes.Role,
        ValidIssuer = "yourIssuer",
        ValidAudience = "yourAudience",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mySuperSecretKekhgkkgkkgkkhkghkgkhky12345"))
    };


    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["jwt"];
            return Task.CompletedTask;
        }
    };

});



builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<UnionMarketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UnionMarketContext>();

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();

   

}

app.UseHttpsRedirection();
app.UseCors("AllowAngularClient");
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
