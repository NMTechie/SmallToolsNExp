/*
 * https://graphql-dotnet.github.io/docs/migrations/migration5/
 * https://github.com/graphql-dotnet/graphql-dotnet/issues/2206
 */
using GraphQL;
using GraphQL.Instrumentation;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.DataLoader;
using GraphQL.Server.Ui.Playground;

using GraphQLExp.ApplicationGraphQL;
using GraphQLExp.ApplicationGraphQL.CustomTypes;
using GraphQLExp.ApplicationGraphQL.Schemas;
using GraphQLExp.DataAccess;
using GraphQLExp.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDBContext>(FillOptions,contextLifetime:ServiceLifetime.Transient, optionsLifetime:ServiceLifetime.Transient);


void FillOptions(DbContextOptionsBuilder dbContextOptionBuilder)
{
    dbContextOptionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),FillSqlServerOptions);
}

void FillSqlServerOptions(SqlServerDbContextOptionsBuilder sqlOptions)
{    
    sqlOptions.EnableRetryOnFailure();
}

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<StudentRepository>();

//GraphQL Section
builder.Services.AddTransient<StudentQuery>();
builder.Services.AddTransient<ProductSampleQuery>();
builder.Services.AddGraphQL(builder => builder
            .AddMetrics()
            .AddDocumentExecuter<ApolloTracingDocumentExecuter>()
            .AddHttpMiddleware<ProductSampleSchema, GraphQLHttpMiddlewareWithLogs<ProductSampleSchema>>()
            //.AddWebSocketsHttpMiddleware<ChatSchema>()
            .AddSchema<ProductSampleSchema>()
            .ConfigureExecutionOptions(options =>
            {
                options.EnableMetrics = true;
                var logger = options.RequestServices.GetRequiredService<ILogger<Program>>();
                options.UnhandledExceptionDelegate = ctx =>
                {
                    logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                    return Task.CompletedTask;
                };
            })
            .AddSystemTextJson()
            //.AddErrorInfoProvider<CustomErrorInfoProvider>()
            //.AddWebSockets()
            .AddDataLoader()
            .AddGraphTypes(typeof(ProductSampleSchema).Assembly));


var app = builder.Build();
app.UseGraphQL<ProductSampleSchema, GraphQLHttpMiddlewareWithLogs<ProductSampleSchema>>();
app.UseGraphQLPlayground(new PlaygroundOptions());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

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
.WithName("GetWeatherForecast");

var dbContext = builder.Services.BuildServiceProvider().GetService<ApplicationDBContext>(); 
InitialBootStrapper.SeedInitialData(dbContext);

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

