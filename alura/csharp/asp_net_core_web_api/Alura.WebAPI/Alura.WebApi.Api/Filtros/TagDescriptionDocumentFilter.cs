﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.WebApi.Api.Filtros
{
    public class TagDescriptionDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Tags = new[] {
                new OpenApiTag { Name = "Livros", Description = "Consulta e mantém os livros." },
                new OpenApiTag { Name = "Listas", Description = "Consulta as listas de leitura." }
            };
        }
    }
}
