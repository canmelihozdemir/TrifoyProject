using Autofac;
using System.Reflection;
using TrifoyProject.Core.Repositories;
using TrifoyProject.Core.Services;
using TrifoyProject.Core.UnitOfWorks;
using TrifoyProject.Repository;
using TrifoyProject.Repository.Repositories;
using TrifoyProject.Repository.UnitOfWorks;
using TrifoyProject.Service.Services;
using Module = Autofac.Module;

namespace TrifoyProject.API.Modules
{
    public class RepositoryServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //GenericTypes
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            //DefaultTypes
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly=Assembly.GetExecutingAssembly();
            var repositoryAssembly = Assembly.GetAssembly(typeof(AppIdentityDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(Service<>));

            builder.RegisterAssemblyTypes(apiAssembly, repositoryAssembly, serviceAssembly).Where(x=>x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repositoryAssembly, serviceAssembly).Where(x=>x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
