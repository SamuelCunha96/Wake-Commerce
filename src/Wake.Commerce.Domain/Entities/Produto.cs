using Wake.Commerce.Domain.Base;

namespace Wake.Commerce.Domain.Entities
{
    public class Produto : EntidadeBase
    {
        public string Nome { get; set; } = string.Empty;
        public short Estoque { get; set; }
        public decimal Valor { get; set; }
    }
}
