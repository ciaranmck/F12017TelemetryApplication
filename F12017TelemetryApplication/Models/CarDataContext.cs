using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace F1TelemetryApplication.Models
{
    public class CarDataContext : DbContext
    {
        public CarDataContext(DbContextOptions<CarDataContext> options)
            : base(options)
        {
        }

        public DbSet<CarData> CarDatas { get; set; }
    }
}
