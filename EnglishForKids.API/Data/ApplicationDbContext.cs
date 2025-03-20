using EnglishForKids.API.Entities.Models;
using HuloToys_Service.Models.Course;
using Microsoft.EntityFrameworkCore;

namespace HuloToys_Service.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<QuizResult> QuizResult { get; set; }
        public DbSet<QuizAnswer> QuizAnswer { get; set; }
        public DbSet<Quiz> Quiz { get; set; }
        public DbSet<Client> Clients { get; set; }
       
    }
}
