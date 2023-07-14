package main

import (
	controller "api-go-gin/controllers"
	"api-go-gin/database"
	"api-go-gin/models"
	"bytes"
	"encoding/json"
	"fmt"
	"io/ioutil"
	"net/http"
	"net/http/httptest"
	"strconv"
	"testing"

	"github.com/gin-gonic/gin"
	"github.com/stretchr/testify/assert"
)

var ID int

func SetupRotasTeste() *gin.Engine {
	gin.SetMode(gin.ReleaseMode)
	rotas := gin.Default()
	return rotas
}

func CriaAlunoMock() {
	aluno := models.Aluno{Nome: "Aluno teste", CPF: "12345678900", RG: "113456789"}
	database.DB.Create(&aluno)
	ID = int(aluno.ID)
	fmt.Println("ID novo do Aluno", ID)
}

func DeletaAlunoMock() {
	var aluno models.Aluno
	database.DB.Delete(&aluno, ID)
}

/* func TestFalha(t *testing.T) {
	t.Fatalf("Teste falhou")
}
*/

func TestVerificaStatusCodeSaudacao(t *testing.T) {
	r := SetupRotasTeste()
	r.GET("/:nome", controller.Saudacao)
	req, _ := http.NewRequest("GET", "/mth", nil)
	response := httptest.NewRecorder()

	r.ServeHTTP(response, req)

	assert.Equal(t, http.StatusOK, response.Code)
	mockResponse := `{"API diz":"Olá,mth"}`
	responseBody, _ := ioutil.ReadAll(response.Body)

	assert.Equal(t, mockResponse, string(responseBody))
}

func TestListaTodosAlunosHandler(t *testing.T) {
	database.ConectaBanco()
	CriaAlunoMock()
	defer DeletaAlunoMock()
	r := SetupRotasTeste()
	r.GET("/alunos", controller.ExibeTodosAlunos)
	req, _ := http.NewRequest("GET", "/alunos", nil)
	response := httptest.NewRecorder()

	r.ServeHTTP(response, req)

	assert.Equal(t, http.StatusOK, response.Code)

}

func TestBuscaAlunoCpfHandler(t *testing.T) {
	database.ConectaBanco()
	CriaAlunoMock()
	defer DeletaAlunoMock()
	r := SetupRotasTeste()
	r.GET("/alunos/cpf/:cpf", controller.BuscaAlunoPorCPF)

	req, _ := http.NewRequest("GET", "/alunos/cpf/12345678900", nil)
	response := httptest.NewRecorder()

	r.ServeHTTP(response, req)

	assert.Equal(t, http.StatusOK, response.Code)

}

func TestBuscaAlunoPorIdHandler(t *testing.T) {

	database.ConectaBanco()
	CriaAlunoMock()
	defer DeletaAlunoMock()
	r := SetupRotasTeste()
	r.GET("/alunos/:id", controller.ExibeUmAluno)
	path := "/alunos/" + strconv.Itoa(ID)
	req, _ := http.NewRequest("GET", path, nil)
	response := httptest.NewRecorder()

	r.ServeHTTP(response, req)

	var alunoMock models.Aluno
	json.Unmarshal(response.Body.Bytes(), &alunoMock)

	assert.Equal(t, "Aluno teste", alunoMock.Nome)

}

func TestDeletaAlunoHandler(t *testing.T) {
	database.ConectaBanco()
	CriaAlunoMock()
	r := SetupRotasTeste()
	r.DELETE("/alunos/:id", controller.DeletaAluno)
	path := "/alunos/" + strconv.Itoa(ID)
	req, _ := http.NewRequest("DELETE", path, nil)
	response := httptest.NewRecorder()

	r.ServeHTTP(response, req)

	assert.Equal(t, http.StatusOK, response.Code)
}

func TestEditaAlunoHandler(t *testing.T) {
	database.ConectaBanco()
	CriaAlunoMock()
	defer DeletaAlunoMock()

	r := SetupRotasTeste()
	r.PATCH("/alunos/:id", controller.EditaAluno)
	aluno := models.Aluno{Nome: "Aluno novo", CPF: "12345678900", RG: "113456789"}

	path := "/alunos/" + strconv.Itoa(ID)
	alunoJson, _ := json.Marshal(&aluno)
	req, _ := http.NewRequest("PATCH", path, bytes.NewBuffer(alunoJson))
	response := httptest.NewRecorder()

	r.ServeHTTP(response, req)

	var alunoMock models.Aluno
	json.Unmarshal(response.Body.Bytes(), &alunoMock)

	assert.Equal(t, aluno.Nome, alunoMock.Nome)

}
