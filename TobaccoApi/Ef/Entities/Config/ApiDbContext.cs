using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TobaccoApi.Entities;

namespace TobaccoApi.Ef.Entities.Config
{
    public class ApiDbContext:DbContext
    {
        public DbSet<Leaf> Leafs { get; set; }
        public DbSet<LeafDetail> LeafDetails { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {


        }
       

    }
}
