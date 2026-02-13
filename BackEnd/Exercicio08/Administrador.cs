namespace Exercicio08
{
   public class Administrador : IAutenticavel
   {
     public bool Autenticar(string senha)
     {
         return senha == "admin";
     }
   }
}