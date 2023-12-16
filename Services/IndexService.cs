using System.Linq;
using Grpc.Core;

namespace Demo.Search;

public class IndexService : SearchIndexService.SearchIndexServiceBase
{
    private readonly ILogger<IndexService> _logger;
    public IndexService(ILogger<IndexService> logger)
    {
        _logger = logger;
    }

    public override Task<AddItemsResponse> AddItems(AddItemsRequest request, ServerCallContext context)
    {
        AddItemsResponse resp = new AddItemsResponse
        {
        };

        return Task.FromResult(resp);
    }

    public override Task<DeleteItemsResponse> DeleteItems(DeleteItemsRequest request, ServerCallContext context)
    {
        DeleteItemsResponse resp = new DeleteItemsResponse
        {
        };

        return Task.FromResult(resp);
    }
}
