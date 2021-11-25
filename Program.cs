// In powershell:
// (dotnet tool install -g Microsoft.dotnet-httprepl)
// dotnet build
// dotnet run
// httprepl https://localhost:7212 (your localhost adr)
// cd WeatherForecast
// get

// dotnet run

using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    // Unsafe policy, allowing any access
    options.AddPolicy("DevCorsPolicy", builder =>
    {
        builder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();

app.UseCors("DevCorsPolicy");

//app.UseCors(policy =>
//    policy.WithOrigins("http://localhost:5000", "Https://localhost:5001")
//    .AllowAnyMethod()
//    .WithHeaders(HeaderNames.ContentType));



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
