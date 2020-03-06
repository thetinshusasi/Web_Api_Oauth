using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Ninject.Web.WebApi.OwinHost;
using Ninject;
using System.Reflection;
using WebAPI.DLL.IRepositories;
using WebAPI.DLL.Repositories;
using WebAPI.DLL.Contexts;
using System.Data.Entity;
using AutoMapper;
using WebAPI.DLL.AutoMapperProfiles;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.Common;
using Swashbuckle.Application;
using WebAPI.DLL.DataModels;
using System.Web.Cors;
using Microsoft.Owin.Cors;

namespace WebAPITut
{
    public class Startup
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);
            config
            .EnableSwagger(c => c.SingleApiVersion("v1", "Owin Self hosted Web API"))
            .EnableSwaggerUi();

            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);


        }
        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            RegisterServices(kernel);
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<ICategoryRepository>().To<CategoryRepository>();
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<IEmployeeRepository>().To<EmployeeRepository>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IRegionRepository>().To<RegionRepository>();
            kernel.Bind<IShipperRepository>().To<ShipperRepository>();
            kernel.Bind<ISuppilerRepository>().To<SuppilerRepository>();
            kernel.Bind<ITerritoryRepository>().To<TerritoryRepository>();

            kernel.Bind<DbContext>().To<NorthWind>();
            kernel.Bind(typeof(IRepository<>)).To(typeof(Repository<>));
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                //Add your automapper profiles here
                cfg.AddProfile<MappingProfiles>();

            });
            kernel.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
        }
    }
}