package models

import "contas/src/app-web/db"

type Produto struct {
	Id         int
	Nome       string
	Descricao  string
	Preco      float64
	Quantidade int
}

func GetAll() []Produto {
	db := db.ConectaBanco()
	/*produtos := []Produto{
		{Nome: "Camisa", Descricao: "Preta", Preco: 69.6, Quantidade: 4},
		{"Tenis", "Vermelho", 156.9, 10},
		{"Casaco", "Preto", 229, 5},
	}*/
	selectProdutos, err := db.Query("select * from produtos")
	if err != nil {
		panic(err.Error)
	}

	p := Produto{}
	produtos := []Produto{}
	for selectProdutos.Next() {
		var id, quantidade int
		var nome, descricao string
		var preco float64

		err = selectProdutos.Scan(&id, &nome, &descricao, &preco, &quantidade)
		if err != nil {
			panic(err.Error)
		}
		p.Nome = nome
		p.Descricao = descricao
		p.Preco = preco
		p.Quantidade = quantidade

		produtos = append(produtos, p)

	}
	defer db.Close()
	return produtos
}
