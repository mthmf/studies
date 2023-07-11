package main

import (
	"fmt"
	"go-rest-api/models"
	"go-rest-api/routes"
)

func main() {
	fmt.Println("Iniciando o servidor Rest com GO")
	models.Personalidades = []models.Personalidade{
		{Nome: "Nome 1", Historia: "Historia 1 "},
		{Nome: "Nome 1", Historia: "Historia 2 "},
	}
	routes.HandleRequest()
}
