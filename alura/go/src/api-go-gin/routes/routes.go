package routes

import (
	controller "api-go-gin/controllers"
	docs "api-go-gin/docs"

	"github.com/gin-gonic/gin"
	swaggerfiles "github.com/swaggo/files"
	ginSwagger "github.com/swaggo/gin-swagger"
)

func HandleRequests() {
	r := gin.Default()
	docs.SwaggerInfo.BasePath = "/"
	r.LoadHTMLGlob("templates/*")
	r.Static("/assets", "./assets")

	r.GET("/alunos", controller.ExibeTodosAlunos)
	r.GET("/alunos/:id", controller.ExibeUmAluno)
	r.GET("/alunos/cpf/:cpf", controller.BuscaAlunoPorCPF)
	r.DELETE("/alunos/:id", controller.DeletaAluno)
	r.PATCH("/alunos/:id", controller.EditaAluno)
	r.GET("/:nome", controller.Saudacao)
	r.POST("/alunos", controller.CriaNovoAluno)
	r.GET("/swagger/*any", ginSwagger.WrapHandler(swaggerfiles.Handler))
	r.NoRoute(controller.RouteNotFound)
	r.GET("/", controller.ExibePaginaIndex)
	r.Run(":8000")
}
