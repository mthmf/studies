package conta

type ContaCorrente struct {
	Titular       string
	NumeroAgencia int
	NumeroConta   int
	Saldo         float64
}

func (c *ContaCorrente) Sacar(valor float64) string {
	var podeSacar = valor > 0 && valor <= c.Saldo
	if podeSacar {
		c.Saldo -= valor
		return "Saque realizado com sucesso"
	} else {
		return "Saldo insuficiente"
	}
}

func (c *ContaCorrente) Depositar(valorDeposito float64) (string, float64) {
	var podeDepositar = valorDeposito > 0
	if podeDepositar {
		c.Saldo += valorDeposito
		return "Depósito realizado com sucesso", c.Saldo
	} else {
		return "Valor incorreto, informe valor válido.", c.Saldo
	}
}
func (c *ContaCorrente) Transferir(valorTransferencia float64, contaDestino *ContaCorrente) bool {
	if valorTransferencia < c.Saldo && valorTransferencia > 0 {
		c.Saldo -= valorTransferencia
		contaDestino.Depositar(valorTransferencia)
		return true
	} else {
		return false
	}

}
