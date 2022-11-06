using IwantApp.Domain.Products;
using IwantApp.Infra.Data;

namespace IwantApp.AndPoint.Categories;

//Obtendo todas as categorias
public class CategoryGetAll
{
    //AndPoint Cadastrar categoria


    //rota
    /*
     => ao colocar esse símbolo estamos já setando esse valor
    */
    public static string Template => "/categories"; //rota do nosso template
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;


    public static IResult Action( ApplicationDbContext context ) //injetando o dbContext para buscar todas as categorias
    {

        //salvando Categoria
        var categories = context.Categories.ToList();
        var response = categories.Select(c => new CategoryResponse {Id = c.Id,  Name = c.Name, Active = c.Active});
        


        return Results.Ok(response); 

    }

}
