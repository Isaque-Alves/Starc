﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star.Models
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<Usuario> Usuarios { get; set; }
    }
}
