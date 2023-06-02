using fauna_db_api.FaunaDB;
using FaunaDB.Client;
using Microsoft.Extensions.Options;

namespace fauna_db_api.FaunaDB;

public class FaunaClientFactory
{
    private readonly string _secret;
    private readonly string _endpoint;

    public FaunaClientFactory(FaunaDBSettings settings)
    {
        _secret = settings.Secret;
        _endpoint = settings.Endpoint;
    }

    public FaunaClient CreateClient()
    {
        return new FaunaClient(endpoint: _endpoint, secret: _secret);
    }
}
