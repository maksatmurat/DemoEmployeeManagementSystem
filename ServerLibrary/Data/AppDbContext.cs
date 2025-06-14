using BaseLibraty.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ServerLibrary.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Town> Towns { get; set; }
<<<<<<< Updated upstream
=======
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }

    //Authentication /Role /System Roles 
>>>>>>> Stashed changes
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<SystemRole> SystemRoles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }

}


