package main

import (
	"contas/src/app-web/routes"
	"net/http"

	_ "github.com/lib/pq"
)

func main() {
	routes.CarregaRotas()
	http.ListenAndServe(":8000", nil)
}
