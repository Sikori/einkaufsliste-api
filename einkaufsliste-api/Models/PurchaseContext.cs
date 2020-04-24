using System;
using Microsoft.EntityFrameworkCore;

namespace einkaufsliste_api.Models
{
    public class PurchaseContext : DbContext
    {
        public PurchaseContext(DbContextOptions<PurchaseContext> options) : base(options)
        {
        }

        public DbSet<PurchaseItem> PurchaseItems { get; set; }
    }
}
