using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using prjDI01.Models;

var builder = WebApplication.CreateBuilder(args);

// db �s�u�r��
var cnstr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={builder.Environment.ContentRootPath}App_Data\\dbEmp.mdf;Integrated Security=True;Trusted_Connection=True;";

// build mvc
builder.Services.AddMvc();
// �إ߳s�u �]�wmodel
builder.Services.AddDbContext<prjDI01.Models.EmpDbContext>(options=>options.UseSqlServer(cnstr));
builder.Services.AddScoped<IProductRepository, ProductDiscountRepository>();
// �W�[���Ҥ覡�A�ϥ�cookie����
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    // �s��������cookie �u��g��HTTP(S)��w�Ӧs��
    option.Cookie.HttpOnly=true;
    // ���n�J�ɷ|�۰ʾɨ�n�J��
    option.LoginPath = new PathString("/Employee/Login");
    // �ڵ��X�ݸ��|
    option.AccessDeniedPath = new PathString("/Employee/Login");
});
var app = builder.Build();

//// �|������
// �ҥ� cookie ��h�\��
app.UseCookiePolicy();
// �ҥΨ����ѧO
app.UseAuthentication();
// �ҥα��v�\��
app.UseAuthorization();

// �ϥιϤ��귽
app.UseStaticFiles();

app.MapControllerRoute(name: "default", pattern: "{Controller=Employee}/{Action=Index}/{id?}");


app.Run();
