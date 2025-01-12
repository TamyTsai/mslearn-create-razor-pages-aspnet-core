using ContosoPizza.Data;
using ContosoPizza.Models;

// services 資料夾 包含 `PizzaService` 類別，此類別 會 公開 列入 和 新增 披薩的方法。
// `PizzaService` 類別 會使用 `PizzaContext` 類別 來將 披薩 讀取和寫入至資料庫。

namespace ContosoPizza.Services
{
    public class PizzaService
    {
        private readonly PizzaContext _context = default!;

        public PizzaService(PizzaContext context)
        {
            _context = context;
        }
        
        public IList<Pizza> GetPizzas()
        {
            if(_context.Pizzas != null)
            {
                return _context.Pizzas.ToList();
            }
            return new List<Pizza>();
        }

        public void AddPizza(Pizza pizza)
        {
            if (_context.Pizzas != null)
            {
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();
            }
        }

        public void DeletePizza(int id)
        {
            if (_context.Pizzas != null)
            {
                var pizza = _context.Pizzas.Find(id);
                if (pizza != null)
                {
                    _context.Pizzas.Remove(pizza);
                    _context.SaveChanges();
                }
            }            
        } 
    }
}
