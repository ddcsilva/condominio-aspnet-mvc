using Microsoft.EntityFrameworkCore;

namespace GerenciadorCondominios.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
    }
}
