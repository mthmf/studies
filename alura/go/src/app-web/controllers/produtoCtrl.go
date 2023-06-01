package controllers

import (
	"contas/src/app-web/models"
	"html/template"
	"net/http"
	"strconv"
)

var temp = template.Must(template.ParseGlob("templates/*html"))

func Index(w http.ResponseWriter, r *http.Request) {
	produtos := models.GetAll()
	temp.ExecuteTemplate(w, "Index", produtos)
}

func NovoProduto(w http.ResponseWriter, r *http.Request) {
	temp.ExecuteTemplate(w, "NovoProduto", nil)
}

func InsereProduto(w http.ResponseWriter, r *http.Request) {
	if r.Method == "POST" {
		nome := r.FormValue("nome")
		desc := r.FormValue("descricao")
		preco, _ := strconv.ParseFloat(r.FormValue("preco"), 64)
		qtd, _ := strconv.Atoi(r.FormValue("quantidade"))

		models.InsereProduto(nome, desc, preco, qtd)
	}

	http.Redirect(w, r, "/", 301)

}

func Delete(w http.ResponseWriter, r *http.Request) {
	idProduto := r.URL.Query().Get("id")

	models.DeleteProduto(idProduto)
	http.Redirect(w, r, "/", 301)

}

func Edit(w http.ResponseWriter, r *http.Request) {
	idProduto := r.URL.Query().Get("id")
	produto := models.GetProduto(idProduto)

	temp.ExecuteTemplate(w, "Edit", produto)

}

func UpdateProduto(w http.ResponseWriter, r *http.Request) {
	if r.Method == "POST" {
		id := r.FormValue("id")
		nome := r.FormValue("nome")
		desc := r.FormValue("descricao")
		preco, _ := strconv.ParseFloat(r.FormValue("preco"), 64)
		qtd, _ := strconv.Atoi(r.FormValue("quantidade"))

		models.UpdateProduto(id, nome, desc, preco, qtd)
	}

	http.Redirect(w, r, "/", 301)

}
