using Microsoft.EntityFrameworkCore;
using TodoList.API.Entities;

namespace TodoList.API.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options) 
        {

        }

        public DbSet<Topic> Topics { get; set; } = null!;

        public DbSet<Todo> Todos { get; set; } = null!;
    }
}
