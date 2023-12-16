using System.Linq;
using Grpc.Core;

namespace Demo.Search;

public class QueryService : SearchQueryService.SearchQueryServiceBase
{
    private readonly ILogger<QueryService> _logger;
    public QueryService(ILogger<QueryService> logger)
    {
        _logger = logger;
    }

    public override Task<GetResultsResponse> GetResults(GetResultsRequest request, ServerCallContext context)
    {
        GetResultsResponse resp = new GetResultsResponse
        {
        };

        return Task.FromResult(resp);
    }

}
