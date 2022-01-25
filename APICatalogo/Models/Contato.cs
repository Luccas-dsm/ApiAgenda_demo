using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models
{
    [Table("Contatos")]
    public class Contato 
    {
        [Key]
        public int ContatoId { get; set; }

        [Required]
        [StringLength(80)]
        public string Nome { get; set; }

        
        [StringLength(300)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(14)]
        public string Telefone { get; set; }

      
     
    }
}
