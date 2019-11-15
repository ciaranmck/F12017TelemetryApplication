using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UDPListener.Interfaces;

namespace UDPListener.Models
{
    public class DataPacketContext : DbContext
    {
        public DataPacketContext(DbContextOptions<DataPacketContext> options)
            : base(options)
        {

        }

        public DbSet<IDataPacket> DataPackets { get; set; }
    }
}