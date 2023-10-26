package main

import "fmt"

var x [5]int

func main() {
	x[0] = 1
	x[1] = 10
	fmt.Println(x[0], x[1])
	fmt.Println(x)
	fmt.Println(len(x))

	fmt.Println("------ slices ------")
	array := [5]int{1, 2, 3, 4, 5}
	slice := []int{1, 2, 3, 4, 5}

	fmt.Println(array)
	fmt.Println(slice)
	fmt.Println(len(array))
	fmt.Println(len(slice))

	slice = append(slice, 6)
	fmt.Println(slice)
	fmt.Println(len(slice))

	slice2 := []string{"banana", "maca", "uva"}
	for ind, valor := range slice2 {
		fmt.Println("No índice ", ind, "tem o valor:", valor)
	}

	slice3 := []int{20, 60, 23, 15, 3}
	total := 0
	for _, valor := range slice3 {
		total += valor
	}
	fmt.Println("O valor total é ", total)

	fmt.Println("------ *slice slice* ------")

	sab := []string{"pep", "mozz", "abacaxi", "4q", "marg"}
	fatia := sab[0:2]
	fmt.Println(fatia)

	s1lice := []int{1, 2, 3, 4, 5}
	s2lice := []int{10, 11, 12, 13}

	fmt.Println(s1lice)
	s1lice = append(s1lice, 6, 7, 8)
	fmt.Println(s1lice)

	s1lice = append(s1lice, s2lice...)
	fmt.Println(s1lice)

	/// make
	novoSlice := make([]int, 4, 8)
	novoSlice[0], novoSlice[1], novoSlice[2], novoSlice[3] = 1, 2, 3, 4
	novoSlice = append(novoSlice, 5)
	novoSlice = append(novoSlice, 6)
	novoSlice = append(novoSlice, 7)
	novoSlice = append(novoSlice, 8)
	fmt.Println(novoSlice, len(novoSlice), cap(novoSlice)) // cap 8
	novoSlice = append(novoSlice, 9)
	fmt.Println(novoSlice, len(novoSlice), cap(novoSlice)) // cap 16

	// multi/matriz
	ss := [][]int{
		[]int{1, 2, 3},
		[]int{4, 5, 6},
		[]int{7, 8, 9},
	}
	fmt.Println(ss)

	// maps
	people := map[string]int{
		"carlos": 1325864,
		"pedro":  12333,
		"ana":    1123,
	}
	// adicionando info
	people["tatiana"] = 123

	// deletar
	delete(people, "carlos")

	for k, v := range people {
		fmt.Println(k, v)
	}
	
	fmt.Println(people)

}
