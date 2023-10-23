using CRUDOperationInDotNetCore.Interfaces;
using CRUDOperationInDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDOperationInDotNetCore.Data.Repo
{
    public class BrandRepository : IBrandRepository
    {
        private readonly BrandContext dc;
        public  BrandRepository(BrandContext dbContext)
        {
            this.dc = dbContext;
        }
        public async Task DeleteBrand(int id)
        {
            var brand = await dc.Brands.FindAsync(id);
 
            dc.Brands.Remove(brand);
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
           
            return await dc.Brands.ToListAsync();
        }

        public async Task AddBrand(Brand brand)
        {
            dc.Brands.Add(brand);
        }

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
