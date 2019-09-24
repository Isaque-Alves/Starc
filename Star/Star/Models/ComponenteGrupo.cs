using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star.Models
{
    public class ComponenteGrupo
    {
        public int Id { get; set; }
        
        public int GrupoId { get; set; }
        
        public int TipoComponenteId { get; set; }
        public bool Ativo { get; set; }

        public Componente Componente { get; set; }
        public Grupo Grupo { get; set; }
    }
}
