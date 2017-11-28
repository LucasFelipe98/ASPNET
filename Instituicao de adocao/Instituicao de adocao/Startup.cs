using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Instituicao_de_adocao.Startup))]
namespace Instituicao_de_adocao
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
