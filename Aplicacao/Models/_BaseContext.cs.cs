using System.Data.Entity;

namespace Aplicacao.Models
{
    public class BaseContext : DbContext
    {
        public DbSet<GitHubApiItem> GitHubApiItems { get; set; }
        public DbSet<GitHubApiOwner> GitHubApiOwners { get; set; }

        public BaseContext(): base("teste_connection_string") 
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}