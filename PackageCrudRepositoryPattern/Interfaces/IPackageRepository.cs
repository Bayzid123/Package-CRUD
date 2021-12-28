using Microsoft.AspNetCore.Mvc;
using PackageCrudRepositoryPattern.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackageCrudRepositoryPattern.Interfaces
{
    public interface IPackageRepository
    {
        public Task<ActionResult<List<Package>>> GetPackage();
        public Task<ActionResult<Package>> PostPackage(Package Create);
        public Task<ActionResult<List<Package>>> UpdatePackage(Package Update);
        public Task<ActionResult<List<Package>>> DelPackage(int Id);

    }
}
