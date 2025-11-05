using System;

namespace ProductCRUD.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
