var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin() // For production, replace with your React App's specific URL
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("AllowAll"); // Must be placed before MapControllers
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
