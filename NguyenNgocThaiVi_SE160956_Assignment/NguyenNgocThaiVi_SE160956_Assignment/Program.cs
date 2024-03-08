using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects;
using NguyenNgocThaiVi_SE160956_Assignment.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                      });
});
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddRepositoryServices(builder.Configuration);
/*builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    options.AddPolicy("Admin", policy => policy
        .Combine(options.DefaultPolicy)
        .RequireRole("Admin")
        .Build());
    options.AddPolicy("Customer", policy => policy
       .Combine(options.DefaultPolicy)
        .RequireRole("Customer")
       .Build());
});*/
// Add services to the container.
// Adding Authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme/*options =>
    {
      *//*  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    *//*}*/)
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            // Xác nhận rằng khóa ký của người phát hành (Issuer) là hợp lệ.
            ValidateIssuerSigningKey = true,
            // ValidateIssuer, ValidateAudience: Xác nhận rằng Issuer và Audience của token là hợp lệ.
            ValidateIssuer = true,
            ValidateAudience = true,
            // Xác nhận thời gian sống của Token
            ValidateLifetime = true,
            // ClockSkew: Điều chỉnh đồng hồ để chấp nhận token với một khoảng độ lệch thời gian nhất định.
            ClockSkew = TimeSpan.Zero,
            // ValidIssuer, ValidAudience: Các giá trị hợp lệ cho Issuer và Audience.
            ValidIssuer = configuration["JwtSettings:Issuer"],
            ValidAudience = configuration["JwtSettings:Audience"],
            // Khóa ký để kiểm tra chữ ký của token.
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!))
        };
    });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Config JWT for swagger
builder.Services.ConfigureSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JwtSettings",
        In = ParameterLocation.Header,
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
             {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Name = "Bearer",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http, // Thay thế SecuritySchemeType.ApiKey
                Scheme = "Bearer" // Định dạng "Bearer"
             },
             new string[] {}
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(/*c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        // Thêm nút Authorize trong Swagger UI
        c.OAuthUseBasicAuthenticationWithAccessCodeGrant();
        c.OAuthAppName("Your API - Swagger UI");
        c.OAuthAdditionalQueryStringParams(new Dictionary<string, string>
                    {
                        { "access_token", "your-jwt-token" }
                    });
    }*/);
}
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
