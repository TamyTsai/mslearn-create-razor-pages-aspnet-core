using Microsoft.EntityFrameworkCore;

// 資料檔案夾 包含 代表 資料庫內容 的 `PizzaContext` 類別。
// 它繼承自 Entity Framework Core 中的 `DbContext` 類別。
// Entity Framework Core 是一種 物件關聯式對應程式 (ORM)，可讓 您 更輕鬆地 使用 資料庫。

namespace ContosoPizza.Data
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {
        }
        public DbSet<ContosoPizza.Models.Pizza>? Pizzas { get; set; }
    }
}
