using Flunt.Notifications;

namespace IwantApp.Domain;

//classe abstract não pode ser instânciadas só mente erdadar por outro classe
public abstract class Entity : Notifiable<Notification> //  Notifiable<Notification> faz parte do flunte

{    /*criando uma classe abstrata para que seja a classe pai de todas as outras classes*/

    public Entity()
    { /*gerando o id no contrutor toda vez que eu instanciar tanto categoria tanto como produto
       já vamos ter id pronto*/
        Id = Guid.NewGuid();
       
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    /*se preocupar com auditoriao  > */
    public string CreatedBy { get; set; } //quem é o usuario q criaou
    public DateTime CreatedOn { get; set; } //criado quando
    public string EditedBy { get; set; } //por quem foi editato
    public DateTime EditedOn { get; set; } //Data que foi feita

}
