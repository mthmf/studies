package main

import "fmt"

var x [5]int

func main() {
	// exercicio 1
	x[0] = 1996
	x[1] = 1997
	x[2] = 1998
	x[3] = 1999
	x[4] = 2000

	for _, i := range x {
		fmt.Println(i)
	}
	fmt.Printf("%#T", x)

	// exercicio 2
	valores := []int{1, 2, 3, 4, 5, 6, 7, 8, 9, 0}
	for _, valor := range valores {
		fmt.Println("Valor: ", valor)
	}
	fmt.Printf("%#T \n", valores)

	// exercicio 3

	fatia1 := valores[:3]
	fatia2 := valores[4:]
	fatia3 := valores[1:7]
	fatia4 := valores[3 : len(valores)-1]
	fmt.Println(fatia1)
	fmt.Println(fatia2)
	fmt.Println(fatia3)
	fmt.Println(fatia4)

	// exercicio 4

	outro := []int{42, 43, 44, 45, 46, 47, 48, 49, 50, 51}
	y := []int{56, 57, 58, 59, 60}
	outro = append(outro, y...)
	//todos os elementos são apresentados.

	outro = append(outro, 52)
	outro = append(outro, 53, 54, 55)

	fmt.Println(outro)

	outro = append(outro, y...)

	fmt.Println(outro)

	// exercicio 5
	val := []int{42, 43, 44, 45, 46, 47, 48, 49, 50, 51}
	val2 := append(val[:3], val[6:]...)

	fmt.Println("Valor do Slice principal: ", val)
	fmt.Println("Valor do segundo slice:", val2)

	// exercicio 6

	estados := make([]string, 26, 30)
	estados = []string{"Acre", "Alagoas", "Amapá", "Amazonas", "Bahia", "Ceará", "Espírito Santo", "Goiás", "Maranhão", "Mato Grosso", "Mato Grosso do Sul", "Minas Gerais", "Pará", "Paraíba", "Paraná",
		"Pernambuco", "Piauí", "Rio de Janeiro", "Rio Grande do Norte", "Rio Grande do Sul", "Rondônia", "Roraima", "Santa Catarina", "São Paulo", "Sergipe", "Tocantins"}

	fmt.Println("\nTamnanho do slice de estados ", len(estados))
	fmt.Println("Cap do slice de estados", cap(estados))

	for i := 0; i < len(estados); i++ {
		fmt.Println("Estado: ", estados[i])
	}

	// exercicio 7

	pessoas := [][]string{
		[]string{"Felipe", "Nogueira", "Futebol"},
		[]string{"José", "Chaves", "Tênis"},
		[]string{"Ricardo", "Mendes", "Vôlei"},
	}

	for _, i := range pessoas {
		fmt.Println("Pessoa: ", i[0])
		fmt.Println("Sobrenome: ", i[1])
		fmt.Println("Hobby: ", i[2])
	}

	// exercicio 8/9/10
	nomes := map[string][]string{
		"gomes_italo":   {"Estudar", "Escalar"}, 
		"caxias_carlos": {"Violão", "Esqui"},
		"bou_julio":     {"Videogame", "Futebol"},
	}
	nomes["silva_cris"] = []string{"Hockey, Basquete"}
	delete(nomes, "gomes_italo")

	for i, item := range nomes {
		fmt.Print(i, ", Hobbys:")
		for _, j := range item {
			fmt.Print(j, "\t")
		}
		fmt.Println()
	}

}
