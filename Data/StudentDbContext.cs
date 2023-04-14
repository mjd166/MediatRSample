using MediatRApisample.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatRApisample.Data
{
    public class StudentDbContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public StudentDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("ConStr"));

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<StudentDetails> Students { get; set; }
    }
}
