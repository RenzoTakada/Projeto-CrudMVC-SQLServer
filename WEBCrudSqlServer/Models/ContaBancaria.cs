using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBCrudSqlServer.Models
{
    [Table("Conta")]
    public class ContaBancaria
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }
        [Column("Agencia")]
        [Display(Name = "Agencia")]
        public int Agencia { get; set; }
        [Column("NumeroDaConta")]
        [Display(Name = "Numero da conta")]
        public int NumeroDaConta { get; set; }

    }
}
