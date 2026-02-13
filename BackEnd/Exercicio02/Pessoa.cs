namespace Exercicio02
{
    public class Pessoa
    {
        public string nome;
        public int idade;
      
        public void ExibirDados()
        {
            Console.WriteLine($"Nome:{nome}");
            Console.WriteLine($"Idade:{idade}" );
        }
    }
}