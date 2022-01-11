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

                #region Validations
                //Dictionary<int, string> errors = new Dictionary<int, string>() {
                //    { -6532, "Purchase of product could not be made with quantity less that 250" }
                //};

                ////Check minimum quantity requirement
                //if (definition.Quantity < 250)
                //    return ErrorResult(ActionLogUUID, -6532, errors[-6532]);

                #endregion

                if (definition.CheckOnly)
                    return SuccessResult(ActionLogUUID, result);

                #region Provisioning

                ///...do something on the other side to create subscription
                result.CustomFieldValues = new Dictionary<string, string>()
                {
                    {"VendorXOfferId","38F0BAD7-06ED-4094-AA4E-3395B3482C82" }
                };
                
                // Set external subscription ID
                result.Result = Guid.NewGuid().ToString();

                #endregion

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

        [Route("Subscriptions/UpgradeToPaid")]
        public override IHttpActionResult SubscriptionsUpgradeToPaid(ServiceDefinition definition)
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