using Interworks.Cloud.ServiceManagersSDK.Libraries.Controllers;
using Interworks.Cloud.ServiceManagersSDK.Libraries.Logs;
using Interworks.Extensions.Models.Accounts;
using Interworks.Extensions.Models.Results;
using ServiceManagerExample.Code;
using ServiceManagerSDK.Example.RecurringServices.Code;
using System.Collections.Generic;
using System.Web.Http;

namespace ServiceManagerExample.Controllers
{
    public partial class ExampleController : ServiceManagerBaseController
    {
        [Route("Accounts/SyncOptions")]
        public override IHttpActionResult AccountsSychronizationOptions()
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID))
            {
                return SuccessResult(ActionLogUUID, AccountsHelper.GetSyncOptions());
            }
        }

        [Route("Accounts/Exists")]
        public override IHttpActionResult AccountsExists(AccountDefinition account)
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { account }))
            {
                bool exists = false;
                ResultDefinition result;

                //...check if account exists on the other system

                if (!exists)
                    result = new ResultDefinition() { Code = 0, Message = "Account does not exists on third system." };
                else
                    result = new ResultDefinition() { Code = 1, Message = "Account alread exists on third system.", Result = "account_on_other_system", ResultUser = "user_on_other_system" };

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Accounts/Synchronize")]
        public override IHttpActionResult AccountsSychronize(AccountDefinition account)
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { account }))
            {
                AccountResultDefinition result = new AccountResultDefinition()
                {
                    Code = 0,
                    Message = "Account synchronized"
                };

                //... implement your synchronization procedure

                result.Result = System.Guid.NewGuid().ToString();

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Accounts/Delete")]
        public override IHttpActionResult AccountsDelete(AccountDefinition account)
        {
            using (var tracer = new LogTracer(LogActionInput, Logging, ActionName, ActionLogUUID, new List<object>() { account }))
            {
                ResultDefinition result = new ResultDefinition()
                {
                    Code = 0,
                    Message = "Account deleted"
                };

                //... implement your delete procedure

                result.Result = account.ExternalID;

                return SuccessResult(ActionLogUUID, result);
            }
        }       
    }
}