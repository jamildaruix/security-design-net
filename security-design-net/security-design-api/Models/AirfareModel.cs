using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Security.Design.Api.Models
{
    [Table("Passagens")]
    public class AirfareModel(int id, string origem, string destino, decimal valor, DateTime validade, bool ativa)
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; } = id;

        [Column(TypeName = "varchar(200)")]
        public string Origem { get; init; } = origem;

        [Column(TypeName = "varchar(200)")]
        public string Destino { get; init; } = destino;

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Valor { get; init; } = valor;
        public DateTime Validade { get; init; } = validade;
        public bool Ativa { get; init; } = ativa;
    }
}
