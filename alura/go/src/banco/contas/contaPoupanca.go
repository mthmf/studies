package contas

import "contas/src/banco/clientes"

type ContaPoupanca struct {
	Titular                              clientes.Titular
	NumeroAgencia, NumeroConta, Operacao int
	saldo                                float64
}

func (c *ContaPoupanca) Sacar(valor float64) string {
	var podeSacar = valor > 0 && valor <= c.saldo
	if podeSacar {
		c.saldo -= valor
		return "Saque realizado com sucesso"
	} else {
		return "Saldo insuficiente"
	}
}

func (c *ContaPoupanca) Depositar(valorDeposito float64) (string, float64) {
	var podeDepositar = valorDeposito > 0
	if podeDepositar {
		c.saldo += valorDeposito
		return "Depósito realizado com sucesso", c.saldo
	} else {
		return "Valor incorreto, informe valor válido.", c.saldo
	}
}

func (c *ContaPoupanca) ObterSaldo() float64 {
	return c.saldo
}
