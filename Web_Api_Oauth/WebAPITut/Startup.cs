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

namespace WebAPITut
{
    public class Startup
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            config.EnableCors();
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);
            config
    .EnableSwagger(c => c.SingleApiVersion("v1", "Owin Self hosted Web API"))
    .EnableSwaggerUi();

        }
        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);

            //kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IProductRepository>().To<ProductRepository>();
            kernel.Bind<DbContext>().To<SqlContext>();
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