namespace CRUDOperationInDotNetCore.Interfaces
{
    public interface IUnitOfWork
    {
        IBrandRepository brandRepository { get; }
        Task<bool> SaveAsync();
    }
}
