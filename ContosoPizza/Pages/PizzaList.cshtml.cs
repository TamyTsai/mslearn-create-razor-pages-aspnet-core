using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models; // 這些 陳述式 會 匯入 您 將在頁面中 使用的 Pizza 和 PizzaService 型別
using ContosoPizza.Services;

// PizzaList.cshtml.cs隨附的 PageModel 類別

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        // 建立 名為 _service 的 私人 唯讀 PizzaService
        // 此 變數 會保存 PizzaService 物件的參考
        // readonly 關鍵字 表示 在 建構函式 中 設定 之後，就無法變更 _service 變數的值
        public IList<Pizza> PizzaList { get;set; } = default!;
        // IList<Pizza> 型別表示 PizzaList 屬性 會 保存 Pizza 物件清單
        // 已將 PizzaList 初始化為 default!，以向 編譯器 指出 將在 稍後 初始化，因此 不需要 Null 安全性 Å檢查。

        public PizzaListModel(PizzaService service)
        // 建構函式 會 接受 PizzaService 物件
        // PizzaService 物件是 由 相依性插入 所提供
        {
            _service = service;
        }

        public void OnGet()
        // 從 PizzaService 物件 擷取 披薩清單 的 方法
        {
            PizzaList = _service.GetPizzas(); // 將其儲存在 PizzaList 屬性 中
        }
    }

    
}
