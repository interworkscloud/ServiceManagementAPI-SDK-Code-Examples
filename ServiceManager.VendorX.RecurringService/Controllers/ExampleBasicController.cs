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
        private string _url = null;
        private string _region = null;
        private string _excelFile = null;

        protected override void InitializeDerived(HttpControllerContext controllerContext)
        {
            GetHeaderValue(controllerContext.Request.Headers, "FieldUsername", out _username);
            GetHeaderValue(controllerContext.Request.Headers, "FieldPassword", out _password);
            GetHeaderValue(controllerContext.Request.Headers, "FieldUri", out _url);
            GetHeaderValue(controllerContext.Request.Headers, "FieldRegion", out _region);
            GetHeaderValue(controllerContext.Request.Headers, "excelfile", out _excelFile);
        }
    }

}