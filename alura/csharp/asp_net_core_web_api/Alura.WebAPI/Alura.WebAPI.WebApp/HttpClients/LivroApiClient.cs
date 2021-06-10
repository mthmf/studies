﻿using Alura.ListaLeitura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lista = Alura.ListaLeitura.Modelos.ListaLeitura;

namespace Alura.WebAPI.WebApp.HttpClients
{
    public class LivroApiClient
    {
        private readonly HttpClient _httpClient;
        public LivroApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Lista> GetListaLeitura(TipoListaLeitura tipo)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"listaleitura/{tipo}");
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsAsync<Lista>();
        }

        public async Task<byte[]> GetCapaLivroApiAsync(int id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"livros/{id}/capa");
            responseMessage.EnsureSuccessStatusCode();
            return  await responseMessage.Content.ReadAsByteArrayAsync();
        }

        public async Task<LivroApi> GetLivroApiAsync(int id)
        {
            HttpResponseMessage responseMessage = await _httpClient.GetAsync($"livros/{id}");
            responseMessage.EnsureSuccessStatusCode();
            return await responseMessage.Content.ReadAsAsync<LivroApi>();
        }

        public async Task DeleteLivroAsync(int id)
        {
            HttpResponseMessage responseMessage = await _httpClient.DeleteAsync($"livros/{id}");
            responseMessage.EnsureSuccessStatusCode();
        }
    }
}
