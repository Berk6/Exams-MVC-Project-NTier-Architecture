using Autofac;
using Exams.Core.Repositories;
using Exams.Core.Services;
using Exams.Core.UnitOfWorks;
using Exams.Repository;
using Exams.Repository.Repositories;
using Exams.Repository.UnitOfWorks;
using Exams.Service.Services;
using MapsterMapper;
using System.Reflection;
using Module = Autofac.Module;
namespace Exams.WEB.ConfigurationService
{
    public class AutoFactContainer:Module
    {
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            builder.RegisterType<ServiceMapper>().As<IMapper>();
            var programCs = Assembly.GetExecutingAssembly();
            var repository = Assembly.GetAssembly(typeof(AppDbContext));
            var service = Assembly.GetAssembly(typeof(UserService));
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<,>)).As(typeof(IService<,>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(programCs, repository, service).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(programCs, repository, service).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
