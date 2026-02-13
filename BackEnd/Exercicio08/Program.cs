using Exercicio08;

Usuario u = new Usuario();
Administrador admin = new Administrador();

Console.WriteLine("Usuário autenticado: " + u.Autenticar("123"));
Console.WriteLine("Administrador autenticado: " + admin.Autenticar("admin"));
