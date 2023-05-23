package main

import (
	"bufio"
	"fmt"
	"io"
	"io/ioutil"
	"net/http"
	"os"
	"strconv"
	"strings"
	"time"
)

const monitoramento = 3
const delay = 5

func main() {

	exibeIntro()
	for {
		exibeMenu()
		comando := leComando()

		switch comando {
		case 1:
			iniciarMonitoramento()
		case 2:
			imprimeLogs()
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

	//sites := []string{
	//	"https://www.alura.com.br",
	//	"https://www.google.com.br",
	//	"https://www.caelum.com.br",
	//}
	sites := leSitesArquivo()

	for i := 0; i < monitoramento; i++ {
		for _, site := range sites {
			testaSite(site)
		}
		time.Sleep(delay * time.Second)
		fmt.Println("")
	}
	fmt.Println("")

}

func testaSite(site string) {
	resp, error := http.Get(site)

	if error != nil {
		fmt.Println("Ocorreu um erro ", error)
	}

	if resp.StatusCode == 200 {
		fmt.Println("Site:", site, " carregado com sucesso")
		registraLog(site, true)
	} else {
		fmt.Println("Site:", site, " está com problema. Status Code: ", resp.StatusCode)
		registraLog(site, false)
	}
}

func exibeNomesSlice() {
	nomes := []string{"Pedro", "Daniel", "Cristina"}
	nomes = append(nomes, "Italo")
	fmt.Println(nomes)
}

func leSitesArquivo() []string {

	var sites []string
	//arquivo, error := ioutil.ReadFile("sites.txt")
	arquivo, error := os.Open("sites.txt")

	if error != nil {
		fmt.Println("Ocorreu um erro ", error)
	}

	var reader = bufio.NewReader(arquivo)
	for {
		linha, err := reader.ReadString('\n')
		linha = strings.TrimSpace(linha)
		sites = append(sites, linha)
		if err == io.EOF {
			break
		}
	}

	arquivo.Close()
	return sites
}

func registraLog(site string, status bool) {
	arquivo, err := os.OpenFile("log.txt", os.O_RDWR|os.O_APPEND|os.O_CREATE, 0666)

	arquivo.WriteString(time.Now().Format("02/01/2006 15:04:05") + " - " + site + " - online: " + strconv.FormatBool(status) + "\n")
	if err != nil {
		fmt.Println(err)
	}
	fmt.Println(arquivo)

	arquivo.Close()
}

func imprimeLogs() {
	fmt.Println("Exibindo Logs")
	arquivo, err := ioutil.ReadFile("log.txt")
	if err != nil {
		fmt.Println(err)
	}
	fmt.Println(string(arquivo))

}
