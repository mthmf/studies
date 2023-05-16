package main

import (
	"fmt"
	"net/http"
	"os"
)

func main() {

	exibeIntro()
	for {
		exibeMenu()
		comando := leComando()

		switch comando {
		case 1:
			iniciarMonitoramento()
		case 2:
			fmt.Println("Exibindo Logs")
		case 0:
			os.Exit(0)
		default:
			fmt.Println("Comnando não encontrado.")
		}
	}
}

func devolveNomeIdade() (string, int) {
	nome := "Ted"
	idade := 26
	return nome, idade
}

func exibeIntro() {
	var nome string = "Yang"
	var versao float32 = 1.1
	fmt.Println("Olá, sr.", nome)
	fmt.Println("Versão do sistema: ", versao)
}

func leComando() int {

	var comando int
	fmt.Scan(&comando)
	return comando
}

func exibeMenu() {
	fmt.Println("1 - Iniciar Monitoramento")
	fmt.Println("2 - Exibir Logs")
	fmt.Println("3 - Sair")
}

func iniciarMonitoramento() {
	fmt.Println("Monitorando")
	site := "https://www.alura.com.br"
	resp, _ := http.Get(site)
	if resp.StatusCode == 200 {
		fmt.Println("Site:", site, " carregado com sucesso")
	} else {
		fmt.Println("Site:", site, " está com problema. Status Code: ", resp.StatusCode)
	}

}
