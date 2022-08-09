// See https://aka.ms/new-console-template for more information
using CSharp10.C10_News;
using CSharp10_News.C10_News;

Console.WriteLine("C# 10 - Strings interpoladas constantes");
StringInterpolada stringInterpolada = new StringInterpolada();
Console.WriteLine(stringInterpolada.RetornaBoasVindas());

Console.WriteLine("");
Console.WriteLine("C# 10 - Sealed ToString() Records");
Pessoa pessoa = new Pessoa()
{
    Nome = "Júnior",
    SobreNome = "Teste"
};

Console.WriteLine(pessoa.ToString());

Aluno aluno = new Aluno()
{
    Nome = "Júnior Aluno ",
    SobreNome = "Teste Fechado"
};

Console.WriteLine(aluno.ToString());

Console.WriteLine("");
Console.WriteLine("C# 10 - Record Structs ");
Linguagem linguagem = new Linguagem(){Nome = "C#"};
Projeto projeto = new Projeto() { Nome = "Autorizador", Linguagem = linguagem, Versao = 1 };

Console.WriteLine($"Linguagem ToString() = {linguagem}");
Console.WriteLine($"Projeto ToString() = {projeto}");



Console.WriteLine("");
Console.WriteLine("C# 10 - ThrowIfNull ");

static string Juntar(string a, string b)
{
    ArgumentNullException.ThrowIfNull(a);
    ArgumentNullException.ThrowIfNull(b);
    return a + b;
}
Juntar("as", "sadf");


Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("#### Expressões Lambdas ### ");
Console.WriteLine("C# 10 - Inferir tipo natural em lambda (var) ");

// C# 9
Func<int, bool> IsPositivo = (int numero) => numero > 0;
Console.WriteLine($"O número 9 é positivo {IsPositivo(9)}");

Action<int> Imprimir = (int i) => Console.WriteLine(i);
Imprimir(10);

// C#10
var IsPositivoNovo = (int numero) => numero > 0;
Console.WriteLine($"O número 9 é positivo {IsPositivoNovo(9)}");

var ImprimirNovo = (int i) => Console.WriteLine(i);
ImprimirNovo(10);

Console.WriteLine("");
Console.WriteLine("C# 10 - Inferir tipo natural para grupo de métodos ");

var leitura = Console.Read();
//var escrito = Console.Write(); 

var EntradaUsuario = Console.ReadLine;
var DizAoUsuario = (string s) => Console.WriteLine(s);

var nome = EntradaUsuario();
DizAoUsuario(nome);


Console.WriteLine("");
Console.WriteLine("C# 10 - Tipo de retorno em lambda ");
