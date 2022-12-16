using BlazorAPI.Responsitories;
using BlazorModel.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CSharp6AssignmentContext>(c => c.UseSqlServer("Server=DESKTOP-QTCBJBH\\SQLEXPRESS;Database=CSharp6Assignment;Trusted_Connection=True;"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    c =>
    {
        c.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWTIssuer"],
            ValidAudience = builder.Configuration["JWTAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSecurity"]))
        };
    }
    );
builder.Services.AddCors(c => c.AddPolicy("cors",
    builder => builder.SetIsOriginAllowed((host) => true).AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()));
builder.Services.AddTransient<IDiemRespositories, DiemRespositorie>();
builder.Services.AddTransient<ITruongResponsitories, TruongRespositories>();
builder.Services.AddTransient<ILopRespositories, LopRespositories>();
builder.Services.AddTransient<IMonHocRespositories, MonHocRespositories>();
builder.Services.AddTransient<INganhResponsitories, NganhRespositories>();
builder.Services.AddTransient<ISinhVienResponsitories, SinhVienRespositories>();
builder.Services.AddTransient<IUserInteraction, UserInteractioncs>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("cors");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();