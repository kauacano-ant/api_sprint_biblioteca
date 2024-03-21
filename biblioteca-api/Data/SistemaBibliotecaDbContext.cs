using biblioteca_api.Data.Map;
using biblioteca_api.Models;
using Microsoft.EntityFrameworkCore;

namespace biblioteca_api.Data
{
    public class SistemaBibliotecaDbContext : DbContext
    {
        public SistemaBibliotecaDbContext(DbContextOptions<SistemaBibliotecaDbContext> options)
            : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<AutorModel> Autor { get; set; }
        public DbSet<AvaliacaoModel> Avaliacao { get; set; }
        public DbSet<EditoraModel> Editora { get; set; }
        public DbSet<EmprestimoModel> Emprestimo { get; set; }
        public DbSet<LivroModel> Livro { get; set; }
        public DbSet<ReservaModel> Reserva { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new AutorMap());
            modelBuilder.ApplyConfiguration(new AvaliacaoMap());
            modelBuilder.ApplyConfiguration(new EditoraMap());
            modelBuilder.ApplyConfiguration(new EmprestimoMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
