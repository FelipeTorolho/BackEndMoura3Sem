namespace Exercicio06
{
    
public class Pessoa
{
    public string Nome { get; set; }

    private int idade;

    public int Idade
    {
        get { return idade; }
        set
        {
            if (value > 0)
                idade = value;
            else
                Console.WriteLine("Idade deve ser maior que zero.");
        }
    }

    public Pessoa(string nome, int idade)
    {
        Nome = nome;
        Idade = idade;
    }

    public void Apresentar()
    {
        Console.WriteLine($"Olá, meu nome é {Nome}.");
    }

    public void Apresentar(string sobrenome)
    {
        Console.WriteLine($"Olá, meu nome é {Nome} {sobrenome}.");
    }
}

} 

