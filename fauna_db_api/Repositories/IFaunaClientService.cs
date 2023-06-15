using FaunaDB.Query;
using FaunaDB.Types;

namespace fauna_db_api.Repositories;

public interface IFaunaClientService
{
    Task<Value> Query(Expr expression);
}
