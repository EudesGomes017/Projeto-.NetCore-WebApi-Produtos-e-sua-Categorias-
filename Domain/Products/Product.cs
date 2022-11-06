namespace IwantApp.Domain.Products;

public class Product : Entity
{
   
    public string Name { get; set; } // nome tera  100 carecteres
    public Guid CategoryId { get; set; } // simbolizar que ela é obirgatorio , a categorai é obrigatoria
    public Category Category { get; set; }
    public string Description { get; set; }
    public bool HasStock { get; set; }
    public bool Action { get; set; } = true;


}
