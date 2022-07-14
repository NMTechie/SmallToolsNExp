var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

//This is using the Delegate class 
app.MapGet("/weatherforecast", () =>
{  
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
   
})
.WithName("GetWeatherForecast").Produces<HttpResponse>();


//This is using the RequestDelegate overload that has access to HTTPContext object
app.MapGet("/streamchunked", async (context) =>
{
    var response = context.Response;
    response.Headers.Add("Transfer-Encoding", "chunked");
    response.Headers.Add("Content-Type", "text/event-stream");
    response.StatusCode = 200;

    for (var i = 0; true; ++i)
    {
        await response
            .WriteAsync($"data: Controller {i} at {DateTime.Now}\r\r");

        await response.Body.FlushAsync();
        await Task.Delay(5 * 1000);
    }


}).WithName("GetDataStreamChunked");


app.MapGet("/Test", () => 
{
    //return context.Response.WriteAsync("Hello World");
    return "Hello World";

}).WithName("Testing");


app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}