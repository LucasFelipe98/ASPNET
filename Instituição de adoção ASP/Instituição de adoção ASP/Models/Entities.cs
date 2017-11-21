using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Instituição_de_adoção_ASP.Models
{
    public class Entities : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Instituição> Instituição { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}