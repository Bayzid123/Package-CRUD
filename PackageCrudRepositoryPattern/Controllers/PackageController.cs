using Microsoft.AspNetCore.Mvc;
using PackageCrudRepositoryPattern.Core;
using PackageCrudRepositoryPattern.Interfaces;
using PackageCrudRepositoryPattern.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackageCrudRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageRepository _packageRepo;

        public PackageController(IPackageRepository packagerepo)
        {
            _packageRepo = packagerepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Package>>> GetPackageInfo()
        {
            return await _packageRepo.GetPackage();
        }

        [HttpPost]
        public async Task<ActionResult<Package>> PostPackageInfo(Package up)
        {
            return await _packageRepo.PostPackage(up);
        }

        [HttpPut]

        public async Task<ActionResult<List<Package>>> PutPackage(Package Update)
        {
            return Ok(await _packageRepo.UpdatePackage(Update));
        }

        [HttpDelete]
        public async Task<ActionResult<List<Package>>>DeletePackage(int Id)
        {
            return Ok(await _packageRepo.DelPackage(Id));
        }
    }
}
