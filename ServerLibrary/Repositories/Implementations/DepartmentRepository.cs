using BaseLibraty.Entities;
using BaseLibraty.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;
using System;

namespace ServerLibrary.Repositories.Implementations;
public class DepartmentRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Department>
{
    public async Task<GeneralResponse> DeleteById(int id)
    {
        var dep = await appDbContext.Departments.FindAsync(id);
        if (dep is null) return NotFound();

        appDbContext.Departments.Remove(dep);
        return await Commit().ContinueWith(_ => Success());
    }

    public async Task<List<Department>> GetAll() => await appDbContext.Departments
        .AsNoTracking()
        .Include(gd=>gd.GeneralDepartment)
        .ToListAsync();

    public async Task<Department> GetById(int id)
    {
        var entity = await appDbContext.Departments.FindAsync(id);
        return entity is null ? throw new InvalidOperationException($"Department with ID {id} not found.") : entity;
    }

    public async Task<GeneralResponse> Insert(Department item)
    {
        if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Department already added");
        appDbContext.Departments.Add(item);
        return await Commit().ContinueWith(_ => Success());
   }



    public async Task<GeneralResponse> Update(Department item)
    {
        var dep = await appDbContext.Departments.FindAsync(item.Id);
        if (dep is null) return NotFound();
        dep.GeneralDepartmentId = item.GeneralDepartmentId;
        dep.Name = item.Name;
        return await Commit().ContinueWith(_ => Success());
    }
    private async Task Commit() => await appDbContext.SaveChangesAsync();
    private static GeneralResponse NotFound() => new(false, "Sorry department not fount");
    private static GeneralResponse Success() => new(true, "Process completed");
    private async Task<bool> CheckName(string name)
    {
        var item = await appDbContext.Departments.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        return item is null;
    }
}
