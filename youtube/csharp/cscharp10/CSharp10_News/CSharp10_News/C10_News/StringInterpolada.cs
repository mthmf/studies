namespace CSharp10.C10_News;

public class StringInterpolada
{
    public const string Saudacao = "Bem vindo";
    public const string Titulo = "Sr";
    public static string Nome = "Fábio";
    public static string BoasVindas = $"{Saudacao} a você {Titulo}.{Nome}";

    public string RetornaBoasVindas() => BoasVindas;
  
}
