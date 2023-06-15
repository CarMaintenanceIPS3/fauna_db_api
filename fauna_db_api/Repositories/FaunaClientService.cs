using fauna_db_api.FaunaDB;
using FaunaDB.Client;
using FaunaDB.Query;
using FaunaDB.Types;

namespace fauna_db_api.Repositories;

public class FaunaClientService : IFaunaClientService
{
    private readonly FaunaClient _faunaClient;

    public FaunaClientService(FaunaClientFactory faunaClientFactory)
    {
        _faunaClient = faunaClientFactory.CreateClient();
    }

    public Task<Value> Query(Expr expression) => _faunaClient.Query(expression);
}
