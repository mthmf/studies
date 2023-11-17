package main

import "fmt"

type Pessoa struct {
	nome      string
	sobrenome string
	idade     int
}

type Profissao interface {
	sayHello()
}

type arquiteto struct {
	Pessoa
	salario float32
	decora  bool
}

type engenheiro struct {
	Pessoa
	salario  float32
	constroi bool
}

func (p arquiteto) sayHello() {
	fmt.Println(p.nome, ", hello! arquiteto")
}

func (p engenheiro) sayHello() {
	fmt.Println(p.nome, ", hello! engenheiro")
}

func sayHelloAll(p Profissao) {
	p.sayHello()
}

func (p Pessoa) hello() {
	fmt.Println(p.nome, ", hello!")
}

func main() {
	showNome("nome")

	valor := soma(10, 23)
	fmt.Println(valor)

	fmt.Println(somaVarios(26, 95, 36, 15))

	defer fmt.Println("1")
	fmt.Println("2")
	fmt.Println("3")
	fmt.Println("4")

	// result: 2 , 3, 4 , 1

	// metodos
	pessoa := Pessoa{"Pablo", "Silva", 32}
	pessoa.hello()

	arquiteto := arquiteto{
		Pessoa:  Pessoa{"Luis", "Silva", 40},
		salario: 123,
		decora:  true,
	}

	engenheiro := engenheiro{
		Pessoa:   Pessoa{"Carlos", "Silva", 20},
		salario:  123,
		constroi: true,
	}

	//arquiteto.sayHello()
	//engenheiro.sayHello()
	sayHelloAll(arquiteto)
	sayHelloAll(engenheiro)

	x := 1231
	func(x int) {
		fmt.Println(x, "vezes 655 é", x*655)
	}(x)

	y := 123
	teste := func(x int) {
		fmt.Println(x, "vezes 655 é", x*123)
	}

	teste(y)

	x1 := retornaFuncao()
	y1 := x1(5)

	fmt.Println(y1)
	fmt.Println(retornaFuncao()(2))

	// callback
	valores := somenteImpar(total, []int{10, 2, 3, 97, 74, 68}...)
	fmt.Println(valores)

}

func total(x ...int) int {
	total := 0
	for _, i := range x {
		total += i
	}
	return total
}

func somenteImpar(funcao func(x ...int) int, y ...int) int {
	var impares []int
	for _, i := range y {
		if i%2 == 1 {
			impares = append(impares, i)
		}
	}
	total := funcao(impares...)
	return total
}

func retornaFuncao() func(int) int {
	return func(valor int) int {
		return valor * 10
	}
}

func basic() {
	fmt.Println("Hello World")
}

// com parametro
func showNome(nome string) {
	fmt.Println(nome)
}

// com parametro e retorno
func soma(x, y int) int {
	return x + y
}

// multiplos retornos e parametros variadicos
func somaVarios(x ...int) (int, int) {
	total := 0
	for _, v := range x {
		total += v
	}
	return total, len(x)
}
