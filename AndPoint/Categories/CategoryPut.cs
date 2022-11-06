using IwantApp.Domain.Products;
using IwantApp.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace IwantApp.AndPoint.Categories;

//atualizar
public class CategoryPut
{


    //rota
    /*
     => ao colocar esse símbolo estamos já setando esse valor
    */
    public static string Template => "/categories/{id:guid}"; //rota do nosso template
    public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
    public static Delegate Handle => Action;


    public static IResult Action([FromRoute] Guid id, CategoryRequest categoryRequest, ApplicationDbContext context )
    {
            //buscando atravez do id 
        var category = context.Categories.Where(c => c.Id == id).FirstOrDefault();

        //emetidno o erro statuso 404/ codigo do usuario esta errado
        if(category == null)
        {
            return Results.NotFound();
        }

        category.Name = categoryRequest.Name;
        category.Active = categoryRequest.Active;

        context.SaveChanges();
         

        return Results.Ok();

    }

}
