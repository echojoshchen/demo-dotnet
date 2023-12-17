using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Grpc.Net.Client;

namespace Demo.Search.Tests;

public class IndexServiceStartup {
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddGrpc();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<IndexService>();
        });
    }
}

[TestClass]
public class IndexServiceTests
{
    private readonly TestServer _server;
    private readonly SearchIndexService.SearchIndexServiceClient _client;

    private ContentItem createTestItem(string id, string lang, string title)
    {
        return new ContentItem
        {
            Id = id,
            Lang = lang,
            Title = title,
        };
    }

    public IndexServiceTests()
    {
        // Create a TestServer with the startup class from your gRPC service project
        _server = new TestServer(new WebHostBuilder().UseStartup<IndexServiceStartup>());

        // Create a GrpcChannel connected to the TestServer
        var channel = GrpcChannel.ForAddress(_server.BaseAddress, new GrpcChannelOptions
        {
            HttpClient = _server.CreateClient()
        });

        // Create a client for your gRPC service
        _client = new SearchIndexService.SearchIndexServiceClient(channel);
    }

    [TestMethod]
    public async Task AddItems_AddsItemsSuccessfully()
    {
        var items = new List<ContentItem>
        {
            createTestItem("1", "E", "Test 1"),
            createTestItem("2", "E", "Test 2"),
        };
        var request = new AddItemsRequest {};
        request.Items.AddRange(items);

        var response = await _client.AddItemsAsync(request);

        Assert.AreEqual(response.Success, true);
    }

    [TestMethod]
    public async Task DeleteItems_DeletesItemsSuccessfully()
    {
        var items = new List<ContentItem>
        {
            createTestItem("1", "E", "Test 1"),
            createTestItem("2", "E", "Test 2"),
        };
        var request = new AddItemsRequest {};
        request.Items.AddRange(items);

        var response = await _client.AddItemsAsync(request);

        Assert.AreEqual(response.Success, true);

        var deleteRequest = new DeleteItemsRequest {};
        deleteRequest.Ids.AddRange(new List<string> { "1", "2" });

        var deleteResponse = await _client.DeleteItemsAsync(deleteRequest);

        Assert.AreEqual(deleteResponse.Success, true);
    }

    [TestMethod]
    public async Task DeleteAll_DeletesAllItemsSuccessfully()
    {
        var items = new List<ContentItem>
        {
            createTestItem("1", "E", "Test 1"),
            createTestItem("2", "E", "Test 2"),
        };
        var request = new AddItemsRequest {};
        request.Items.AddRange(items);

        var response = await _client.AddItemsAsync(request);

        Assert.AreEqual(response.Success, true);

        var deleteAllRequest = new DeleteAllRequest {};

        var deleteAllResponse = await _client.DeleteAllAsync(deleteAllRequest);

        Assert.AreEqual(deleteAllResponse.Success, true);
    }
}