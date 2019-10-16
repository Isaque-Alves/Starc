using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace STARC.Model
{
    class Usuario
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int CadastroId { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

    }
}
