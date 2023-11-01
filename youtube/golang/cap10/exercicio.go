package main

import "fmt"

type Pessoa struct {
	nome      string
	sobrenome string
	sabores   []string
}

type Veiculo struct {
	portas int
	cor    string
}

type Caminhonete struct {
	veiculo           Veiculo
	tracaoQuatroRodas bool
}

type Sedan struct {
	veiculo    Veiculo
	modeloLuxo bool
}

func main() {

	// exercicio 1
	pessoa1 := Pessoa{"Marcos", "Lima", []string{"Limão", "Uva"}}
	pessoa2 := Pessoa{"Junior", "Junior", []string{"Avela", "Maracuja"}}

	fmt.Println(pessoa1.nome, ",sabores favoritos:")
	for _, i := range pessoa1.sabores {
		fmt.Println(i)
	}
	fmt.Println(pessoa2.nome, ",sabores favoritos:")
	for _, i := range pessoa2.sabores {
		fmt.Println(i)
	}

	// exercicio 2

	fmt.Println("###############")

	map1 := map[string]Pessoa{
		pessoa1.sobrenome: pessoa1,
		pessoa2.sobrenome: pessoa2,
	}

	for _, item := range map1 {
		fmt.Println(item.nome)
		for _, j := range item.sabores {
			fmt.Println(j)
		}

	}

	// exercicio 3

	fmt.Println("###############")

	caminhonete := Caminhonete{veiculo: Veiculo{2, "Branca"}, tracaoQuatroRodas: true}
	sedan := Sedan{veiculo: Veiculo{4, "Preta"}, modeloLuxo: false}

	fmt.Println(caminhonete)
	fmt.Println(sedan)

	fmt.Println("Quantidade de portas:", caminhonete.veiculo.portas)
	fmt.Println("Quantidade de portas:", sedan.veiculo.portas)

	// exercicio 4

	fmt.Println("###############")

	anon := struct {
		mapa map[string]string
		sli  []string
	}{
		map[string]string{
			"1": "1",
			"2": "2",
		},
		[]string{"Local1, local2"},
	}

	fmt.Println(anon)
}
