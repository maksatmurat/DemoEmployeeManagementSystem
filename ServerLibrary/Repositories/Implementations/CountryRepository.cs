using BaseLibraty.Entities;
using BaseLibraty.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations;

public class CountryRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Country>
{

    public async Task<GeneralResponse> DeleteById(int id)
    {
        var cnt = await appDbContext.Countries.FindAsync(id);
        if (cnt is null) return NotFound();

        appDbContext.Countries.Remove(cnt);
        return await Commit().ContinueWith(_ => Success());
    }
    public async Task<List<Country>> GetAll() => await appDbContext.Countries.ToListAsync();

    public async Task<Country> GetById(int id)
    {
        var entity = await appDbContext.Countries.FindAsync(id);
        return entity is null ? throw new InvalidOperationException($"Country with ID {id} not found.") : entity;
    }

    public async Task<GeneralResponse> Insert(Country item)
    {
        if (!await CheckName(item.Name!)) return new GeneralResponse(false, "Country already added");
        appDbContext.Countries.Add(item);
        return await Commit().ContinueWith(_ => Success());
    }



    public async Task<GeneralResponse> Update(Country item)
    {
        var cnt = await appDbContext.Countries.FindAsync(item.Id);
        if (cnt is null) return NotFound();
        cnt.Name = item.Name;
        return await Commit().ContinueWith(_ => Success());
    }

    private async Task Commit() => await appDbContext.SaveChangesAsync();
    private static GeneralResponse NotFound() => new(false, "Sorry Country not fount");
    private static GeneralResponse Success() => new(true, "Process completed");
    private async Task<bool> CheckName(string name)
    {
        var item = await appDbContext.Countries.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        return item is null;
    }
}