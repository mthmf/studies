package main

import (
	"fmt"
	"math"
)

type Pessoa struct {
	nome      string
	sobrenome string
	idade     int
}

type figura interface {
	area() float32
}

type quadrado struct {
	lado int
}

type circulo struct {
	raio float32
}

func (q quadrado) area() float32 {
	return float32(q.lado) * float32(q.lado)
}

func (c circulo) area() float32 {
	return 2.0 * math.Pi * c.raio
}

func info(f figura) float32 {
	return f.area()
}

func main() {

	// exercicio 1
	fmt.Println(retornaInt())
	fmt.Println(retornaIntString())

	// exercicio 2
	fmt.Println("Sem slice: ", getVariari(2, 6, 9, 12))
	numeros := []int{3, 6, 89, 12}
	fmt.Println("Com o Slice:", getVariari(numeros[2:]...))
	fmt.Println("Com função de Slice :", getSlice(numeros[2:]))

	// exercicio 3
	//defer fmt.Println(last())
	fmt.Println(first())

	// exercicio 4
	pessoa := Pessoa{"Julio", "Luis", 22}
	fmt.Println(pessoa.mostraNome())

	// exercicio 5
	q := quadrado{3}
	c := circulo{4.5}
	fmt.Println("Área do quadrado:", info(q))
	fmt.Println("Área do circulo: ", info(c))

	// exercicio 6
	x := 1523
	func(x int) {
		fmt.Println("Valor de x é:", x)
	}(x)

	// exercicio 7

	funcao := func() {
		fmt.Println("Chamada via função")
	}

	funcao()

	// exercicio 8
	outraFuncao := retorna()
	outraFuncao()

	// exercicio 9
	call(apresenta, "Roberto")



}

func apresenta(nome string) {
	fmt.Println("Fala ", nome)
}

func call(minhafunc func(nome string), nome string) {
	minhafunc(nome)
}

func retorna() func() {
	fmt.Println("Dentro da funcao 1")
	return func() {
		fmt.Println("Dentro da funcao 2!")
	}
}

func (p Pessoa) mostraNome() string {
	return p.nome + " " + p.sobrenome
}

func retornaInt() int {
	return 4
}

func retornaIntString() (int, string) {
	return 5, "teste"
}

func getVariari(numeros ...int) int {
	total := 0
	for _, i := range numeros {
		total += i
	}
	return total
}

func getSlice(slice []int) int {
	total := 0
	for _, v := range slice {
		total += v
	}
	return total
}

func first() string {
	return "Primeiro"
}

func last() string {
	return "Ultimo"
}
