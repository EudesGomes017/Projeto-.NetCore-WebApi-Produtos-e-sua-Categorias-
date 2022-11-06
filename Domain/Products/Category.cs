using Flunt.Validations;

namespace IwantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; private set; } // nome tera  100 carecteres   
    public bool Active { get; private set; } 

    public Category(string name, string createdBy, string editedBy)
    {

        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.Now;
        EditedOn = DateTime.Now;

        Validate();

    }

    //metodo resposavel ela validação de todos os dados 
    private void Validate()
    {
        //trabalhando com a notificação dentro do contrutor
        var contract = new Contract<Category>()
            //oq nao pode ser null, nome da propriedade onde ela é obrigatoria
            .IsNotNull(Name, "Name")
            .IsGreaterOrEqualsThan(Name, 3, "Name") // tem que ser igual ou maior que 3 caracteres
            .IsNotNull(CreatedBy, "CreatedBy")
            .IsNotNull(EditedBy, "EditedBy");
        AddNotifications(contract); // esse contrato é resposavel para validar  
    }

    public void EditInfo(string name, bool active)
    {
        Active = active;
        Name = name;

        Validate(); // vai lançar as notificações sim ou nao nas mensagens

    }
}
