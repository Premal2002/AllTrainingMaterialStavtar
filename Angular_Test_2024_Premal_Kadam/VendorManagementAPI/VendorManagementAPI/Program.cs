using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using VendorManagementAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<VendorManagementContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
    
//    .AddJsonOptions(jsonOptions =>
//{
//    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI 
builder.Services.AddScoped(typeof(Vendor));
builder.Services.AddScoped(typeof(Invoice));
builder.Services.AddScoped(typeof(Currency));

builder.Services.AddCors(policy => policy.AddPolicy("AllowAll", rules =>
{
    rules.AllowAnyOrigin();
    rules.AllowAnyMethod();
    rules.AllowAnyHeader();
}));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<VendorManagementContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
