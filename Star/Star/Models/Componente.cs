using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Star.Models
{
    public class Componente
    {
        public int Id { get; set; }
        [Required]
        public int CadastroId { get; set; }
        [Required]
        public int TipoComponenteId { get; set; }
        [Required]
        public string Nome { get; set; }
        public bool Status { get; set; }
        public bool Ativo { get; set; }
        public Cadastro Cadastro { get; set; }
        public TipoComponente TipoComponente { get; set; }

        [NotMapped]
        public IEnumerable<ComponenteGrupo> ComponenteGrupos { get; set; }

        public IEnumerable<Registro> Registros { get; set; }
    }
}
