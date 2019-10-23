using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Star.Models
{
    public class Grupo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        public DateTime HorarioInicial { get; set; }

        [NotMapped]
        public String[] DiasSemana { get; set; }
        [NotMapped]
        public int?[] Componentes { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HorarioFinal { get; set; }
        public String Descricao { get; set; }
        public bool Segunda { get; set; }
        public bool Terca { get; set; }
        public bool Quarta { get; set; }
        public bool Quinta { get; set; }
        public bool Sexta { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public bool Ativo { get; set; }

        public IEnumerable<ComponenteGrupo> ComponenteGrupos { get; set; }

        public string DiasDaSemanaHabilitados()
        {
            List<string> dias = new List<string>();

            if(Segunda)
            {
                dias.Add("Segunda");
            }
            if (Terca)
            {
                dias.Add("Terça");
            }
            if (Quarta)
            {
                dias.Add("Quarta");
            }
            if (Quinta)
            {
                dias.Add("Quinta");
            }
            if (Sexta)
            {
                dias.Add("Sexta");
            }
            if (Sabado)
            {
                dias.Add("Sábado");
            }
            if (Domingo)
            {
                dias.Add("Domingo");
            }
            return string.Join(", ",dias) ;
        }
    }
}
