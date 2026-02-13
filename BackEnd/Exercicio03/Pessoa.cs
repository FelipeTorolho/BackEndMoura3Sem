namespace Exercicio03
{
    public class Pessoa
    {
        public string Nome;

        public int idade;

        public int Idade
        {
            get { return idade; }
            set
            {
                if (value > 0)
                {
                    idade = value;
                }
                else
                {
                    Console.WriteLine("Idade deve ser maior que zero.");
                }
            }
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Idade: {idade}");
        }
    }
}
