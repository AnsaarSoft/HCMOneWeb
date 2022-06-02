using HCM.UI;
using HCM.UI.Data.MasterData;
using HCM.UI.Interfaces.MasterData;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
builder.Services.AddScoped<IMstDepartment, MstDepartmentService>();
builder.Services.AddScoped<IMstDesignation, MstDesignationService>();
builder.Services.AddScoped<IMstLocation, MstLocationService>();
builder.Services.AddScoped<IMstPosition, MstPositionService>();
builder.Services.AddScoped<IMstGrading, MstGradingService>();
builder.Services.AddScoped<IMstBranch, MstBranchService>();
builder.Services.AddScoped<IMstCalendar, MstCalendarService>();
builder.Services.AddScoped<IMstLeaveCalendar, MstLeaveCalendarService>();


//Configuration Start

Settings.APIBaseURL = builder.Configuration.GetValue<string>("APIBaseUrl");

//Configuration End

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();