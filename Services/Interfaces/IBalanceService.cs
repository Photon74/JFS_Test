using JFS_Test.DTOModels;

namespace JFS_Test.Services.Interfaces
{
    public interface IBalanceService
    {
        IEnumerable<BalanceDto> GetBalancesByAccountId(int accountId);
    }
}