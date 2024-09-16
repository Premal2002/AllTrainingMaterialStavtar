using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI 
builder.Services.AddScoped(typeof(EmployeeManagementDI.Models.EmployeeDbContext));
builder.Services.AddScoped(typeof(EmployeeManagementDI.Accounts));

////CORS
//builder.Services.AddCors(policy => policy.AddPolicy("accountsApp", rules =>
//{
//    string[] accountClients = new string[]
//    {
//        "http://127.0.0.1:5500","","http://www.abc.com" //this are origins
//    };

//    //string[] methods = new string[] { "GET", "POST" }; //this are methods



//    rules.AllowAnyOrigin();
//    //rules.WithOrigins(accountClients);
//    rules.AllowAnyMethod();
//    rules.AllowAnyHeader();//
//}));

//builder.Services.AddCors(policy => policy.AddPolicy("customerApp", rules =>
//{
//    rules.AllowAnyOrigin();
//    rules.AllowAnyMethod();
//    rules.AllowAnyHeader();
//}));

//builder.Services.AddCors(policy => policy.AddPolicy("invoiceApp", rules =>
//{

//}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
