package main

import "fmt"

func main() {

	for x := 0; x < 10; x++ {
		fmt.Println(x)
	}

	// clock neasted for
	for hora := 1; hora <= 12; hora++ {
		//fmt.Println("Hora ", hora)
		for min := 1; min <= 60; min++ {
			//	fmt.Printf("%d ", min)
		}
		//fmt.Print("\n")
	}

	y := 0
	for y < 10 {
		fmt.Printf("%d ", y)
		if y == 5 {
			break
		}
		y++
	}

	fmt.Print("\n")
	for i := 0; i < 10; i++ {
		if i%2 != 0 {
			continue
		}
		fmt.Printf("%d ", i)

	}
	fmt.Print("\n")
	fmt.Print("Formatos")
	for i := 33; i <= 122; i++ {
		fmt.Printf("%d %#x %#U ", i, i, i)
		fmt.Print("\t \n")

	}

	if h := 11; h > 10 {
		fmt.Print("É maior que 10")

	}

	val := "talvez"
	switch {
	case val == "sim":
		fmt.Print("Sim")
	case val == "talvez":
		fmt.Print("Talvez")
	}

	// com comparação direto
	nome := "joana"
	switch nome {
	case "marcos":
		fmt.Print("Marcos")
	case "joana":
		fmt.Print("Joana")
	}

	// com fallthrough
	teste := "n1"
	switch teste {
	case "n1":
		fmt.Print("n1")
		fallthrough
	case "n2":
		fmt.Print("n2")
	}
	//resultado n1n2


}
