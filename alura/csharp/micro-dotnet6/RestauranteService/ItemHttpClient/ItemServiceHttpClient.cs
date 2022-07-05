using RestauranteService.Dtos;
using System.Text;
using System.Text.Json;

namespace RestauranteService.ItemHttpClient
{
    public class ItemServiceHttpClient : IItemServiceHttpClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public ItemServiceHttpClient(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }
        public async void EnviaRestaurante(RestauranteReadDto dto)
        {
            var conteudo = new StringContent(JsonSerializer.Serialize(dto), encoding: Encoding.UTF8, "application/json");
            await _client.PostAsJsonAsync(_configuration["ItemService"], conteudo);
        }
    }
}
