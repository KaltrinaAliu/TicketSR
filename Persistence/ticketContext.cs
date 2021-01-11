using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ticketContext: DbContext
    {
        public ticketContext(DbContextOptions options):base(options)
        {
        }
        public DbSet<Value> Values { get; set; }
        public DbSet<Company> Companies  { get; set; }
        public DbSet<TicketType> TicketTypes  { get; set; }


        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<Value>()
            .HasData(
                new Value{Id=1, Name="103"},
                new Value{Id=2, Name="102"},
                new Value{Id=3, Name="101"}
            );
        }
    }
}