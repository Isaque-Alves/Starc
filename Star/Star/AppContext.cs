using Microsoft.EntityFrameworkCore;
using Star.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star
{
    public class AppContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Componente> Componentes { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<TipoComponente> TipoComponentes { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<ComponenteGrupo> ComponenteGrupos { get; set; }

        public AppContext(DbContextOptions o) : base(o)
        {

        }
    }
}
