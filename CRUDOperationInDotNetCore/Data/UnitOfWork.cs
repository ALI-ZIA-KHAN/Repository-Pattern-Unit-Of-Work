using CRUDOperationInDotNetCore.Data.Repo;
using CRUDOperationInDotNetCore.Interfaces;
using CRUDOperationInDotNetCore.Models;

namespace CRUDOperationInDotNetCore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BrandContext dc;
        public UnitOfWork(BrandContext dc)
        {
            this.dc = dc;
        }

        public IBrandRepository brandRepository => new BrandRepository(dc);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
