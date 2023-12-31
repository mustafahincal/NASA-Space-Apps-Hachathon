using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Teapot.Business;
using Teapot.Business.Concrete.AI;
using Teapot.Business.Hubs;
using Teapot.Core.Utilities.Security.Encryption;
using Teapot.Core.Utilities.Security.JWT;
using Teapot.DataAccess.Contexts;
using Teapot.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Teapot418DbContext>(opt => opt
                    .UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                    .UseSnakeCaseNamingConvention()
                    .EnableSensitiveDataLogging());

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey),
            ClockSkew = TimeSpan.Zero
        };
    });
builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
                      builder =>
                      {
                          builder.SetIsOriginAllowed(_ => true)
                                 .AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowCredentials();

                      });
});

builder.Services.AddHttpContextAccessor();
builder.Services.RegisterBusinessServices();
//var serviceProvider = builder.Services.BuildServiceProvider();
//var service = serviceProvider.GetRequiredService<IAIService>();
//service.WriteToDatabase().GetAwaiter();
builder.Services.AddSignalR();

var app = builder.Build();
app.InitializeDatabase();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapHub<ChatHub>("/chatHub");
app.MapControllers();
app.UseCors("_myAllowSpecificOrigins");
app.Run();
