using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Consul;
using orderApi.Interfaces;
using orderApi.Helpers;


public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Microsoft.Extensions.Hosting.IHostApplicationLifetime lifetime)
    {
        ServiceEntity serviceEntity = new ServiceEntity
        {
            /*
             
             "IP": "localhost",
    "Port": 5205,
    "ServiceName": "customer-api",
    "ConsulIP": "localhost",
    "ConsulPort": "8500"*/
            IP = "localhost",
            Port = 5000,
            ServiceName = "order-api",
            ConsulIP = "localhost",
            ConsulPort = 8500
        };
        app.RegisterConsul(lifetime, serviceEntity);

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/health");
        });


    }
}

public static class AppBuilderExtensions
{
    public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime, ServiceEntity serviceEntity)
    {
        var consulClient = new ConsulClient(x => x.Address = new Uri($"http://localhost:8500"));
        var httpCheck = new AgentServiceCheck()
        {
            DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
            Interval = TimeSpan.FromSeconds(10),
            HTTP = $"http://localhost:5000/health",
            Timeout = TimeSpan.FromSeconds(5)
        };
        var registration = new AgentServiceRegistration()
        {
            Checks = new[] { httpCheck },
            ID = Guid.NewGuid().ToString(),
            Name = "order-api",
            Address = "localhost",
            Port = 5000,
            Tags = new[] { $"urlprefix-/{serviceEntity.ServiceName}" }
        };
        consulClient.Agent.ServiceRegister(registration).Wait();
        lifetime.ApplicationStopping.Register(() =>
        {
            consulClient.Agent.ServiceDeregister(registration.ID).Wait();
        });
        return app;
    }
}

public class ServiceEntity
{
    public string IP { get; set; }
    public int Port { get; set; }
    public string ServiceName { get; set; }
    public string ConsulIP { get; set; }
    public int ConsulPort { get; set; }
}