
using BaseLibraty.Entities;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers;
[Route("api/[Controller]")]
public class DepartmentController(IGenericRepositoryInterface<Department> genericRepositoryInterface)
    :GenericController<Department>(genericRepositoryInterface)
{
}
