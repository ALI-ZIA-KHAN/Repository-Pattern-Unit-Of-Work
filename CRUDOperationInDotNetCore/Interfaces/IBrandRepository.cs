using CRUDOperationInDotNetCore.Models;

namespace CRUDOperationInDotNetCore.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task AddBrand(Brand brand);
        Task DeleteBrand(int id);

    }
}
