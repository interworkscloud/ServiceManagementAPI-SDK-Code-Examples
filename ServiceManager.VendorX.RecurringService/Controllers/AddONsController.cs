using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ServiceManager.VendorX.RecurringService.Controllers
{
    using Interworks.Cloud.ServiceManagersSDK.Libraries.Controllers;
    using Interworks.Cloud.ServiceManagersSDK.Libraries.Controllers.Interfaces;
    using Interworks.Cloud.ServiceManagersSDK.Libraries.Logs;
    using Interworks.Extensions.Models.Results;
    using Interworks.Extensions.Models.Services;

    public partial class ExampleController : ServiceManagerBaseController
    {

        [Route("Addons/Cancel")]
        public override IHttpActionResult AddonsCancel(ServiceDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { definition }))
            {
                ServiceResultDefinition result = new ServiceResultDefinition();

                 string externalSubscriptionID = definition.ID;

                ///...do something on the other side to update

                // The external subscription ID
                result.Result = externalSubscriptionID;

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Addons/Create")]
        public override IHttpActionResult AddonsCreate(ServiceDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { definition }))
            {
                ServiceResultDefinition result = new ServiceResultDefinition();
                 result.Result = Guid.NewGuid().ToString();

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Addons/Update")]
        public override IHttpActionResult AddonsUpdate(ServiceDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { definition }))
            {
                ServiceResultDefinition result = new ServiceResultDefinition();

                 string externalSubscriptionID = definition.ID;

                ///...do something on the other side to update

                // The external subscription ID
                result.Result = externalSubscriptionID;

                return SuccessResult(ActionLogUUID, result);
            }
        }


    }
}