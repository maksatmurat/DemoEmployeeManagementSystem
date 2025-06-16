using BaseLibraty.Responses;

namespace CLientLibrary.Services.Contracts;

public interface IGenericServiceInterface<T>
{
    Task<List<T>> GetAll(string baseUrl);
    Task<T> GetByIdA(int id,string baseUrl);
    Task<GeneralResponse> Insert(T entit, string baseUrly);
    Task<GeneralResponse> Update(T entity, string baseUrl);
    Task<GeneralResponse> DeleteById(int id, string baseUrl);
}
