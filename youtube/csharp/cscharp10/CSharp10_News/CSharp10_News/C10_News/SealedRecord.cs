namespace CSharp10_News.C10_News;

public record Pessoa
{
    public string? Nome { get; init; }
    public string? SobreNome { get; init; }

    public sealed override string ToString()
    {
        return $"Meu nome é: {Nome} {SobreNome}";
    }
}


public record Aluno: Pessoa
{
    // Não é possível fazer a sobreescrita do ToString() por que está definido como sealed
   /* public override string ToString()
    {
        return $"Meu nome de Aluno é : {Nome} {SobreNome}";
    }*/
}