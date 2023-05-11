package main

import (
	"fmt"
	"reflect"
)

func main() {
	//fmt.Println("Hello World")
	var nome string = "Yang"
	var idade int = 32
	var versao float32 = 1.1
	var ves = 2.1 // float64 = pega sempre o maior.
	fmt.Println("Hello. Mrs.", nome, "sua idedade é ", idade)
	fmt.Println("Versão do sistema: ", versao)

	fmt.Println("Tipo da variavel:", reflect.TypeOf(ves))
}
