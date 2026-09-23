namespace FptRagLab.Domain.Interfaces
{
    /// <summary>
    /// Unit of Work pattern for grouping multiple repository operations into a single transaction.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
