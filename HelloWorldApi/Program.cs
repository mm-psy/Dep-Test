using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddNewtonsoftJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/hello", () => "Hello World");

app.MapPost("/api/data", (JsonData data) =>
{
    var response = new JsonResponse
    {
        Message = $"Received: {data.Name}",
        Timestamp = DateTime.UtcNow,
        Data = data
    };
    
    // Serialize using Newtonsoft.Json
    var json = JsonConvert.SerializeObject(response, Formatting.Indented);
    
    return Results.Ok(response);
});

app.Run();

public class JsonData
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}

public class JsonResponse
{
    public string? Message { get; set; }
    public DateTime Timestamp { get; set; }
    public JsonData? Data { get; set; }
}
