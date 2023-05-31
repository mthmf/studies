package main

import (
	"html/template"
	"net/http"
)

type Produto struct {
	Nome       string
	Descricao  string
	Preco      float64
	Quantidade int
}

var temp = template.Must(template.ParseGlob("templates/*html"))

func main() {
	http.HandleFunc("/", index)
	http.ListenAndServe(":8000", nil)
}

func index(w http.ResponseWriter, r *http.Request) {
	produtos := []Produto{
		{Nome: "Camisa", Descricao: "Preta", Preco: 69.6, Quantidade: 4},
		{"Tenis", "Vermelho", 156.9, 10},
		{"Casaco", "Preto", 229, 5},
	}
	temp.ExecuteTemplate(w, "Index", produtos)
}
