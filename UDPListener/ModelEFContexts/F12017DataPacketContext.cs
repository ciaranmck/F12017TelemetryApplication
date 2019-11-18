using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UDPListener.Models;

namespace UDPListener.ModelsEFContexts
{
    public class F12017DataPacketContext : DbContext
    {
        public F12017DataPacketContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<F12017DataPacket> F12017DataPackets { get; set; }
    }
}