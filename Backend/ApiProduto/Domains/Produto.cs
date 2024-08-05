using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProduto.Domains
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public Guid IdProduct { get; set; } = Guid.NewGuid();

        [Column(TypeName ="VARCHAR(100)")]
        public string? Name { get; set; }

        [Column(TypeName = "DECIMAL(12,2)")]
        public decimal Price{ get; set; }


    }
}
