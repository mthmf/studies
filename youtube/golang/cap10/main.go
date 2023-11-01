package main

import "fmt"

type cliente struct {
	nome      string
	sobrenome string
	fumante   bool
}

type pessoa struct {
	nome  string
	idade int
}

type profissional struct {
	pessoa
	titulo  string
	salario int
}

func main() {
	cliente1 := cliente{
		nome:      "Lauro",
		sobrenome: "Giekuz",
		fumante:   false,
	}

	pessoa1 := pessoa{
		nome:  "Cristiano",
		idade: 25,
	}

	profi := profissional{
		pessoa:  pessoa1,
		titulo:  "Graduada",
		salario: 10000,
	}

	x := struct {
		nome  string
		idade int
	}{
		"Mario", 60,
	}


	fmt.Println(cliente1)
	fmt.Println(pessoa1)
	fmt.Println(profi)
	fmt.Println(x)

}
