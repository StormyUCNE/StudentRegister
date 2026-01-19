using Microsoft.EntityFrameworkCore;
using StudentRegister.Models;

namespace StudentRegister.DAL
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options): base(options) { }

        public DbSet<Estudiantes> Estudiantes { get; set; }
    }
}