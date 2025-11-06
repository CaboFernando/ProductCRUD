using System;
using System.ComponentModel.DataAnnotations;

namespace ProductCRUD.API.Models
{
    public class ProductCreateDto
    {
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        public string Descricao { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Preco deve ser maior que zero")]        
        public decimal Preco { get; set; }
    }

    public class ProductUpdateDto : ProductCreateDto { }

    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
