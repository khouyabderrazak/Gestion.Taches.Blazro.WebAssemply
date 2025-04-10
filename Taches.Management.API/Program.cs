using Taches.Management.API;
using Taches.Management.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBALServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
       policy =>
       {
           policy.WithOrigins("https://localhost:7227") // URL de l'application Angular
                 .AllowAnyHeader()
                 .AllowAnyMethod();
       });
});

var app = builder.Build();

var scope = app.Services.CreateScope();
await SeedData.InitializeAsync(scope.ServiceProvider);

app.UseCors("AllowAngularApp");

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
