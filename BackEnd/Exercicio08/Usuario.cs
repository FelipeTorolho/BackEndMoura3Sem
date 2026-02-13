namespace Exercicio08
{
    public class Usuario : IAutenticavel
{
    public bool Autenticar(string senha)
    {
        return senha == "123";
    }
}

}
