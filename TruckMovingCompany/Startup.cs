using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using TruckMovingCompany.DataModel;
[assembly: OwinStartupAttribute(typeof(TruckMovingCompany.Startup))]
namespace TruckMovingCompany
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // ConfigureAuth(app);
            Database.SetInitializer(new NullDatabaseInitializer<TruckCompanyContext>());
            app.CreatePerOwinContext(TruckCompanyContext.Create);
        }
    }
}
