using BaseLibraty.Entities;
using Microsoft.AspNetCore.Components;
using ServerLibrary.Repositories.Contracts;
namespace Server.Controllers;

[Route("api/[Controller]")]
public class BranchController(IGenericRepositoryInterface<Branch> genericRepositoryInterface)
: GenericController<Branch>(genericRepositoryInterface)
{
}