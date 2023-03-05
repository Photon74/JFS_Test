using JFS_Test.DTOModels;
using JFS_Test.DTOModels.Enums;

namespace JFS_Test.Services.Interfaces
{
    public interface IStatementService
    {
        IEnumerable<StatementDto> GetStatements(int accountId, Period period);
    }
}