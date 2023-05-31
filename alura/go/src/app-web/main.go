package main

import (
	"html/template"
	"net/http"

	"contas/src/app-web/models"

	_ "github.com/lib/pq"
)

var temp = template.Must(template.ParseGlob("templates/*html"))

func main() {
	http.HandleFunc("/", index)
	http.ListenAndServe(":8000", nil)
}

func index(w http.ResponseWriter, r *http.Request) {
	produtos := models.GetAll()
	temp.ExecuteTemplate(w, "Index", produtos)

}
