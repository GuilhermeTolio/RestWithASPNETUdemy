using GeekShopping.web.Services;
using GeekShopping.web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IProductService, ProductService>(
    c => c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductAPI"]!)
);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = "cookies";
        options.DefaultChallengeScheme = "oidc";
    }).AddCookie("cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = builder.Configuration["ServiceUrls:IdentityServer"];
        options.GetClaimsFromUserInfoEndpoint = true;
        options.ClientId = "geek_shopping";
        options.ClientSecret = "secret";
        options.ResponseType = "code";
        options.ClaimActions.MapJsonKey("role", "role", "role");
        options.ClaimActions.MapJsonKey("sub", "sub", "sub");
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.Scope.Add("geek_shopping");
        options.SaveTokens = true;
    });

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();