namespace JFS_Test.Repositories
{
    public interface IRepository
    {
        BalanceRoot GetBalances();
        IEnumerable<Payment> GetPayments();
    }
}
