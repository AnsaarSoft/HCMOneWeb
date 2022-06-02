using HCM.API.Interfaces.MasterData;
using HCM.API.Models;
using HCM.API.Repository.MasterData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string? DBCon = builder.Configuration.GetSection("APIBaseUrl").ToString();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WebHCMOneContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IMstDepartment, MstDepartmentRepo>();
builder.Services.AddScoped<IMstDesignation, MstDesignationRepo>();
builder.Services.AddScoped<IMstLocation, MstLocationRepo>();
builder.Services.AddScoped<IMstPosition, MstPositionRepo>();
builder.Services.AddScoped<IMstGrading, MstGradingRepo>();
builder.Services.AddScoped<IMstBranch, MstBranchRepo>();
builder.Services.AddScoped<IMstCalendar, MstCalendarRepo>();
builder.Services.AddScoped<IMstLeaveCalendar, MstLeaveCalendarRepo>();

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
