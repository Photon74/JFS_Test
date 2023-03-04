namespace JFS_Test.Repositories
{
    public interface IRepository
    {
        BalanceRoot GetCalculations();
        IEnumerable<Payment> GetPayments();
    }
}
