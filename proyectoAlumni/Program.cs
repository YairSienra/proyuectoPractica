using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient("useApi", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["ServiceUrl:ApiUrl"]);
});
builder.Services.AddAuthentication(x =>
{
    x.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    x.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
{
    config.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        context.Response.Redirect(builder.Configuration["ServiceUrl:WebUrl"]);
        return Task.CompletedTask;
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}"
    );

app.Run();
