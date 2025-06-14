using BaseLibraty.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ServerLibrary.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Employee> Employees { get; set; }
    //General Department / Departments / Branches
    public DbSet<GeneralDepartment> GeneralDepartments { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Branch> Branches { get; set; }

    //Country / City / Town
    public DbSet<Town> Towns { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }

    //Authentication /Role /System Roles 
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<SystemRole> SystemRoles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<RefreshTokenInfo> RefreshTokenInfos { get; set; }

    //Other /Vacation /Sanction /Doctor /Overtime
    public DbSet<Vacantion> Vacantions { get; set; }
    public DbSet<VacantionType> VacantionTypess { get; set; }
    public DbSet<Overtime> Overtimes  {get;set; }
    public DbSet<OvertimeType> OvertimeTypes  {get;set; }
    public DbSet<Sanction> Sanctions  {get;set; }
    public DbSet<SanctionType> SanctionTypes  {get;set; }
    public DbSet<Doctor> Doctor  {get;set; }
}


