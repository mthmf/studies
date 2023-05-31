package main

import (
	"contas/src/banco/clientes"
	c "contas/src/banco/contas"
	"fmt"
)

func main() {
	cliente := clientes.Titular{"Roberto", "152165", "Dev"}
	conta1 := c.ContaCorrente{
		Titular:       cliente,
		NumeroAgencia: 12354,
		NumeroConta:   12344,
	}

	conta2 := c.ContaCorrente{
		Titular:       cliente,
		NumeroAgencia: 12354,
		NumeroConta:   12345,
	}

	valor := 200.
	conta1.Sacar(valor)
	conta1.Depositar(500.)
	//fmt.Println(conta1.Saldo)
	PagarBoleto(&conta1, 400)

	status := conta1.Transferir(200, &conta2)
	fmt.Println(status)

	fmt.Println(conta2)
}

func PagarBoleto(conta verificaConta, valorBoleto float64) {
	conta.Sacar(valorBoleto)
}

type verificaConta interface {
	Sacar(valor float64) string
}
