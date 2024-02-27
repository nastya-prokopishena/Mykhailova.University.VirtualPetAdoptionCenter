using Microsoft.EntityFrameworkCore;
using VirtualPetAdoptionCenter.Models.Account;

namespace VirtualPetAdoptionCenter.Core;

public class VirtualPetAdoptionCenterDbContext : DbContext
{
    public VirtualPetAdoptionCenterDbContext(DbContextOptions<VirtualPetAdoptionCenterDbContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("YourConnectionString"); // Replace YourConnectionString with your actual connection string
        }
    }

    public DbSet<UserModel> Users { get; set; }
}