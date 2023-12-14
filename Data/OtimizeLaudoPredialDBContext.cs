using Microsoft.EntityFrameworkCore;
using OtimizeLaudoPredial.Data.Map;
using OtimizeLaudoPredial.Models;

namespace OtimizeLaudoPredial.Data
{

    public class OtimizeLaudoPredialDBContext : DbContext
    {
        public OtimizeLaudoPredialDBContext(DbContextOptions<OtimizeLaudoPredialDBContext> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
        public object IUsuarioRepositorio { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
           
        }

    }
   
}
