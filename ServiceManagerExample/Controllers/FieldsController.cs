using Interworks.Cloud.ServiceManagersSDK.Libraries.Controllers;
using Interworks.Cloud.ServiceManagersSDK.Libraries.Logs;
using Interworks.Extensions.Models.Fields;
using Interworks.Extensions.Models.ProductTypes;
using ServiceManagerExample.Code;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServiceManagerExample.Controllers
{
    public partial class ExampleController : ServiceManagerBaseController
    {
        [Route("Fields/Get")]
        public override IHttpActionResult FieldsGet()
        {
            using (LogTracer tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID))
            {
                return SuccessResult(ActionLogUUID, FieldsHelper.GetFieldsCollection(ActionLogUUID));
            }
        }

        [Route("Fields/Validate")]
        public override IHttpActionResult FieldsValidate(FieldCollection fields)
        {
            List<string> errors = new List<string>() { };

            using (LogTracer tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { fields }))
            {
                var username = fields.Fields.SingleOrDefault(r => r.ID.Equals("FieldUsername")).GetSingleValue().ToString();
                var password = fields.Fields.SingleOrDefault(r => r.ID.Equals("FieldPassword")).GetSingleValue().ToString();

                if (!FieldsHelper.ValidateCredentials(username, password))
                {
                    errors.Add("Invalid credentials");
                }

                return SuccessResult(ActionLogUUID, errors);
            }
        }

        [Route("Fields/ServiceDefinition")]
        public override IHttpActionResult FieldsServiceDefinition()
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID))
            {
                ProductTypeCollection productTypeCollection = new ProductTypeCollection()
                {
                    ProductTypes = FieldsHelper.GetProductTypes()
                };

                return SuccessResult(ActionLogUUID, productTypeCollection);
            }
        }

        public override IHttpActionResult GetAdditionalInfo()
        {
            throw new System.NotImplementedException();
        }
    }
}