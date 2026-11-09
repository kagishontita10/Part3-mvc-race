using part3_mvc_consume.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// sir's pattern - CHANGE 7053 to your prog_part_2 API port
builder.Services.AddHttpClient<ApiServices_Users>(o => { o.BaseAddress = new Uri("https://localhost:7138"); });
builder.Services.AddHttpClient<ApiServices_events>(o => { o.BaseAddress = new Uri("https://localhost:7138"); });
builder.Services.AddHttpClient<ApiServices_categories>(o => { o.BaseAddress = new Uri("https://localhost:7138"); });
builder.Services.AddHttpClient<ApiServices_Enrolments>(o => { o.BaseAddress = new Uri("https://localhost:7138"); });
builder.Services.AddHttpClient<ApiServices_Results>(o => { o.BaseAddress = new Uri("https://localhost:7138"); });
builder.Services.AddHttpClient<ApiServices_eventRoute>(o => { o.BaseAddress = new Uri("https://localhost:7138"); });

builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
if (!app.Environment.IsDevelopment()) { app.UseExceptionHandler("/Home/Error"); app.UseHsts(); }
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
