using ORMDemo.API.Infrastructure.Contexts;

WebApplication app;
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DemoContext>(options => 
    options.UseNpgsql("Host=postgres;Database=demo;Username=postgres;Password=demopassword")
);

app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();
