using System.Linq;
using Grpc.Core;

namespace Demo.Search;

public class IndexService : SearchIndexService.SearchIndexServiceBase
{
    SearchData searchData = new SearchData(".");

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
}
