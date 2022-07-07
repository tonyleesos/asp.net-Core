using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using prjDI01.Models;

var builder = WebApplication.CreateBuilder(args);

// db 連線字串
var cnstr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={builder.Environment.ContentRootPath}App_Data\\dbEmp.mdf;Integrated Security=True;Trusted_Connection=True;";

// build mvc
builder.Services.AddMvc();
// 建立連線 設定model
builder.Services.AddDbContext<prjDI01.Models.EmpDbContext>(options=>options.UseSqlServer(cnstr));
builder.Services.AddScoped<IProductRepository, ProductDiscountRepository>();
// 增加驗證方式，使用cookie驗證
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    // 瀏覽器限制cookie 只能經由HTTP(S)協定來存取
    option.Cookie.HttpOnly=true;
    // 未登入時會自動導到登入頁
    option.LoginPath = new PathString("/Employee/Login");
    // 拒絕訪問路徑
    option.AccessDeniedPath = new PathString("/Employee/Login");
});
var app = builder.Build();

//// 會員驗證
// 啟用 cookie 原則功能
app.UseCookiePolicy();
// 啟用身分識別
app.UseAuthentication();
// 啟用授權功能
app.UseAuthorization();

// 使用圖片資源
app.UseStaticFiles();

app.MapControllerRoute(name: "default", pattern: "{Controller=Employee}/{Action=Index}/{id?}");


app.Run();
