package main

import (
	"fmt"
)

type ContaCorrente struct {
	titular       string
	numeroAgencia int
	numeroConta   int
	saldo         float64
}

func main() {
	conta1 := ContaCorrente{
		titular:       "Roberto",
		numeroAgencia: 12354,
		numeroConta:   12344,
		saldo:         12.63,
	}

	conta2 := ContaCorrente{"Bruna", 54, 344, 121.63}

	var conta3 *ContaCorrente
	conta3 = new(ContaCorrente)
	conta3.titular = "Jr"

	fmt.Println(conta1)
	fmt.Println(conta2)
	fmt.Println(conta3)

}
