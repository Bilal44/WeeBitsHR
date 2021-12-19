using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text.RegularExpressions;
using WeeBitsHRService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{ 
	options.UseLazyLoadingProxies();
	options.UseSqlServer(connectionString);
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddRoles<IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddRazorPages(options =>
{
	options.Conventions.Add(
		new PageRouteTransformerConvention(
			new SlugifyRazorPages()));

	options.Conventions.AddAreaPageRoute("Identity", "/Account/AccessDenied", "/Access-Denied");
	options.Conventions.AddAreaPageRoute("Identity", "/Account/ConfirmEmail", "/Confirm-Email");
	options.Conventions.AddAreaPageRoute("Identity", "/Account/ConfirmEmailChange", "/Confirm-Email-Change");
	options.Conventions.AddAreaPageRoute("Identity", "/Account/ForgotPassword", "/Forgot-Password");
	options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "/Login");
	options.Conventions.AddAreaPageRoute("Identity", "/Account/LoginWith2fa", "/Login-With-2fa");
	options.Conventions.AddAreaPageRoute("Identity", "/Account/LoginWithRecoveryCode", "/Login-With-Recovery-Code");
	options.Conventions.AddAreaPageRoute("Identity", "/Account/Logout", "/Logout");
	options.Conventions.AddAreaPageRoute("Identity", "/Account/ResendEmailConfirmation", "/Resend-Email-Confirmation");
	options.Conventions.AddAreaPageRoute("Identity", "/Account/ResetPassword", "/Reset-Password");
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

var cultureInfo = new CultureInfo("en-GB");
cultureInfo.NumberFormat.CurrencySymbol = "£";

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");

	endpoints.MapRazorPages();
});

app.Run();


public class SlugifyRazorPages : IOutboundParameterTransformer
{
	public string TransformOutbound(object value)
	{
		if (value == null) { return null; }

		return Regex.Replace(value.ToString(),
			"([a-z0-9])([A-Z0-9])",
			"$1-$2",
			RegexOptions.CultureInvariant,
			TimeSpan.FromMilliseconds(100)).ToLowerInvariant();
	}
}
