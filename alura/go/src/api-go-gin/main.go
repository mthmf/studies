package main

import (
	"api-go-gin/database"
	"api-go-gin/routes"
)

func main() {
	database.ConectaBanco()

	/*models.Alunos = []models.Aluno{
		{Nome: "Maria", CPF: "00000000000", RG: "846986546"},
	}*/
	routes.HandleRequests()
}
