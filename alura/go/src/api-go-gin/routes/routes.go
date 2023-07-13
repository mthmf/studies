package routes

import (
	controller "api-go-gin/controllers"

	"github.com/gin-gonic/gin"
)

func HandleRequests() {
	r := gin.Default()
	r.GET("/alunos", controller.ExibeTodosAlunos)
	r.GET("/alunos/:id", controller.ExibeUmAluno)
	r.GET("/alunos/cpf/:cpf", controller.BuscaAlunoPorCPF)
	r.DELETE("/alunos/:id", controller.DeletaAluno)
	r.PATCH("/alunos/:id", controller.EditaAluno)
	r.GET("/:nome", controller.Saudacao)
	r.POST("/alunos", controller.CriaNovoAluno)
	r.Run(":8000")
}
