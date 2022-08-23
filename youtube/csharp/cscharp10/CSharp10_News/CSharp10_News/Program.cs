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

//var leitura = Console.Read();
//var escrito = Console.Write(); 

//var EntradaUsuario = Console.ReadLine;
var DizAoUsuario = (string s) => Console.WriteLine(s);

var nome = "nome"; //EntradaUsuario();
DizAoUsuario(nome);


Console.WriteLine("");
Console.WriteLine("C# 10 - Tipo de retorno em lambda ");

var escolha = string (bool b) => b ? "um" : "dois";
Console.WriteLine(escolha);

Console.WriteLine("");
Console.WriteLine("C# 10 - TimeOnly ");

var time = new TimeOnly();
var timeWithHour = new TimeOnly(8, 0);
var timeWithHour2 = new TimeOnly(18, 45);
var complete = new TimeOnly(20, 30, 50);
var timeWithParse = TimeOnly.Parse("16:50");
var fromMinutes = TimeSpan.FromMinutes(10);
var minutes_time = TimeOnly.FromTimeSpan(fromMinutes);

Console.WriteLine($"Hora padrão: { time}");
Console.WriteLine($"Hora antes das 12h: { timeWithHour}");
Console.WriteLine($"Hora depois das 12h: { timeWithHour2}");
Console.WriteLine($"Hora com parse: {timeWithParse}");
Console.WriteLine($"Minutos a partir de um TimeSpan: {minutes_time}");
Console.WriteLine($"Usando as propriedades TimeOnly.Hour {complete.Hour}/TimeOnly.Minute {complete.Minute}/TimeOnly.Second {complete.Second}");

var newComplete = complete.AddHours(2).AddMinutes(25);


Console.WriteLine("");
Console.WriteLine("C# 10 - DateOnly ");

var dateonly = new DateOnly();
var dateReal = new DateOnly(2022, 8, 23);
DateOnly dataFromDate = DateOnly.FromDateTime(DateTime.Now);
DateOnly dataNumber = DateOnly.FromDayNumber(739117);


Console.WriteLine($"Date Only Padrão: {dateonly}");
Console.WriteLine($"Date Only Completo: {dateReal}");
Console.WriteLine($"FromDateTime: {dataFromDate}");
Console.WriteLine($"FromDayNumber: {dataNumber}");

Console.WriteLine("");
Console.WriteLine("Propriedades...");
Console.WriteLine($"Ano: {dateReal.Year}");
Console.WriteLine($"Mês: {dateReal.Month}");
Console.WriteLine($"Dia: {dateReal.Day}");

Console.WriteLine("");
Console.WriteLine("Métodos...");

var newDateReal = dateReal.AddDays(50).AddMonths(96).AddYears(40);
Console.WriteLine($"Nova Data: {newDateReal}");



