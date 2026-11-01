using Rusoom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Asp.Versioning;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<RusoomDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RusoomDb")));

builder.Services.AddApiVersioning(options => 
{ options.ApiVersionReader = new UrlSegmentApiVersionReader(); 
}).AddApiExplorer(options => 
{ 
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
})
.AddMvc().AddOpenApi();

builder.Services.AddProblemDetails();
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().WithDocumentPerVersion();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in app.DescribeApiVersions().Reverse())
        {
            options.SwaggerEndpoint($"/openapi/{description.GroupName}.json", 
               $"Rusoom API {description.GroupName.ToUpperInvariant()}");
        }
    }
    );
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
