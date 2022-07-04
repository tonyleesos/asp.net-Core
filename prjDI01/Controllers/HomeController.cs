using Microsoft.AspNetCore.Mvc;
using prjDI01.Models;

namespace prjDI01.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _repository;
        private readonly EmpDbContext _empdbcontext; // 連結empdb資料庫宣告
        public HomeController(IProductRepository repository, EmpDbContext empdbcontext)
        {
            _repository = repository;
            _empdbcontext = empdbcontext;
        }
        //優質電腦圖書(index2)
        IList<Product> GetProducts()
        {
            IList<Product> products = new List<Product>();
            products.Add(new Product { Id = "AEI006600", Classification = "數據處理", Name = "Excel VBA基礎必修課：商管群最佳程式設計訓練教材(適用Excel 2019~2010) ", Price = 500 });
            products.Add(new Product { Id = "AEI007000", Classification = "數據處理", Name = "Excel VBA新手入門-從基礎到爬蟲實例應用(適用Excel 2021/2019/2016)", Price = 450 });
            products.Add(new Product { Id = "AEL021400", Classification = "網頁開發", Name = "跟著實務學習HTML5、CSS3、JavaScript、jQuery、Bootstrap 4增訂版", Price = 500 });
            products.Add(new Product { Id = "AEL022231", Classification = "網頁開發", Name = "跟著實務學習 Bootstrap 4、JavaScript：第一次設計響應式網頁就上手", Price = 540 });
            products.Add(new Product { Id = "AEL022500", Classification = "程式語言", Name = "Java SE 12基礎必修課(適用Java 12~10，涵蓋OCJP與MTA Java國際認證) ", Price = 540 });
            products.Add(new Product { Id = "AEL022600", Classification = "程式語言", Name = "Visual C# 2019基礎必修課(適用2019/2017) ", Price = 530 });
            products.Add(new Product { Id = "AEL022700", Classification = "程式語言", Name = "Visual C# 2019程式設計經典-邁向Azure雲端與AI影像辨識服務 ", Price = 680 });
            products.Add(new Product { Id = "AEL022900", Classification = "網頁開發", Name = "跟著實務學習ASP.NET MVC 5.x-打下前進ASP.NET Core的基礎(使用C#2019) ", Price = 550 });
            products.Add(new Product { Id = "AEL023400", Classification = "數據處理", Name = "跟著阿才學Python - 從基礎到網路爬蟲應用 ", Price = 450 });
            products.Add(new Product { Id = "AEL025100", Classification = "程式語言", Name = "最新Python基礎必修課(含ITS Python國際認證模擬試題) ", Price = 350 });
            return products;
        }
        //學生成績用(index2)
        IList<Student> StudentGradeList()
        {
            IList<Student> students = new List<Student>();
            students.Add(new Student() { Id = "S01", Name = "王小明", Chi = 60, Math = 89, Eng = 74 });
            students.Add(new Student() { Id = "S02", Name = "李小華", Chi = 90, Math = 89, Eng = 54 });
            students.Add(new Student() { Id = "S03", Name = "張小呆", Chi = 70, Math = 29, Eng = 64 });
            students.Add(new Student() { Id = "S04", Name = "蔡小龍", Chi = 37, Math = 49, Eng = 64 });
            students.Add(new Student() { Id = "S05", Name = "周小旬", Chi = 97, Math = 79, Eng = 84 });
            return students;
        }

        public IActionResult Index()
        {
            IList<Product> ? product = _repository.GetAll();
            return View(GetProducts());
        }
        public IActionResult Index2(int id=1)
        {
            // id = 1 遞增 id = 2 遞減           
            IList<Product> ? product = null;
            if(id == 1)
            {
                product = GetProducts().OrderBy(x => x.Price).ToList();
            }
            else if(id == 2)
            {
                product = GetProducts().OrderByDescending(x => x.Price).ToList();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Index2(string keyword)
        {
            // 關鍵字搜尋    
            IList<Product>? product = GetProducts().Where(x=>x.Name.Contains(keyword) || x.Classification.Contains(keyword)).ToList();          
            return View(product);
        }
        public IActionResult StudentGrade()
        {            
            return View(StudentGradeList());
        }
        // 客戶服務
        public IActionResult Services()
        {
            return View();
        }
        // 註冊
        public IActionResult RegisterIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterIndex(Member member)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Show = "會員註冊資訊如下<hr>" +
                    $"帳號:{member.Uid}<br>" +
                    $"帳號:{member.Pwd}<br>" +
                    $"帳號:{member.Name}<br>" +
                    $"帳號:{member.Email}<br>" +
                    $"帳號:{member.Website}<br>" +
                    $"帳號:{member.Salary}<br>";
            }
            return View(member);
        }
        // EmpDB Sql prj
        public IActionResult EmpDbIndex()
        {
            var emps = _empdbcontext.TEmployees.OrderBy(x => x.FEmpId).ToList();
            return View(emps);
        }
    }
}
