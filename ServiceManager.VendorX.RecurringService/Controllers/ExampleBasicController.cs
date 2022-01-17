using System.Web.Http;
using System.Web.Http.Controllers;
using Interworks.Cloud.ServiceManagersSDK.Libraries.Controllers;

namespace ServiceManager.VendorX.RecurringService.Controllers
{

    [RoutePrefix("api/Example")]
    public partial class ExampleController : ServiceManagerBaseController
    {
        private string _username = null;
        private string _password = null;

        protected override void InitializeDerived(HttpControllerContext controllerContext)
        {
            GetHeaderValue(controllerContext.Request.Headers, "FieldUsername", out _username);
            GetHeaderValue(controllerContext.Request.Headers, "FieldPassword", out _password);
        }
    }

}