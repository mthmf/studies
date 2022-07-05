using RestauranteService.Dtos;

namespace RestauranteService.ItemHttpClient
{
    public interface IItemServiceHttpClient
    {
        public void EnviaRestaurante(RestauranteReadDto dto);
    }
}
