using Microsoft.EntityFrameworkCore;
using WebChat.Etities;
using WebChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ChattingAppDbContext> (Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddSession();

builder.Services.AddAuthentication("Cookies")
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Account/Login";
        opt.ExpireTimeSpan = TimeSpan.FromHours(2);
        opt.Cookie.HttpOnly = true;

    });

builder.Services.AddSignalR();
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
app.UseSession();
app.UseRouting();

app.UseAuthentication();  //  Đăng nhập   phải nằm trước lệnh Author
app.UseAuthorization();  //   phân quyền

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<ChatHub>("/chat");
app.Run();


//http://localhost/wordpress/wp-login.php