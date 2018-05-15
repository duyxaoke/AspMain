using Data.DAL;
using Shared.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspMain.Web.Startup))]
namespace AspMain.Web
{
    public partial class Startup
    {
        #region Define AutoMapper
        public void InitializeAutoMapper()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
        }
        #endregion

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            InitializeAutoMapper();

        }
    }
}
