using APIProjectBackend.Entities;
using Microsoft.EntityFrameworkCore;


namespace APIProjectBackend.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Proyecto)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.IdProyecto)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict); 

            
        }
    }
}
