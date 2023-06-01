package routes

import (
	"contas/src/app-web/controllers"
	"net/http"
)

func CarregaRotas() {
	http.HandleFunc("/", controllers.Index)
	http.HandleFunc("/novo", controllers.NovoProduto)
	http.HandleFunc("/insert", controllers.InsereProduto)
	http.HandleFunc("/delete", controllers.Delete)
	http.HandleFunc("/edit", controllers.Edit)
	http.HandleFunc("/update", controllers.UpdateProduto)

}
