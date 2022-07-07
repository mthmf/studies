using AutoMapper;
using ItemService.Data;
using ItemService.Dtos;
using ItemService.Models;
using System.Text.Json;

namespace ItemService.EventProcessor
{
    public class ProcessaEvento : IProcessaEvento
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public ProcessaEvento(IMapper mapper, IServiceScopeFactory serviceScopeFactory)
        {
            _mapper = mapper;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public void Processa(string mensagem)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var itemRepository = scope.ServiceProvider.GetRequiredService<IItemRepository>();
            var restauranteReadDto = JsonSerializer.Deserialize<RestauranteReadDto>(mensagem);

            var restaurante = _mapper.Map<Restaurante>(restauranteReadDto);
            if (!itemRepository.ExisteRestauranteExterno(restaurante.Id))
            {
                itemRepository.CreateRestaurante(restaurante);
                itemRepository.SaveChanges();
            }

        }
    }
}
