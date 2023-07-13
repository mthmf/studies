package database

import (
	"api-go-gin/models"
	"log"

	"gorm.io/driver/postgres"
	"gorm.io/gorm"
)

var (
	DB   *gorm.DB
	erro error
)

func ConectaBanco() {
	stringConexao := "host=localhost user=root password=root dbname=root port=5432"
	con, err := gorm.Open(postgres.Open(stringConexao))
	if err != nil {
		log.Panic("Erro ao conectar com o banco de dados")
	}
	DB = con
	DB.AutoMigrate(&models.Aluno{})
}
