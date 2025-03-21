
using EvaluationCrm.Models.entity;
using Microsoft.EntityFrameworkCore;

namespace EvaluationCrm.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    
    public DbSet<Role> Roles { get; set; }
    
    //public DbSet<Role> Roles { get; set; }
    // Ajoute d'autres DbSets pour d'autres entités
}