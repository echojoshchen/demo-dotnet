/// <summary>
/// IndexService.cs
/// 
/// This service adds and deletes items from the search index.
/// </summary>

using System.Linq;
using Grpc.Core;

namespace Demo.Search;

public class IndexService : SearchIndexService.SearchIndexServiceBase
{
    SearchData searchData = new SearchData(".", "search.db");

    private readonly ILogger<IndexService> _logger;
    public IndexService(ILogger<IndexService> logger)
    {
        _logger = logger;
    }

    public override Task<AddItemsResponse> AddItems(AddItemsRequest request, ServerCallContext context)
    {
        AddItemsResponse resp = new AddItemsResponse{};
        try {
            searchData.AddItems(request.Items.ToList());
            resp.Success = true;
        } catch (Exception e) {
            resp.Success = false;
            resp.Message = "Error adding items: " + e.Message;
        }

        return Task.FromResult(resp);
    }

    public override Task<DeleteItemsResponse> DeleteItems(DeleteItemsRequest request, ServerCallContext context)
    {
        DeleteItemsResponse resp = new DeleteItemsResponse{};
        try {
            searchData.DeleteItems(request.Ids.ToList());
            resp.Success = true;
        } catch (Exception e) {
            resp.Success = false;
            resp.Message = "Error adding items: " + e.Message;
        }

        return Task.FromResult(resp);
    }

    public override Task<DeleteAllResponse> DeleteAll(DeleteAllRequest request, ServerCallContext context)
    {
        DeleteAllResponse resp = new DeleteAllResponse{};
        try {
            searchData.reset();
            resp.Success = true;
        } catch (Exception e) {
            resp.Success = false;
            resp.Message = "Error adding items: " + e.Message;
        }

        return Task.FromResult(resp);
    }
}
