using AutoMapper;
using CatalogService.Business.Abstract;
using CatalogService.Business.AutoMapper;
using CatalogService.Business.Concrete;
using CatalogService.Business.Consumer;
using CatalogService.DataAccess.Abtract;
using CatalogService.DataAccess.Concrete;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Business.DependencyResolver
{
    public static class ServiceRegistrations
    {
        public static void Create(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            services.AddMassTransit(config =>
            {
                config.AddConsumer<UpdateProductNameConsumer>();
                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("amqp://guest:guest@localhost");
                    //cfg.Message<SendEmailCommand>(x => x.SetEntityName("SendEmailCommand"));

                    cfg.ReceiveEndpoint("update-prodcut-name", c =>
                    {
                        c.ConfigureConsumer<UpdateProductNameConsumer>(ctx);
                    });
                });
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}