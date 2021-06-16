using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.WebApi.Api.Modelos
{
    public class ErroResponse
    {
        public int Code { get; set; }
        public string Mensagem { get; set; }
        public ErroResponse InnerError { get; set; }
        public string[] Detalhes { get; set; }

        public static ErroResponse From(Exception ex)
        {
            if(ex == null)
            {
                return null;
            }
            return new ErroResponse
            {
                Code = ex.HResult,
                Mensagem = ex.Message,
                InnerError = ErroResponse.From(ex.InnerException)

            };
        }

        public static ErroResponse FromModelState(ModelStateDictionary model)
        {
            var erros = model.Values.SelectMany(f => f.Errors);
            return new ErroResponse
            {
                Code = 100,
                Mensagem = "Houve erro no envio da requisição",
                Detalhes = erros.Select(e => e.ErrorMessage).ToArray()

            };
        }
    }
}
