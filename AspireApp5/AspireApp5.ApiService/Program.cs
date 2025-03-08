var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add API Documentation
builder.Services.AddSwaggerGen();

// Add controllers services
builder.Services.AddControllers();

builder.AddRabbitMQClient(connectionName: "messaging");

// Add services to the container.
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();


app.MapDefaultEndpoints();

app.Run();
