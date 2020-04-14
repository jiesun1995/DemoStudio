using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using rabbitmqDemo.Client;
using rabbitmqDemo.Configuration;
using rabbitmqDemo.Consumer;

namespace rabbitmqDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<RabbitOptions>(config => { 
            
            
            });
            services.AddSingleton<IRabbitMQClient, RabbitMQClient>();
            services.AddHostedService<ConsumerManager>();
            services.AddSingleton<IRabbitEventBusContainer, EventBusContainer>();
            services.AddSingleton(serviceProvider => serviceProvider.GetService<IRabbitEventBusContainer>() as IProducerContainer);
            //Startup.Register(async serviceProvider =>
            //{
            //    var container = serviceProvider.GetService<IRabbitEventBusContainer>();
            //    if (eventBusConfig != default)
            //        await eventBusConfig(container);
            //    else
            //        await container.AutoRegister();
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
