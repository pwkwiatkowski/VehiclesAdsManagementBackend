using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehiclesAdsManagement.Models
{
    public class VehicleContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {
        }
    }
}
