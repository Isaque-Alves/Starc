using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public int CadastroId { get; set; }
        [Required]
        public int TipoUsuarioId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Nome { get; set; }
        public bool Status { get; set; }

        public TipoUsuario TipoUsuario { get; set; }
        public Cadastro Cadastro { get; set; }

        public IEnumerable<Registro> Registros { get; set; }



    }
}
