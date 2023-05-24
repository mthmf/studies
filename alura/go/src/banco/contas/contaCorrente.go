package conta

import (
	"contas/src/banco/clientes"
)

type ContaCorrente struct {
	Titular       clientes.Titular
	NumeroAgencia int
	NumeroConta   int
	saldo         float64
}

func (c *ContaCorrente) Sacar(valor float64) string {
	var podeSacar = valor > 0 && valor <= c.saldo
	if podeSacar {
		c.saldo -= valor
		return "Saque realizado com sucesso"
	} else {
		return "Saldo insuficiente"
	}
}

func (c *ContaCorrente) Depositar(valorDeposito float64) (string, float64) {
	var podeDepositar = valorDeposito > 0
	if podeDepositar {
		c.saldo += valorDeposito
		return "Depósito realizado com sucesso", c.saldo
	} else {
		return "Valor incorreto, informe valor válido.", c.saldo
	}
}
func (c *ContaCorrente) Transferir(valorTransferencia float64, contaDestino *ContaCorrente) bool {
	if valorTransferencia < c.saldo && valorTransferencia > 0 {
		c.saldo -= valorTransferencia
		contaDestino.Depositar(valorTransferencia)
		return true
	} else {
		return false
	}

}

func (c *ContaCorrente) ObterSaldo() float64 {
	return c.saldo
}
