using RestauranteService.Dtos;

namespace RestauranteService.RabbitMqClient
{
    public interface IRabbitMqClient
    {
        void Publicar(RestauranteReadDto dto);
    }
}
