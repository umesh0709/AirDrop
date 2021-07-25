using AirDrop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirDrop.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<Item> Items { get; set; }

        public DbSet<CurrentAirdropsData> CryptoInfo { get; set; }

        public DbSet<Tweets> Tweets { get; set; }

     //   public DbSet<TrendingCoinsOnCoinGecko> TrendingCoins {get; set;}

        public DbSet<Item> Item { get; set; }

    }
}
