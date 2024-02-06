using Microsoft.Azure.Cosmos;
using CosmosCRUD.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserService, CosmosDBUserService>();
// builder.Services.AddSingleton<CosmosClient>(
//     new CosmosClient(
//             builder.Configuration["Cosmos:Endpoint"], 
//                 builder.Configuration["Cosmos:Key"])
//     );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
