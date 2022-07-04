namespace prjDI01.Models
{
    public class ProductDataSource
    {
        public IList<Product> GetProducts()
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
    }
}
