using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace EFCoreCodeFirstSample.Models
{
    public class EmployeeContext : DbContext
    {

        protected readonly IHostingEnvironment hostingEnvironment;

        public EmployeeContext(DbContextOptions<EmployeeContext> options, IHostingEnvironment hostingEnvironment)
            : base(options)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var path = hostingEnvironment.ContentRootPath;
            var path1 = Path.Combine(path, "zaposleni.json");

            var jsonString = File.ReadAllText(path1);
            var list = JsonConvert.DeserializeObject<List<Employee>>(jsonString);
            modelBuilder.Entity<Employee>().HasData(list);                             //seed data
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
