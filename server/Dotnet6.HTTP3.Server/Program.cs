using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, options) =>
  {
      options.Listen(IPAddress.Any, 7192, listenOptions =>
      {
          // Use HTTP/3
          listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
          listenOptions.UseHttps();
      });
  });

// Add services to the container.

var app = builder.Build();

app.MapGet("/", async httpContext =>
{
    await httpContext.Response.WriteAsync("HTTP3 Test!");
});

app.Run();
