using Business.Abstract;
using Business.Concrete.Managers;
using Business.Helpers;
using Business.ValidationRules;
using Core.Logging.Serilog;
using Core.Utilities.Mail;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Net7ApiTemplate;
using Core.Extensions;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// AddDependencyResolvers islemi
// EFZone
builder.Services.AddTransient<IUserService, UserManager>();
builder.Services.AddTransient<IUserDal, EfUserDal>();
builder.Services.AddSingleton<IZoneDal, EfZoneDal>();
// EFZone
// Services
builder.Services.AddTransient<IAuthService, AuthManager>();
builder.Services.AddTransient<ITokenHelper, JwtHelper>();
builder.Services.AddTransient<IUserTokenService, UserTokenManager>();
builder.Services.AddTransient<IUserTokenDal, EfUserTokenDal>();
builder.Services.AddSingleton<IMailService, MailManager>();
builder.Services.AddSingleton<IZoneService, ZoneManager>();
builder.Services.AddTransient<IFileLogService, FileLogManager>();
// Services

builder.Services.AddDbContext<DataAccess.Concrete.EntityFramework.Context.MyDbContext>(options => options.UseMySQL(builder.Configuration["ConnectionStrings:RosiBMSAPIConStr"]));
builder.Services.AddAutoMapper(typeof(AutoMapperHelper));
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<LoginUserValidator>();
builder.Services.AddSwaggerGen((options) =>
{
    options.SwaggerGeneratorOptions.IgnoreObsoleteActions = true;   
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}

                    }
                });

    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //options.IncludeXmlComments(xmlPath);
});

var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
    };
});

//MediatR
//builder.Services.AppendMediatR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    DataSeeding.Seed(app);
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NET Template API v1"));
}

app.ConfigureCustomExceptionMiddleware();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
