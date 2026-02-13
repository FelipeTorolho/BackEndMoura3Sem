using Exercicio05;

public class Funcionario : Pessoa
{
    public double Salario { get; set; }

    public Funcionario(string nome, int idade, double salario)
        : base(nome, idade) //chama o construtor da classe Pessoa
    {
        Salario = salario;
    }

    public void ExibirDadosFuncionario()
    {
        ExibirDados(); 
        Console.WriteLine($"Salário: {Salario}");
    }
}
