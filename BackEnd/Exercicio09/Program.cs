using System.Runtime.Intrinsics.X86;
using Exercicio09;

Console.WriteLine("Escolha o primeiro número da equação");
float a = float.Parse(Console.ReadLine());

Console.WriteLine("Escolha o segundo número da equação");
float b = float.Parse(Console.ReadLine());

CalculadoraClass cal = new CalculadoraClass(a, b);
cal.Multiplicar();