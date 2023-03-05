using JFS_Test.Models;

namespace JFS_Test.Repositories
{
    public interface IRepository
    {
        IEnumerable<Balance> GetBalances();
        IEnumerable<Payment> GetPayments();
    }
}
