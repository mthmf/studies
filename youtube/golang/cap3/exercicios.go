package main

import "fmt"

var (
	x2 int
	y2 string
	z2 bool

	x3 = 42
	y3 = "James Bond"
	z3 = true
)

type storie int

var newstr storie

var newstr2 uint

func main() {
	// exercicio 1
	x, y, z := 42, "James Bond", true

	fmt.Println(x, y, z)
	fmt.Println(x)
	fmt.Println(y)
	fmt.Println(z)

	// exercicio 2
	fmt.Println("\n Exercicio 2 \n ")
	fmt.Println(x2)
	fmt.Println(y2)
	fmt.Println(z2)

	// exercicio 3
	fmt.Println("\n Exercicio 3 \n ")
	s := fmt.Sprintf("%v\t%v\t%v", x3, y3, z3)
	fmt.Println(s)

	// exercicio 4
	fmt.Println("\n Exercicio 4\n ")
	fmt.Printf("%d %T \n", newstr, newstr)
	newstr = 42
	fmt.Printf("%d %T \n", newstr, newstr)

	// exercicio 5
	fmt.Println("\n Exercicio 5\n ")
	newstr2 = int(newstr)
	fmt.Printf("%d %T \n", newstr2, newstr2)
}
