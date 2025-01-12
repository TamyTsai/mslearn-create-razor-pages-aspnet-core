using ContosoPizza.Data;
using ContosoPizza.Services;

using Microsoft.EntityFrameworkCore;

// Program.cs 做為 應用程式 的 進入點，並設定 應用程式行為，例如 路由傳送。

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PizzaContext>(options => // 類別 會在 Program.cs (第 10 行) 註冊 相依性插入。
    options.UseSqlite("Data Source=ContosoPizza.db"));
builder.Services.AddScoped<PizzaService>(); // 向容器註冊 PizzaService 類別
// 此程式碼會 向 相依性插入容器 註冊 `PizzaService` 類別。
// `AddScoped` 方法 表示 應該為 每個 HTTP 要求 建立新的 `PizzaService` 物件。
// 現在可將 `PizzaService` 插入任何 Razor 頁面。

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

app.MapRazorPages();

app.Run();
