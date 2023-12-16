using System.Linq;
using Grpc.Core;
using GrpcDemo;

namespace GrpcDemo.Services;

public class DemoService : DemoApi.DemoApiBase
{
    private readonly ILogger<DemoService> _logger;
    public DemoService(ILogger<DemoService> logger)
    {
        _logger = logger;
    }

    public override Task<DemoContainer> DoSomething(DemoRequest request, ServerCallContext context)
    {
        DemoObject obj = new DemoObject {
            Name = "obj name",
        };
        DemoContainer resp = new DemoContainer
        {
            Id = request.Id,
        };
        resp.Objects.Add(obj);

        return Task.FromResult(resp);
    }
}
