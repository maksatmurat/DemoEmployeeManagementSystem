using BaseLibraty.Entities;
using BaseLibraty.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations;

public class CityRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<City>
{

    public async Task<GeneralResponse> DeleteById(int id)
    {
        var cnt = await appDbContext.Cities.FindAsync(id);
        if (cnt is null) return NotFound();

        appDbContext.Cities.Remove(cnt);
        return await Commit().ContinueWith(_ => Success());
    }
    public async Task<List<City>> GetAll() => await appDbContext.Cities.ToListAsync();

    public async Task<City> GetById(int id)
    {
        var entity = await appDbContext.Cities.FindAsync(id);
        return entity is null ? throw new InvalidOperationException($"City with ID {id} not found.") : entity;
    }

    public async Task<GeneralResponse> Insert(City item)
    {
        if (!await CheckName(item.Name!)) return new GeneralResponse(false, "City already added");
        appDbContext.Cities.Add(item);
        return await Commit().ContinueWith(_ => Success());
    }



    public async Task<GeneralResponse> Update(City item)
    {
        var cnt = await appDbContext.Cities.FindAsync(item.Id);
        if (cnt is null) return NotFound();
        cnt.Name = item.Name;
        return await Commit().ContinueWith(_ => Success());
    }

    private async Task Commit() => await appDbContext.SaveChangesAsync();
    private static GeneralResponse NotFound() => new(false, "Sorry City not fount");
    private static GeneralResponse Success() => new(true, "Process completed");
    private async Task<bool> CheckName(string name)
    {
        var item = await appDbContext.Cities.FirstOrDefaultAsync(x => x.Name!.ToLower().Equals(name.ToLower()));
        return item is null;
    }
}