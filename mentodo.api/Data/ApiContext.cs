using Mentodo.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Mentodo.Api.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
             : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

    }

}
