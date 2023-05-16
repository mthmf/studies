package main

import (
	"fmt"
)

func main() {
	//fmt.Println("Hello World")
	var nome string = "Yang"
	var versao float32 = 1.1
	//var ves = 2.1 // float64 = pega sempre o maior.
	//fmt.Println("Tipo da variavel:", reflect.TypeOf(ves))

	fmt.Println("Olá, sr.", nome)
	fmt.Println("Versão do sistema: ", versao)

	fmt.Println("1 - Iniciar Monitoramento")
	fmt.Println("2 - Exibir Logs")
	fmt.Println("3 - Sair")
	var comando int
	fmt.Scan(&comando)

	//if comando == 1 {
	//	fmt.Println("Monitorando...")
	//}

	switch comando {
	case 1:
		fmt.Println("Monitorando")
	case 2:
		fmt.Println("Exibindo Logs")
	default:
		fmt.Println("Comnando não encontrado.")
	}
}
