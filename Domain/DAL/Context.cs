using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DAL
{
    public class Context : DbContext
    {
        DbSet<Price> Prices { get; set; }
        DbSet<Person> People { get; set; }
        DbSet<PersonType> PersonTypes { get; set; }
        DbSet<AvailableService> AvailableServices { get; set; }
        DbSet<ServiceType> ServiceTypes { get; set; }
        DbSet<Visit> Visits { get; set; }

        public Context()
        {
            sqlServer = ConfigurationHelper.Configuration.GetConnetcionString("SQLServer");
        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        private string sqlServer; // readonly ?
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (sqlServer != null)
            {
                optionsBuilder.UseSqlServer(sqlServer);
            }
        }
    }
}
