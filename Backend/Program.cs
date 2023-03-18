using Backend2;
using Backend2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
//Added dbcontext 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<MemberDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MemberDbContext")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();
app.UseCors(policy => policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(Origin => true)
                    .AllowCredentials());

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

app.Run();

