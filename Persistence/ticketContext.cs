using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ticketContext: IdentityDbContext<AppUser, AppRole, string>
    {
        public ticketContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Value> Values { get; set; }
        public DbSet<Company> Companies  { get; set; }
        public DbSet<TicketType> TicketTypes  { get; set; }


        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            builder.Entity<Value>()
            .HasData(
                new Value{Id=1, Name="103"},
                new Value{Id=2, Name="102"},
                new Value{Id=3, Name="101"}
            );
        }
    }
}