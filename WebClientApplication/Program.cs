using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Data.EF;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Services.Catalog.Orders;
using Services.Catalog.ProductCategories;
using Services.Catalog.Products;
using Services.Catalog.Users;
using Services.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ShopDbContext>(options =>
            options.UseSqlServer("Server=.;Database=ShopDB;Trusted_Connection=True;"));

builder.Services.AddHttpClient();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 3; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMvc();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(option =>
{
    option.Cookie.Name = "CartSession";
    option.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddControllers();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IStorageService, FileStorageService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IOrderService, OrderService>();



IMvcBuilder build = builder.Services.AddRazorPages();
build.AddRazorRuntimeCompilation();
build.Services.AddMemoryCache();

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

app.UseAuthorization();
app.UseNotyf();
app.MapRazorPages();
app.UseSession();

app.MapControllerRoute(name: "chi-tiet-san-pham",
                pattern: "product-{id}.html",
                defaults: new { controller = "Product", action = "ProductDetail" });

app.MapControllerRoute(name: "them-vao-gio-hang",
                pattern: "AddToCart-{id}.html",
                defaults: new { controller = "Product", action = "AddToCart" });

app.MapControllerRoute(name: "danh-muc-san-pham",
                pattern: "category-{id}.html",
                defaults: new { controller = "Category", action = "ProductInCategory" });

app.MapControllerRoute(name: "dang-nhap-nguoi-dung",
                pattern: "loginuser.html",
                defaults: new { controller = "Login", action = "Index" });
app.MapControllerRoute(name: "Home",
                pattern: "index.html",
                defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
