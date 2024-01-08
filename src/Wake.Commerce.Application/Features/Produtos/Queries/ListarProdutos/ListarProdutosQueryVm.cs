namespace Wake.Commerce.Application.Features.Produtos.Queries.ListarProdutos
{
    public class ListarProdutosQueryVm
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public short Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}
