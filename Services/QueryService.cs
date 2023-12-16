using System.Linq;
using Grpc.Core;

namespace Demo.Search;

public class QueryService : SearchQueryService.SearchQueryServiceBase
{
    SearchData searchData = new SearchData(".", "search.db");

    private readonly ILogger<QueryService> _logger;
    public QueryService(ILogger<QueryService> logger)
    {
        _logger = logger;
    }

    public override Task<GetResultsResponse> GetResults(GetResultsRequest request, ServerCallContext context)
    {
        var results = searchData.GetResults(request.Lang, request.Text);
        GetResultsResponse resp = new GetResultsResponse{};
        resp.Items.AddRange(results);

        return Task.FromResult(resp);
    }

}
