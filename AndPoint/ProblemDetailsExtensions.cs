using Flunt.Notifications;
using System.Runtime.CompilerServices;

namespace IwantApp.AndPoint;

//Criando metodo de extensões
public static class ProblemDetailsExtensions
{
    //vamos extender aparte dessa parte de notifications
    public static Dictionary<string, string[]> ConvertToProblemsDetails(this IReadOnlyCollection<Notification> notifications)
    {
      return  notifications
               .GroupBy(g => g.Key).ToDictionary(g => g.Key, g => g.Select(x => x.Message).ToArray());
    }
}
