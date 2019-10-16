using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        public string ConfirmaSenha { get; set; }
        [Required]
        public string Nome { get; set; }
        public bool Status { get; set; }


        [NotMapped]
        public string NomeCadastro { get; set; }


        public TipoUsuario TipoUsuario { get; set; }
        public Cadastro Cadastro { get; set; }

        public IEnumerable<Registro> Registros { get; set; }



    }
}
