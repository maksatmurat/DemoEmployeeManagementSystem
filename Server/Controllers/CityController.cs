using BaseLibraty.Entities;
using Microsoft.AspNetCore.Components;
using ServerLibrary.Repositories.Contracts;
namespace Server.Controllers;

[Route("api/[Controller]")]
public class CityController(IGenericRepositoryInterface<City> genericRepositoryInterface)
: GenericController<City>(genericRepositoryInterface)
{
}