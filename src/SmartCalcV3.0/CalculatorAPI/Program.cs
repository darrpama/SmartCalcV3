using System.Linq.Expressions;
using CalculatorModel.Models;

var model = new CalcCore();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:5173") // Replace with your Vue.js app URL
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("calculator/calculate", (HttpContext context, CalculatorExpression calculatorExpression) =>
    {
        if (calculatorExpression.expression != null)
        {
            var answer = model.Calculate(calculatorExpression.expression);
            return Results.Json(answer);
        }
        else
        {
            return Results.BadRequest();
        }
    })
    .WithName("CalculateExpression")
    .WithOpenApi();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowSpecificOrigin");
}

app.Run();

public record CalculatorExpression(string expression);
