﻿using Alura.ListaLeitura.Modelos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;

namespace Alura.WebAPI.WebApp.HttpClients
{
    public class LivroApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly AuthApiClient _authClient;
        private readonly IHttpContextAccessor _accessor;

        public LivroApiClient(HttpClient httpClient, AuthApiClient authApiClient, IHttpContextAccessor accessor)
        {
            _httpClient = httpClient;
            _authClient = authApiClient;
            _accessor = accessor;
        }

        private void AddBearerToken()
        {
            var token = _accessor.HttpContext.User.Claims.First(c => c.Type == "Token").Value;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<Lista> GetListaLeitura(TipoListaLeitura tipo)
        {
            AddBearerToken();
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"listasleitura/{tipo}");
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsAsync<Lista>();
        }

        public async Task<byte[]> GetCapaLivroApiAsync(int id)
        {
            AddBearerToken();
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"livros/{id}/capa");
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsByteArrayAsync();
        }

        public async Task<LivroApi> GetLivroApiAsync(int id)
        {
            AddBearerToken();
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"livros/{id}");
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsAsync<LivroApi>();
        }

        public async Task DeleteLivroAsync(int id)
        {
            AddBearerToken();
            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync($"livros/{id}");
            responseMessage.EnsureSuccessStatusCode();
        }

        public async Task PostLivroAsync(LivroUpload model)
        {
            AddBearerToken();
            HttpContent content = CreateMultipartFormData(model);
            HttpResponseMessage responseMessage = await _httpClient.PostAsync("livros", content);
            responseMessage.EnsureSuccessStatusCode();
        }

        public async Task PutLivroAsync(LivroUpload model)
        {
            AddBearerToken();
            HttpContent content = CreateMultipartFormData(model);
            HttpResponseMessage responseMessage = await _httpClient.PutAsync("livros", content);
            responseMessage.EnsureSuccessStatusCode();
        }

        private string EnvolveAspas(string valor)
        {
            return $"\"{valor}\"";
        }
        private HttpContent CreateMultipartFormData(LivroUpload model)
        {
            var content = new MultipartFormDataContent();
            if(model.Id > 0)
            {
                content.Add(new StringContent(model.Id.ToString()), EnvolveAspas("id"));
            }

            content.Add(new StringContent(model.Titulo), EnvolveAspas("titulo"));
            content.Add(new StringContent(model.Lista.ParaString()), EnvolveAspas("lista"));

            if (!string.IsNullOrEmpty(model.Subtitulo))
            {
                content.Add(new StringContent(model.Subtitulo), EnvolveAspas("subtitulo"));
            }

            if (!string.IsNullOrEmpty(model.Resumo))
            {
                content.Add(new StringContent(model.Resumo), EnvolveAspas("resumo"));
            }

            if (!string.IsNullOrEmpty(model.Autor))
            {
                content.Add(new StringContent(model.Autor), EnvolveAspas("autor"));
            }

            if(model.Capa != null)
            {
                var imagemContent = new ByteArrayContent(model.Capa.ConvertToBytes());
                imagemContent.Headers.Add("content-type", "image/png");
                content.Add(imagemContent, EnvolveAspas("capa"), EnvolveAspas("nome-do-arquivo.png"));

            }

            return content;
        }
    }
}
