using System.Web.Http;
using Contacts.Web.Entities;
using Contacts.Web.Entities.Context;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace Contacts.Web
{
    public class DependencyConfig
    {
        public static void Initialize(HttpConfiguration config)
        {
            Container container = new Container();
            container.RegisterWebApiRequest<IContactsDbContext>(() => new ContactsDbContext());
            container.RegisterWebApiControllers(config);
            container.Verify();
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
