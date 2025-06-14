using BaseLibraty.Entities;
using BaseLibraty.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations;

public class TownRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Town>
{

    public async Task<GeneralResponse> DeleteById(int id)
    {
        var cnt = await appDbContext.Towns.FindAsync(id);
        if (cnt is null) return NotFound();

        appDbContext.Towns.Remove(cnt);
        return await Commit().ContinueWith(_ => Success());
    }
    public async Task<List<Town>> GetAll() => await appDbContext.Towns.ToListAsync();

    public async Task<Town> GetById(int id)
    {
        var entity = await appDbContext.Towns.FindAsync(id);
        return entity is null ? throw new InvalidOperationException($"Town with ID {id} not found.") : entity;
    }

    public async Task<GeneralResponse> Insert(Town item)
    {
        if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Town already added");
        appDbContext.Towns.Add(item);
        return await Commit().ContinueWith(_ => Success());
    }



    public async Task<GeneralResponse> Update(Town item)
    {
        var cnt = await appDbContext.Towns.FindAsync(item.Id);
        if (cnt is null) return NotFound();
        cnt.Name = item.Name;
        return await Commit().ContinueWith(_ => Success());
    }

    private async Task Commit() => await appDbContext.SaveChangesAsync();
    private static GeneralResponse NotFound() => new(false, "Sorry Town not fount");
    private static GeneralResponse Success() => new(true, "Process completed");
    private async Task<bool> CheckName(string name)
    {
        var item = await appDbContext.Towns.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        return item is null;
    }
}