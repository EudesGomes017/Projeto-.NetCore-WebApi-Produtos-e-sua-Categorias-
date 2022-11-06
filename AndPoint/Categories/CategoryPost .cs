using IwantApp.Domain.Products;
using IwantApp.Infra.Data;

namespace IwantApp.AndPoint.Categories;


public class CategoryPost
{
    //AndPoint Cadastrar categoria


    //rota
    /*
     => ao colocar esse símbolo estamos já setando esse valor
    */
    public static string Template => "/categories"; //rota do nosso template
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;


    public static IResult Action(CategoryRequest categoryRequest, ApplicationDbContext context )
    {
        //validação, respota para campos obirgatorios, exemplo Nmae
        /*  if(string.IsNullOrEmpty(categoryRequest.Name))
          {
              return Results.BadRequest("Name is required");
          }*/


        //salvando Categoria
        var category = new Category(categoryRequest.Name, "Test", "Test");
       

        //Depois que passou pelo construtor podemos validar
        if(!category.IsValid)
        {
            var errors = category.Notifications
               .GroupBy(g => g.Key).ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
            return Results.ValidationProblem(errors);
           

        }

        context.Categories.Add(category);
        context.SaveChanges();


        return Results.Created($"/categories/{category.Id}", category.Id);

    }

}
