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
        // 頁面初始化
        {
            PizzaList = _service.GetPizzas(); // 將其儲存在 PizzaList 屬性 中
        }

        [BindProperty]
        // BindProperty 屬性 會套用到 NewPizza 屬性
        // BindProperty 屬性 是 用來將 NewPizza 屬性 繫結至 Razor 頁面
        // 提出 HTTP POST 要求時，NewPizza 屬性 會以 使用者的 輸入 來填入
        public Pizza NewPizza { get; set; } = default!;
        // 名為 NewPizza 的屬性 會 新增至 PizzaListModel 類別
        // NewPizza 是 Pizza 物件
        // NewPizza 屬性會 初始化 為 default!
        // default! 關鍵字是用來將 NewPizza 屬性 初始化 為 null。 
        // 這可防止編譯器 產生 有關 未初始化之 NewPizza 屬性 的 警告

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null)
            // ModelState.IsValid 屬性 可用來 判斷 使用者 的 輸入 是否 有效
            // 驗證規則 是從 Models/Pizza.cs 中 Pizza 類別上 的 屬性 (例如 Required 和 Range) 推斷而來
            {
                return Page(); // 如果 使用者 的 輸入無效，則會 呼叫 Page 方法 來 重新轉譯 頁面
            }

            _service.AddPizza(NewPizza);
            // NewPizza 屬性 是 用來 將 新的披薩 新增至 _service 物件

            return RedirectToAction("Get");
            // RedirectToAction 方法 是 用來 將 使用者 重新導向 至 Get 頁面 處理常式，
            // 這會 使用 更新的 披薩清單 重新轉譯 頁面
        }

    }

    
}
