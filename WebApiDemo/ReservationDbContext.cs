using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReservationWebAPI
{
    public class ReservationDbContext : DbContext
    {
        private IConfiguration configuration;

        public ReservationDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=POSEIDON\SQLEXPRESS;Initial Catalog=APIDB;MultipleActiveResultSets=True;Persist Security Info=True;User ID=sa;Password=master";

            optionsBuilder
                .UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Reservation> Reservations { get; set; }
    }


    [Table("Reservations")]
    public class Reservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }

        public string Name { get; set; }

        public string StartLocation { get; set; }

        public string EndLocation { get; set; }

        public bool IsActive { get; set; }
    }

}
