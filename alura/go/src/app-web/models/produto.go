package models

import (
	"contas/src/app-web/db"
	"strconv"
)

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
	selectProdutos, err := db.Query("select * from produtos order by id asc")
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
		p.Id = id
		p.Nome = nome
		p.Descricao = descricao
		p.Preco = preco
		p.Quantidade = quantidade

		produtos = append(produtos, p)

	}
	defer db.Close()
	return produtos
}

func GetProduto(id string) Produto {
	db := db.ConectaBanco()

	selectProdutos, err := db.Query("select * from produtos where id =$1", id)
	if err != nil {
		panic(err.Error)
	}

	var produto = Produto{}
	for selectProdutos.Next() {
		var idBd, quantidade int
		var nome, descricao string
		var preco float64

		err = selectProdutos.Scan(&idBd, &nome, &descricao, &preco, &quantidade)
		if err != nil {
			panic(err.Error)
		}

		produto.Id, _ = strconv.Atoi(id)
		produto.Nome = nome
		produto.Descricao = descricao
		produto.Preco = preco
		produto.Quantidade = quantidade
	}
	defer db.Close()

	return produto

}

func InsereProduto(nome, desc string, preco float64, qtd int) {

	db := db.ConectaBanco()

	insere, err := db.Prepare("insert into produtos (nome, descricao, preco, quantidade) values ($1, $2, $3, $4)")

	if err != nil {
		panic(err.Error)
	}
	insere.Exec(nome, desc, preco, qtd)

	defer db.Close()
}

func DeleteProduto(id string) {

	db := db.ConectaBanco()

	del, err := db.Prepare("delete from produtos where id= $1")

	if err != nil {
		panic(err.Error())
	}

	del.Exec(id)

	defer db.Close()
}

func UpdateProduto(id string, nome, desc string, preco float64, qtd int) {

	db := db.ConectaBanco()

	del, err := db.Prepare("update produtos set  nome=$1, descricao=$2, preco=$3, quantidade=$4 where id= $5")

	if err != nil {
		panic(err.Error())
	}

	del.Exec(nome, desc, preco, qtd, id)

	defer db.Close()
}
