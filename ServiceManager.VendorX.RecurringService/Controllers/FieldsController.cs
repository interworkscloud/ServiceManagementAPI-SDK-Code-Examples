using Interworks.Cloud.ServiceManagersSDK.Libraries.Controllers;
using Interworks.Cloud.ServiceManagersSDK.Libraries.Logs;
using Interworks.Extensions.Models.Fields;
using Interworks.Extensions.Models.ProductTypes;
using ServiceManager.VendorX.RecurringService.Code;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServiceManager.VendorX.RecurringService.Controllers
{
    public partial class ExampleController : ServiceManagerBaseController
    {
        [Route("Fields/Get")]
        public override IHttpActionResult FieldsGet()
        {
            using (LogTracer tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID))
            {
                return SuccessResult(ActionLogUUID, FieldsHelper.GetFieldsCollection());
            }
        }

        [Route("Fields/Validate")]
        public override IHttpActionResult FieldsValidate(FieldCollection fields)
        {
            List<string> errors = new List<string>() { };

            using (LogTracer tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { fields }))
            {
                var country = fields.Fields.SingleOrDefault(r => r.ID.Equals("Country")).GetSingleValue().ToString();

                if (!FieldsHelper.ValidateCredentials(country))
                {
                    errors.Add("Invalid Country code");
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
        
        [Route("Fields/AdditionalInfo")]
        public override IHttpActionResult GetAdditionalInfo()
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID))
            {
                string a = _excelFile;
                return SuccessResult(ActionLogUUID, string.Empty);
            }
        }
    }
}