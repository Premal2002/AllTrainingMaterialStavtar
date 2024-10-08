using Microsoft.EntityFrameworkCore;
using VendorManagementAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<VendorManagementContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI 
builder.Services.AddScoped(typeof(VendorManagementAPI.Vendor));
builder.Services.AddScoped(typeof(VendorManagementAPI.Invoice));
builder.Services.AddScoped(typeof(VendorManagementAPI.Currency));

builder.Services.AddCors(policy => policy.AddPolicy("AllowAll", rules =>
{
    rules.AllowAnyOrigin();
    rules.AllowAnyMethod();
    rules.AllowAnyHeader();
}));


var app = builder.Build();

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
