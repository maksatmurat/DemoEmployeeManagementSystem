
using BaseLibraty.Entities;
using BaseLibraty.Responses;
using Microsoft.EntityFrameworkCore;
using ServerLibrary.Data;
using ServerLibrary.Repositories.Contracts;

namespace ServerLibrary.Repositories.Implementations;

public class VacationRepository(AppDbContext appDbContext) : IGenericRepositoryInterface<Vacation>
{
    public async Task<GeneralResponse> DeleteById(int id)
    {
        var item = await appDbContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == id);
        if (item is null) return NotFound();

        appDbContext.Vacations.Remove(item);
        return await Commit().ContinueWith(_ => Success());
    }
    public async Task<List<Vacation>> GetAll() => await appDbContext
        .Vacations
        .AsNoTracking().Include(t => t.VacationType)
        .ToListAsync();

    public async Task<Vacation> GetById(int id) =>
        await appDbContext.Vacations.FirstOrDefaultAsync(eid => eid.EmployeeId == id);

    public async Task<GeneralResponse> Insert(Vacation item)
    {
        appDbContext.Vacations.Add(item);
        return await Commit().ContinueWith(_ => Success());
    }

    public async Task<GeneralResponse> Update(Vacation item)
    {
        var obj = await appDbContext.Vacations
        .FirstOrDefaultAsync(eid => eid.EmployeeId == item.EmployeeId);
        if (obj is null) return NotFound();
        obj.StartDate = item.StartDate;
        obj.NumberOfDays = item.NumberOfDays;
        obj.VacationTypeId = item.VacationTypeId;
        return await Commit().ContinueWith(_ => Success());
    }


    private async Task Commit() => await appDbContext.SaveChangesAsync();
    private static GeneralResponse NotFound() => new(false, "Sorry Vacation is not found");
    private static GeneralResponse Success() => new(true, "Process completed");
}

