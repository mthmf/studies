namespace CSharp10_News.C10_News;

public readonly record struct Projeto(string? Nome, int Versao, Linguagem? Linguagem);

public readonly record struct Linguagem(string? Nome);
