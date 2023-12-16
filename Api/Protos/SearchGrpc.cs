// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/search.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Demo.Search {
  public static partial class SearchIndexService
  {
    static readonly string __ServiceName = "org.demo.SearchIndexService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Demo.Search.AddItemsRequest> __Marshaller_org_demo_AddItemsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Demo.Search.AddItemsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Demo.Search.AddItemsResponse> __Marshaller_org_demo_AddItemsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Demo.Search.AddItemsResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Demo.Search.DeleteItemsRequest> __Marshaller_org_demo_DeleteItemsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Demo.Search.DeleteItemsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Demo.Search.DeleteItemsResponse> __Marshaller_org_demo_DeleteItemsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Demo.Search.DeleteItemsResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Demo.Search.AddItemsRequest, global::Demo.Search.AddItemsResponse> __Method_AddItems = new grpc::Method<global::Demo.Search.AddItemsRequest, global::Demo.Search.AddItemsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddItems",
        __Marshaller_org_demo_AddItemsRequest,
        __Marshaller_org_demo_AddItemsResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Demo.Search.DeleteItemsRequest, global::Demo.Search.DeleteItemsResponse> __Method_DeleteItems = new grpc::Method<global::Demo.Search.DeleteItemsRequest, global::Demo.Search.DeleteItemsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "DeleteItems",
        __Marshaller_org_demo_DeleteItemsRequest,
        __Marshaller_org_demo_DeleteItemsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Demo.Search.SearchReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of SearchIndexService</summary>
    [grpc::BindServiceMethod(typeof(SearchIndexService), "BindService")]
    public abstract partial class SearchIndexServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Demo.Search.AddItemsResponse> AddItems(global::Demo.Search.AddItemsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Demo.Search.DeleteItemsResponse> DeleteItems(global::Demo.Search.DeleteItemsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(SearchIndexServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_AddItems, serviceImpl.AddItems)
          .AddMethod(__Method_DeleteItems, serviceImpl.DeleteItems).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SearchIndexServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_AddItems, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Demo.Search.AddItemsRequest, global::Demo.Search.AddItemsResponse>(serviceImpl.AddItems));
      serviceBinder.AddMethod(__Method_DeleteItems, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Demo.Search.DeleteItemsRequest, global::Demo.Search.DeleteItemsResponse>(serviceImpl.DeleteItems));
    }

  }
  public static partial class SearchQueryService
  {
    static readonly string __ServiceName = "org.demo.SearchQueryService";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Demo.Search.GetResultsRequest> __Marshaller_org_demo_GetResultsRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Demo.Search.GetResultsRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Demo.Search.GetResultsResponse> __Marshaller_org_demo_GetResultsResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Demo.Search.GetResultsResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Demo.Search.GetResultsRequest, global::Demo.Search.GetResultsResponse> __Method_GetResults = new grpc::Method<global::Demo.Search.GetResultsRequest, global::Demo.Search.GetResultsResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetResults",
        __Marshaller_org_demo_GetResultsRequest,
        __Marshaller_org_demo_GetResultsResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Demo.Search.SearchReflection.Descriptor.Services[1]; }
    }

    /// <summary>Base class for server-side implementations of SearchQueryService</summary>
    [grpc::BindServiceMethod(typeof(SearchQueryService), "BindService")]
    public abstract partial class SearchQueryServiceBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Demo.Search.GetResultsResponse> GetResults(global::Demo.Search.GetResultsRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(SearchQueryServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetResults, serviceImpl.GetResults).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, SearchQueryServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetResults, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Demo.Search.GetResultsRequest, global::Demo.Search.GetResultsResponse>(serviceImpl.GetResults));
    }

  }
}
#endregion
