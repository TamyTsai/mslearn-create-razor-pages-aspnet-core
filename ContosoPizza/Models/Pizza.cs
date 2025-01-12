using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

// model 資料夾 包含 代表披薩 的 Pizza 類別。
public class Pizza
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    public PizzaSize Size { get; set; }
    public bool IsGlutenFree { get; set; }

    [Range(0.01, 9999.99)]
    public decimal Price { get; set; }
}

public enum PizzaSize { Small, Medium, Large }