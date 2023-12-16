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

    public override Task<AddOrUpdateItemsResponse> AddOrUpdateItems(AddOrUpdateItemsRequest request, ServerCallContext context)
    {
        AddOrUpdateItemsResponse resp = new AddOrUpdateItemsResponse
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

    public override Task<DeleteContentFamilyResponse> DeleteContentFamily(DeleteContentFamilyRequest request, ServerCallContext context)
    {
        DeleteContentFamilyResponse resp = new DeleteContentFamilyResponse
        {
        };

        return Task.FromResult(resp);
    }

    public override Task<DeleteAllResponse> DeleteAll(DeleteAllRequest request, ServerCallContext context)
    {
        DeleteAllResponse resp = new DeleteAllResponse
        {
        };

        return Task.FromResult(resp);
    }

    public override Task<GetLastIndexedOnResponse> GetLastIndexedOn(GetLastIndexedOnRequest request, ServerCallContext context)
    {
        GetLastIndexedOnResponse resp = new GetLastIndexedOnResponse
        {
        };

        return Task.FromResult(resp);
    }

    public override Task<ResetResponse> Reset(ResetRequest request, ServerCallContext context)
    {
        ResetResponse resp = new ResetResponse
        {
        };

        return Task.FromResult(resp);
    }
}
