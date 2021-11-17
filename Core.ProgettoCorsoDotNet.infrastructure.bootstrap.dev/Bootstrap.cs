using Core.ProgettoCorsoDotNet.persistence.MSQL;
using Core.ProgettoCorsoDotNet.services.common;
using Core.ProgettoCorsoDotNet.services;
using Microsoft.Extensions.DependencyInjection;
using System;
using Core.ProgettoCorsoDotNet.domain;
using Core.ProgettoCorsoDotNet.persistence.common;
using Core.ProgettoCorsoDotNet.persistence.MSQL.EF.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.ProgettoCorsoDotNet.infrastructure.bootstrap.dev
{
    public static class Bootstrap
    {
        public static void AddDependencies(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NORTHWINDContext>(
                options => options.UseSqlServer(connectionString));
            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IRepository<Category>, CategoryRepository>();
            services.AddTransient<IService<Product>, ProductService>();
            services.AddTransient<IService<Category>, CategoryService>();
        }
    }
}
