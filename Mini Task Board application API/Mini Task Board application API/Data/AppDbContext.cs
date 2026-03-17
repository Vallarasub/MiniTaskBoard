using Microsoft.EntityFrameworkCore;
using Mini_Task_Board_application_API.Models;

namespace Mini_Task_Board_application_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}