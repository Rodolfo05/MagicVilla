using MagicVilla_API.Modelos;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MagicVilla_API.Datos
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Nombre="Vira",
                    Detalle="detalle 1",
                    ImagenUrl="",
                    Ocupantes=10,
                    MetrosCuadrados=200,
                    Tarifa=3000,
                    Amenidad="",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                },
                new Villa()  {
                Id = 2,
                    Nombre = "Monstaf",
                    Detalle = "detalle 2",
                    ImagenUrl = "",
                    Ocupantes = 20,
                    MetrosCuadrados = 2330,
                    Tarifa = 2000,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                }
             );
        }

    }
}
