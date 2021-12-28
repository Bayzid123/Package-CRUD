using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PackageCrudRepositoryPattern.Core;
using PackageCrudRepositoryPattern.Interfaces;
using PackageCrudRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PackageCrudRepositoryPattern.Implementations
{
    public class PackageRepository : IPackageRepository
    {
        private readonly DataContext _context;
        public PackageRepository(DataContext context)
        {
            _context = context;
        }
        //get info from package table
        public async Task<ActionResult<List<Package>>>GetPackage()
        {
            return await _context.Packages.ToListAsync();
        }

        //post info on package table
        public async Task<ActionResult<Package>>PostPackage(Package id)
        {
            var createPackage = new Package
            {
                Name = id.Name,
                PackageType = id.PackageType,
                PackagePrice = id.PackagePrice,
            };
            _context.Packages.Add(createPackage);
            await _context.SaveChangesAsync();
            return (createPackage);
        }

        //update info into package table

        public async Task<ActionResult<List<Package>>> UpdatePackage(Package package)
        {
            var updatepackage = await _context.Packages.FindAsync(package.Id);
            if (updatepackage == null)
                Console.WriteLine("Package id not found");

            updatepackage.Id = package.Id;
            updatepackage.Name = package.Name;
            updatepackage.PackageType = package.PackageType;
            updatepackage.PackagePrice = package.PackagePrice;

            await _context.SaveChangesAsync();
            return (await _context.Packages.ToListAsync());
        }

        // Delete package from packages table
        public async Task<ActionResult<List<Package>>> DelPackage(int Id)
        {
            var delpackage = await _context.Packages.FindAsync(Id);
            if (delpackage == null)
                Console.WriteLine("Package Not Found");

            _context.Packages.Remove(delpackage);
            await _context.SaveChangesAsync();

            return (await _context.Packages.ToListAsync());
        }
    }
}
