using BaseLibraty.Entities;
using BaseLibraty.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations;

public class BranchRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Branch>
{
    public async Task<GeneralResponse> DeleteById(int id)
    {
        var brc = await appDbContext.Branches.FindAsync(id);
        if (brc is null) return NotFound();

        appDbContext.Branches.Remove(brc);
        return await Commit().ContinueWith(_ => Success());
    }
    public async Task<List<Branch>> GetAll() => await appDbContext.Branches.ToListAsync();

    public async Task<Branch> GetById(int id)
    {
        var entity = await appDbContext.Branches.FindAsync(id);
        return entity is null ? throw new InvalidOperationException($"Branch with ID {id} not found.") : entity;
    }

    public async Task<GeneralResponse> Insert(Branch item)
    {
        if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Branch already added");
        appDbContext.Branches.Add(item);
        return await Commit().ContinueWith(_ => Success());
    }



    public async Task<GeneralResponse> Update(Branch item)
    {
        var brc = await appDbContext.Branches.FindAsync(item.Id);
        if (brc is null) return NotFound();
        brc.Name = item.Name;
        return await Commit().ContinueWith(_ => Success());
    }

    private async Task Commit() => await appDbContext.SaveChangesAsync();
    private static GeneralResponse NotFound() => new(false, "Sorry Branch not fount");
    private static GeneralResponse Success() => new(true, "Process completed");
    private async Task<bool> CheckName(string name)
    {
        var item = await appDbContext.Branches.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        return item is null;
    }
}
