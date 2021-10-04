using System;
using System.Collections.Generic;
using System.Web.Http;


namespace ServiceManager.VendorX.RecurringService.Controllers
{
    using Interworks.Cloud.ServiceManagersSDK.Libraries.Controllers;
    using Interworks.Cloud.ServiceManagersSDK.Libraries.Logs;
    using Interworks.Extensions.Models.Results;
    using Interworks.Extensions.Models.Services;

    public partial class ExampleController : ServiceManagerBaseController
    {
        [Route("Subscriptions/Activate")]
        public override IHttpActionResult SubscriptionsActivate(ServiceDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { definition }))
            {
                ServiceResultDefinition result = new ServiceResultDefinition();

                string externalSubscriptionID = definition.ID;

                ///...do something on the other side to activate

                // The external subscription ID
                result.Result = externalSubscriptionID;

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Subscriptions/Cancel")]
        public override IHttpActionResult SubscriptionsCancel(ServiceDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { definition }))
            {
                ServiceResultDefinition result = new ServiceResultDefinition();

                string externalSubscriptionID = definition.ID;

                ///...do something on the other side to cancel

                // The external subscription ID
                result.Result = externalSubscriptionID;

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Subscriptions/Create")]
        public override IHttpActionResult SubscriptionsCreate(ServiceDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { definition }))
            {
                ServiceResultDefinition result = new ServiceResultDefinition();

                string externalSubscriptionID = null;
                ///...do something on the other side to create subscription

                externalSubscriptionID = Guid.NewGuid().ToString();

                // The external subscription ID
                result.Result = externalSubscriptionID;

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Subscriptions/Suspend")]
        public override IHttpActionResult SubscriptionsSuspend(ServiceDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { definition }))
            {
                ServiceResultDefinition result = new ServiceResultDefinition();

                string externalSubscriptionID = definition.ID;

                ///...do something on the other side to suspend

                // The external subscription ID
                result.Result = externalSubscriptionID;

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Subscriptions/Update")]
        public override IHttpActionResult SubscriptionsUpdate(ServiceDefinition definition)
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