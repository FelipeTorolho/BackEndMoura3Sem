namespace Exercicio04
{
    public class Pessoa
    {
        public string Nome { get; set; }

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

        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Idade: {Idade}");
        }
    }
}
