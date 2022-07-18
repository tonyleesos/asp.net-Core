namespace prjDI01.Models
{
    public class PagedList<T>:List<T>
    {
        // 目前在第幾頁
        public int PageIndex { get; set; }
        // 總頁數
        public int PageTotal { get; set; }
        // PageIndex目前頁數大於 1 表示在第二頁之後HasPrevPage設為true，表示有上一頁
        // PageIndex目前頁數小於 1 時HasPrevPage設為false，表示沒有上一頁
        public bool HasPrevPage => PageIndex > 1;
        // PageIndex目前頁數小於 PageTotal 總頁數時HasNextPage設為true，表示有下一頁
        // PageIndex目前頁數大於等於 PageTotal 總頁數時HasNextPage設為false，表示沒有下一頁
        public bool HasNextPage => PageIndex < PageTotal;

        // 建構式
        public PagedList(IList<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            // 總頁數
            PageTotal = (int)Math.Ceiling(count/(double)pageSize);
            this.AddRange(items);
        }
        /// <summary>
        /// 創建頁數資料
        /// </summary>
        /// <param name="source">資料來源</param>
        /// <param name="pageIndex">現在第幾頁</param>
        /// <param name="pageSiez">一頁顯示幾筆</param>
        /// <returns></returns>
        public static PagedList<T> Create(IList<T> source,int pageIndex,int pageSiez)
        {
            // 取得資料總筆數
            var count = source.Count();
            // 取得第幾頁指定的筆數
            var items = source.Skip((pageIndex - 1) * pageSiez).Take(pageSiez).ToList();
            // 傳回指定筆數得串列
            return new PagedList<T>(items, count, pageIndex, pageSiez);
        }
    }
}
