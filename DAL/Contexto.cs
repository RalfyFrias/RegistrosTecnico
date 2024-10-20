using Microsoft.EntityFrameworkCore;
using RegistroTecnicos.Models;

namespace RegistroTecnicos.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
          : base(options) { }
    public DbSet<Tecnicos> Tecnicos { get; set; }
    public DbSet<Tipostecnicos> Tipostecnicos { get; set; }
    public DbSet<Clientes> Cliente { get; set; }
    public DbSet<Trabajos> Trabajos { get; set; }
    public DbSet<Prioridades> Prioridad { get; set; }
    public DbSet<Articulos> Articulos { get; set; }
    public DbSet<TrabajosDetalle> TrabajosDetalle { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Articulos>().HasData(new List<Articulos>()
        {
          new Articulos() { ArticuloId = 1, Descripcion = "Turbo", Costo = 120, Precio = 170, Existencia = 55 },
          new Articulos() { ArticuloId = 2, Descripcion = "Aros de Aluminio", Costo = 90, Precio = 130, Existencia = 45 },
          new Articulos() { ArticuloId = 3, Descripcion = "Faros LED", Costo = 220, Precio = 320, Existencia = 25 },
          new Articulos() { ArticuloId = 4, Descripcion = "Neumáticos", Costo = 280, Precio = 450, Existencia = 18 },
          new Articulos() { ArticuloId = 5, Descripcion = "Amortiguadores", Costo = 60, Precio = 100, Existencia = 30 },
          new Articulos() { ArticuloId = 6, Descripcion = "Filtro de Aire", Costo = 20, Precio = 35, Existencia = 75 },
          new Articulos() { ArticuloId = 7, Descripcion = "Aceite de Motor", Costo = 15, Precio = 25, Existencia = 65 },
          new Articulos() { ArticuloId = 8, Descripcion = "Batería", Costo = 120, Precio = 200, Existencia = 35 },
          new Articulos() { ArticuloId = 9, Descripcion = "Radio Multimedia", Costo = 70, Precio = 120, Existencia = 28 },
          new Articulos() { ArticuloId = 10, Descripcion = "Altavoces para Auto", Costo = 60, Precio = 100, Existencia = 45 },
          new Articulos() { ArticuloId = 11, Descripcion = "Inyectores de Combustible", Costo = 350, Precio = 600, Existencia = 12 },
          new Articulos() { ArticuloId = 12, Descripcion = "Sistema de Escape", Costo = 900, Precio = 1300, Existencia = 10 },
          new Articulos() { ArticuloId = 13, Descripcion = "Espejos Retrovisores", Costo = 350, Precio = 550, Existencia = 18 },
          new Articulos() { ArticuloId = 14, Descripcion = "Sistema de Frenos ABS", Costo = 120, Precio = 170, Existencia = 22 },
         new Articulos() { ArticuloId = 15, Descripcion = "Llantas Todo Terreno", Costo = 220, Precio = 350, Existencia = 20 }

       });
    }
}
