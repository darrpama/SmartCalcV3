using CalculatorModel.Models;

var model = new CalcCore();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("calculator/calculate", (string expression) =>
    {
        var answer = model.Calculate(expression);
        return answer;
    })
    .WithName("CalculateExpression")
    .WithOpenApi();

app.Run();
