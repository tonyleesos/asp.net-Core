using Microsoft.EntityFrameworkCore;
using prjDI01.Models;

var builder = WebApplication.CreateBuilder(args);

// db 連線字串
var cnstr = $"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename={builder.Environment.ContentRootPath}App_Data\\dbEmp.mdf;Integrated Security=True;Trusted_Connection=True;";

// build mvc
builder.Services.AddMvc();
// 建立連線
builder.Services.AddDbContext<prjDI01.Models.EmpDbContext>(options=>options.UseSqlServer(cnstr));
builder.Services.AddScoped<IProductRepository, ProductDiscountRepository>();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(name: "default", pattern: "{Controller=Employee}/{Action=Index}/{id?}");

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

app.Run();
