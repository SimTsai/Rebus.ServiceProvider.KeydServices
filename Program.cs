using Rebus.Config;
using Rebus.Transport.InMem; // Add this using directive

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddKeyedScoped<MyKeydService>("MyKeydService");
builder.Services.AddRebus(c => c.Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "bimse")));
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.Run();


class MyKeydService
{
    public MyKeydService(string key)
    {
        Key = key;
    }

    public string Key { get; }
}