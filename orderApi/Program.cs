

using basketApi.Context;
using orderApi.Helpers;
using orderApi.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<orderDbContext>();
builder.Services.AddSingleton<ServiceEntity>();
builder.Services.AddTransient<IServiceCallHelper, ServiceCallHelper>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCap(option =>
{
    option.UseEntityFramework<orderDbContext>();
    option.UseDashboard(x => x.PathMatch = "/cap");
    string db_setting = String.Format("Host={0}; Port={1}; Username={2}; Password={3}; Database={4};", "Postgre", 5432, "root", "root", "Emarket");

    option.UsePostgreSql(db_setting);
    option.UseRabbitMQ(option =>
    {
        option.ConnectionFactoryOptions = option =>
        {
            option.Ssl.Enabled = false;
            option.HostName = "192.168.0.14";
            option.Port = 5672;
            option.UserName = "guest";
            option.Password = "guest";
        };

    });
});



builder.Services.AddHealthChecks();



var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();



app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
var serviceEntity = app.Services.GetRequiredService<ServiceEntity>();
app.RegisterConsul(lifetime, serviceEntity);

app.Run();
