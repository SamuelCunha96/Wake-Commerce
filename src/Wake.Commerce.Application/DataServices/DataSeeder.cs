using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;

namespace Wake.Commerce.Application.DataServices
{
    public class DataSeeder
    {
        private readonly IProdutoRepository _produtoRepository;

        public DataSeeder(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task SeedAsync() 
        {
            if (!_produtoRepository.GetQuery().Any())
            {
                var produtosIniciais = new List<Produto> {
                    new Produto { Id = 1, Nome = "Produto C", Estoque = 10, Valor = 50 },
                    new Produto { Id = 2, Nome = "Produto A", Estoque = 20, Valor = 40 },
                    new Produto { Id = 3, Nome = "Produto B", Estoque = 30, Valor = 30 },
                    new Produto { Id = 4, Nome = "Produto D", Estoque = 40, Valor = 20 },
                    new Produto { Id = 5, Nome = "Produto E", Estoque = 50, Valor = 10 }
                };

                await _produtoRepository.AddAsync(produtosIniciais);
            }
        }
    }
}
