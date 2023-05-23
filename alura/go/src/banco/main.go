package main

import (
	c "banco/contas"
	"fmt"
)

func main() {
	conta1 := c.ContaCorrente{
		Titular:       "Roberto",
		NumeroAgencia: 12354,
		NumeroConta:   12344,
		Saldo:         900.63,
	}

	conta2 := c.ContaCorrente{
		Titular:       "Gustavo",
		NumeroAgencia: 12354,
		NumeroConta:   12345,
		Saldo:         950.63,
	}

	valor := 200.
	conta1.Sacar(valor)
	conta1.Depositar(500.)
	fmt.Println(conta1.Saldo)

	status := conta1.Transferir(200, &conta2)
	fmt.Println(status)

	fmt.Println(conta2)
}
