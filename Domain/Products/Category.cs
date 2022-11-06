using Flunt.Validations;

namespace IwantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; } // nome tera  100 carecteres   
    public bool Active { get; set; } 

    public Category(string name, string createdBy, string editedBy)
    {
        //trabalhando com a notificação dentro do contrutor
        var contract = new Contract<Category>()
             //oq nao pode ser null, nome da propriedade onde ela é obrigatoria
            .IsNotNull(name, "Name")
            .IsGreaterOrEqualsThan(name, 3, "Name") // tem que ser igual ou maior que 3 caracteres
            .IsNotNull(createdBy, "CreatedBy")
            .IsNotNull(editedBy, "EditedBy");
        AddNotifications(contract); // esse contrato é resposavel para validar  

        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;
    }
}
