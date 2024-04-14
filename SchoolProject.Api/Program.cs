using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolProject.Core;
using SchoolProject.Core.Filters;
using SchoolProject.Core.Middlewares;
using SchoolProject.Data.Identity;
using SchoolProject.Infrastructure;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.Seeder;
using SchoolProject.Service;
using Serilog;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region Connection SQL
builder.Services.AddDbContext<AppDbContext>(option =>
{
	option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
});
#endregion

#region Dependency Injections
builder.Services.AddInfrastructureDpendencies()
				.AddServiceDpendencies()
				.AddCoreDependencies()
				.AddServiceRegisteration(builder.Configuration);
#endregion

#region Localization
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt =>
{
	opt.ResourcesPath = "";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	List<CultureInfo> supportedCultures = new List<CultureInfo>
	{
			new CultureInfo("en-US"),
			new CultureInfo("de-DE"),
			new CultureInfo("fr-FR"),
			new CultureInfo("ar-EG")
	};

	options.DefaultRequestCulture = new RequestCulture("en-US");
	options.SupportedCultures = supportedCultures;
	options.SupportedUICultures = supportedCultures;
});

#endregion

#region AllowCORS
var CORS = "_cors";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: CORS,
					  policy =>
					  {
						  policy.AllowAnyHeader();
						  policy.AllowAnyMethod();
						  policy.AllowAnyOrigin();
					  });
});
#endregion

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddTransient<IUrlHelper>(x =>
{
	var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
	var factory = x.GetRequiredService<IUrlHelperFactory>();
	return factory.GetUrlHelper(actionContext);
});

builder.Services.AddTransient<AuthFilter>();
#region Serilog
Log.Logger = new LoggerConfiguration()
			  .ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Services.AddSerilog();
#endregion

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
	var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
	await RoleSeeder.SeedAsync(roleManager);
	await UserSeeder.SeedAsync(userManager);
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsProduction())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

#region Localization Middleware
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseCors(CORS);
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
