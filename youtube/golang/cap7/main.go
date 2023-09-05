package main

import "fmt"

func main() {

	// exercicio 1
	for i := 0; i <= 10; i++ {
		fmt.Printf("%d\t", i)
	}

	// exercicio 2
	for i := 65; i <= 90; i++ {
		fmt.Println("Número:", i)
		for j := 0; j < 3; j++ {
			fmt.Printf("\t%#U\n", i)
		}
	}

	// exercicio 3
	ano := 1996
	for ano <= 2023 {
		fmt.Println("Ano: ", ano)
		ano++
	}

	// exercicio 4

	ano2 := 1996
	for {
		if ano2 > 2023 {
			break
		}
		fmt.Println("4. Ano : ", ano2)
		ano2++
	}

	// exercicio 5
	for i := 10; i <= 100; i++ {
		fmt.Println(i % 4)
	}

	//exercicio 6, 7
	idade := 16
	if idade <= 16 {
		fmt.Println("Não pode entrar ")
	} else {
		fmt.Println("Pode entrar")
	}

	// exercicio 8
	cond := 3
	switch {
	case cond == 1:
		fmt.Println("Cond = 1")
	case cond == 2:
		fmt.Println("Cond = 2")
	case cond == 3:
		fmt.Println("Cond = 3")
	}

	// exercicio 9
	espoteFav := "Futebol"
	switch espoteFav {
	case "Tênis":
		fmt.Println("Tênis")
	case "Volei":
		fmt.Println("Volei")
	case "Futebol":
		fmt.Println("Futebol")
	}

	// exercicio 10

	fmt.Println(true && true)  //true
	fmt.Println(true && false) // false
	fmt.Println(true || true)  // true
	fmt.Println(true || false) //true
	fmt.Println(!true)         // false

}
