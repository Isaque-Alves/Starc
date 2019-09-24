using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star.Models
{
    public class Registro
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ComponenteId { get; set; }
        public DateTime DataHora { get; set; }
        public bool Status { get; set; }

        public Componente Componente { get; set; }
        public Usuario Usuario { get; set; }

    }
}
