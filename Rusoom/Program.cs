using Rusoom.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Asp.Versioning;
using Rusoom.Controllers;
using Rusoom.Services.PrivacyPolicy;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<RusoomDbContext>(options => 
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("RusoomDb"));

        // TODO: Re-enable policy seeding after Arabic and English policy pages are published.
        /* options.UseSeeding((context, _ ) =>
        {
            var policyV1Exists = context.Set<PrivacyPolicy>().Any(policy => policy.Version == 1);

            if(policyV1Exists)
            {
                return;
            } else
            {
                var privacyPolicy = new PrivacyPolicy
                {
                    PrivacyPolicyId = Guid.NewGuid(),
                    Version = 1,
                    IsCurrent = true
                };
                context.Set<PrivacyPolicy>().Add(privacyPolicy);
            }
        }
        );

        options.UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            var policyV1Exists = await context.Set<PrivacyPolicy>().AnyAsync(policy => policy.Version == 1, cancellationToken);
            if (policyV1Exists)
            {
                return;
            }
            else
            {
                var privacyPolicy = new PrivacyPolicy
                {
                    PrivacyPolicyId = Guid.NewGuid(),
                    Version = 1,
                    IsCurrent = true
                };
                context.Set<PrivacyPolicy>().Add(privacyPolicy);
            }
        }
        );*/

    });

builder.Services.AddApiVersioning(options => 
{ options.ApiVersionReader = new UrlSegmentApiVersionReader(); 
}).AddApiExplorer(options => 
{ 
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
})
.AddMvc().AddOpenApi();

builder.Services.AddScoped<IPrivacyPolicyService, PrivacyPolicyService>();

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
