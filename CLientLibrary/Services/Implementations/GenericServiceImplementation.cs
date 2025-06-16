using BaseLibraty.Responses;
using CLientLibrary.Helpers;
using CLientLibrary.Services.Contracts;
using System.Net.Http.Json;
namespace CLientLibrary.Services.Implementations;

public class GenericServiceImplementation<T>(GetHttpClient getHttpClient) :IGenericServiceInterface<T>
{
    public async Task<GeneralResponse> Insert(T entity, string baseUrl)
    {
        var httpClient = await getHttpClient.GetPrivateHttpClient();
        var response = await httpClient.PostAsJsonAsync($"{baseUrl}/add", entity);
        var result= await response.Content.ReadFromJsonAsync<GeneralResponse>();
        return result!;
    }
    public async Task<List<T>> GetAll(string baseUrl)
    {
        var client = await getHttpClient.GetPrivateHttpClient();
        var results = await client.GetFromJsonAsync<List<T>>($"{baseUrl}/all");
        return results!;
    }
    public async Task<T> GetByIdA(int id, string baseUrl)
    {
        var client = await getHttpClient.GetPrivateHttpClient();
        var results = await client.GetFromJsonAsync<T>($"{baseUrl}/single/{id}");
        return results!;
    }
    public async Task<GeneralResponse> Update(T entity, string baseUrl)
    {
        var client = await getHttpClient.GetPrivateHttpClient();
        var response = await client.PutAsJsonAsync($"{baseUrl}/update", entity);
        var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
        return result!;
    }
    public async Task<GeneralResponse> DeleteById(int id, string baseUrl)
    {
        var client = await getHttpClient.GetPrivateHttpClient();
        var response = await client.DeleteAsync($"{baseUrl}/delete/{id}");
        var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
        return result!;
    }

}
