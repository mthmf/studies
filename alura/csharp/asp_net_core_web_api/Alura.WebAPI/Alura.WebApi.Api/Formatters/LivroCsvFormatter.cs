using Alura.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.Api.Formatters
{
    public class LivroCsvFormatter : TextOutputFormatter
    {

        public LivroCsvFormatter()
        {
            var csvMedia = MediaTypeHeaderValue.Parse("text/csv");
            var appCsvMedia = MediaTypeHeaderValue.Parse("application/csv");
            SupportedMediaTypes.Add(csvMedia);
            SupportedMediaTypes.Add(appCsvMedia);
            SupportedEncodings.Add(Encoding.UTF8);

        }

        protected override bool CanWriteType(Type type)
        {
            return type == typeof(LivroApi);
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var livroCsv = "";
            if (context.Object is LivroApi)
            {
                var livro = context.Object as LivroApi;
                livroCsv = $"{livro.Titulo};{livro.Subtitulo};{livro.Autor};{livro.Lista}";
            }
            using (var escritor = context.WriterFactory(context.HttpContext.Response.Body, selectedEncoding))
            {
                return escritor.WriteAsync(livroCsv);
            }

        }
    }
}
