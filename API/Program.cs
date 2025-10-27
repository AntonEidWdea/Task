using API.Extention;
using Infrastrucure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepository();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging(true);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCors",
        builder =>
        {
            builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000")
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    var serviceProvider = serviceScope.ServiceProvider;
    if (!serviceScope.ServiceProvider.GetService<ApplicationDBContext>().AllMigrationsApplied())
    {
        serviceScope.ServiceProvider.GetService<ApplicationDBContext>().Migrate();
    }
    ContextSeed.Seed(dbContext, serviceProvider);
}

app.UseHttpsRedirection();
app.UseCors("AllowCors");
app.UseAuthorization();
app.UseMiddleware<GlobalExceptionHandler>();
app.MapControllers();

app.Run();
