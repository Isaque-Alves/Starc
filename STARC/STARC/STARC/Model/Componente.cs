using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace STARC.Model
{
    class Componente
    {
        [PrimaryKey]
        public int Id { get; set; }

        public String Nome { get; set; }

        public bool Status { get; set; }
    }
}
