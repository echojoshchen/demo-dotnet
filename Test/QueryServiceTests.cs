using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Grpc.Net.Client;

namespace Demo.Search.Tests;

public class QueryServiceStartup {
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
            endpoints.MapGrpcService<QueryService>();
        });
    }
}

[TestClass]
public class QueryServiceTests
{
    private readonly TestServer _server;
    private readonly SearchQueryService.SearchQueryServiceClient _client;

    private ContentItem createTestItem(string id, string lang, string title)
    {
        return new ContentItem
        {
            Id = id,
            Lang = lang,
            Title = title,
        };
    }

    public QueryServiceTests()
    {
        // Create a TestServer with the startup class from your gRPC service project
        _server = new TestServer(new WebHostBuilder().UseStartup<QueryServiceStartup>());

        // Create a GrpcChannel connected to the TestServer
        var channel = GrpcChannel.ForAddress(_server.BaseAddress, new GrpcChannelOptions
        {
            HttpClient = _server.CreateClient()
        });

        // Create a client for your gRPC service
        _client = new SearchQueryService.SearchQueryServiceClient(channel);
    }

    [TestMethod]
    public async Task GetResults_ReturnsCorrectItems()
    {
        SearchData searchData = new SearchData(".", "search.db");
        searchData.reset();

        // Arrange
        var items = new List<ContentItem>
        {
            createTestItem("1", "E", "Test 1"),
            createTestItem("2", "E", "Test 2"),
            createTestItem("3", "E", "Test 3"),
            createTestItem("4", "E", "Nothing"),
            createTestItem("5", "S", "Test Spanish"),
        };
        searchData.AddItems(items);

        // Act
        var getResultsRequest = new GetResultsRequest
        {
            Lang = "E",
            Text = "Test",
        };
        var getResultsResponse = await _client.GetResultsAsync(getResultsRequest);

        // Assert
        Assert.AreEqual(3, getResultsResponse.Items.Count);
    }
}