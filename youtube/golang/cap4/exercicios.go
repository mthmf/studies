package main

import "fmt"

const novaConst int = 10

const newCons = 16

const (
	ano1 = 2023 + iota
	ano2
	ano3
	ano4
)

func main() {
	// exercicio 1
	x := 42
	fmt.Printf("decimal: %d \n binário: %b \n hexa: %#x \n", x, x, x)

	// exercicio 2
	x1 := 10 == 10
	y1 := 32 <= 31
	z1 := 49 >= 49
	fmt.Println("10 == 10: ", x1)
	fmt.Println("32 <= 31: ", y1)
	fmt.Println("49 >= 49: ", z1)

	// exercicio 3
	fmt.Println(novaConst, newCons)

	// exercicio 4
	x2 := 36
	fmt.Printf("decimal: %d \n binário: %b \n hexa: %#x \n", x2, x2, x2)
	y2 := x2 << 1
	fmt.Printf("decimal: %d \n binário: %b \n hexa: %#x \n", y2, y2, y2)

	// exercicio 5
	str := `nova string
				com 
				
				separação war`
	fmt.Println(str)

	// exercicio 6

	fmt.Println(ano1, ano2, ano3, ano4)

}
