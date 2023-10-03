using System;
using System.Collections.Generic;
using System.Web.Http;


namespace ServiceManager.VendorX.RecurringService.Controllers
{
    using Interworks.Cloud.ServiceManagersSDK.Libraries.Controllers;
    using Interworks.Cloud.ServiceManagersSDK.Libraries.Logs;
    using Interworks.Extensions.Models.Requests;
    using Interworks.Extensions.Models.Responses;
    using Interworks.Extensions.Models.Results;
    using Interworks.Extensions.Models.Users;
    using Newtonsoft.Json;

    public partial class ExampleController : ServiceManagerBaseController
    {
        [Route("Users/Add")]
        public override IHttpActionResult UsersAdd(UserDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { definition }))
            {
                ResultDefinition result = new ResultDefinition();

                try
                {
                    //...do something on the other side to create a new user

                    // The external ussr Id
                    result.Code = 0;
                    result.Result = Guid.NewGuid().ToString();
                    result.Message = "User created successfully";
                }
                catch(Exception ex)
                {
                    result.Code = -1;
                    result.Message = "Error while creating user.";
                }                

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Update")]
        public override IHttpActionResult UsersUpdate(UserDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { definition }))
            {
                ResultDefinition result = new ResultDefinition();

                try
                {
                    //...do something on the other side to update existing user

                    result.Code = 0;
                    result.Result = definition.ID;
                    result.Message = "User updated successfully";
                }
                catch (Exception ex)
                {
                    result.Code = -1;
                    result.Message = "Error while updating user.";
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Provision")]
        public override IHttpActionResult UsersProvision(UserDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { definition }))
            {
                ResultDefinition result = new ResultDefinition();

                try
                {
                    //...do something on the other side to provision an user

                    result.Code = 0;
                    result.Result = definition.ID;
                    result.Message = "User provisioned successfully";
                }
                catch (Exception ex)
                {
                    result.Code = -1;
                    result.Message = "Error while provisioning user.";
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/DeProvision")]
        public override IHttpActionResult UsersDeProvision(UserDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { definition }))
            {
                ResultDefinition result = new ResultDefinition();

                try
                {
                    //...do something on the other side to deprovision an user

                    result.Code = 0;
                    result.Result = definition.ID;
                    result.Message = "User deprovisioned successfully";
                }
                catch (Exception ex)
                {
                    result.Code = -1;
                    result.Message = "Error while deprovisioning user.";
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Disable")]
        public override IHttpActionResult UsersDisable(UserDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { definition }))
            {
                ResultDefinition result = new ResultDefinition();

                try
                {
                    //...do something on the other side to disable an user

                    result.Code = 0;
                    result.Result = definition.ID;
                    result.Message = "User disabled successfully";
                }
                catch (Exception ex)
                {
                    result.Code = -1;
                    result.Message = "Error while disabling user.";
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Activate")]
        public override IHttpActionResult UsersActivate(UserDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { definition }))
            {
                ResultDefinition result = new ResultDefinition();

                try
                {
                    //...do something on the other side to activate an user

                    result.Code = 0;
                    result.Result = definition.ID;
                    result.Message = "User activated successfully";
                }
                catch (Exception ex)
                {
                    result.Code = -1;
                    result.Message = "Error while activating user.";
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Get")]
        public override IHttpActionResult UsersGet(UserDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { definition }))
            {
                var result = new UserDefinition();
                try
                {
                    //...do something on the other side to find existing user details
                    //...and update the following lines accordingly

                    result.ID = definition.ID;
                    result.Customer = definition.Customer;
                    result.Status = UserStatus.Provisioned;
                    result.Username = "john.doe";
                    result.Email = "john.doe@test.com";
                    result.FirstName = "John";
                    result.LastName = "Doe";
                    result.DisplayName = "John Doe";
                    result.SecondaryEmail = "john.doe@secondary.com";
                    result.TotalServices = 3;

                }catch(Exception ex)
                {
                    throw new Exception("User Get error!");
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Get/List")]
        public override IHttpActionResult UsersGetUsersList(UsersListRequest criteria)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { criteria }))
            {
                var result = new UsersListResponse()
                {
                };

                try
                {
                    //...do something on the other side to find users given the available request criteria
                    //...and update the following lines accordingly

                    //example users list
                    var users = new List<UserDefinition>() {
                        new UserDefinition() { ID="user_1" }, //add more details here
                        new UserDefinition() { ID="user_2" }, //add more details here 
                        new UserDefinition() { ID="user_3" }  //add more details here
                    };

                    //example available services list
                    var services = new List<UserService>() {
                        new UserService("service_1","Service 1"),
                        new UserService("service_2","Service 2"),
                        new UserService("service_3","Service 3"),
                    };

                    //Result
                    result.Users = users;
                    result.TotalUsers = users.Count;
                    result.AvailableServices = services;
                }
                catch (Exception ex)
                {
                    throw new Exception("User Get List error!");
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Delete")]
        public override IHttpActionResult UsersDelete(UserDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { definition }))
            {
                ResultDefinition result = new ResultDefinition();

                try
                {
                    //...do something on the other side to delete an user

                    result.Code = 0;
                    result.Result = definition.ID;
                    result.Message = "User deleted successfully";
                }
                catch (Exception ex)
                {
                    result.Code = -1;
                    result.Message = "Error while deleting user.";
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Service/Add")]
        public override IHttpActionResult UsersAddService(UserSetServiceRequest request)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { request }))
            {
                ResultDefinition result = new ResultDefinition();

                try
                {
                    //...do something on the other side to assign service to user

                    result.Code = 0;
                    result.Result = request.User.ID;
                    result.Message = "User service added successfully";
                }
                catch (Exception ex)
                {
                    result.Code = -1;
                    result.Message = "Error while adding service to user.";
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Service/Delete")]
        override public IHttpActionResult UsersRemoveService(UserSetServiceRequest request)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { request }))
            {
                ResultDefinition result = new ResultDefinition();

                try
                {
                    //...do something on the other side to remove service from user

                    result.Code = 0;
                    result.Result = request.User.ID;
                    result.Message = "User service removed successfully";
                }
                catch (Exception ex)
                {
                    result.Code = -1;
                    result.Message = "Error while removing service from user.";
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Get/Customer")]
        public override IHttpActionResult UsersGetCustomer(CustomerDefinition customer)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { customer }))
            {
                CustomerDefinition result = new CustomerDefinition();

                try
                {
                    //...do something on the other side to find existing customer details
                    //...and update the following lines accordingly

                    //example customer details
                    result.ID = customer.ID;
                result.Name = "Cloud Company";
                result.PrimaryDomain = "cloudcompany.com";
                result.Status = CustomerStatus.Provisioned;
                result.TotalUsers = 5;
                }
                catch (Exception ex)
                {
                    throw new Exception("Users Get Customer failed!");
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Get/Customers")]
        public override IHttpActionResult UsersGetCustomersList(CustomersListRequest criteria)
        {
            using (var tracer = new LogTracer(LogActionInput,
                                              Logging,
                                              ActionName,
                                              ActionLogUUID,
                                              new List<object>() { criteria }))
            {
                CustomersListResponse result = new CustomersListResponse();

                try
                {
                    //...do something on the other side to find existing customers given the provided ctiretia
                    //...and update the following lines accordingly

                    //example customer details
                    var customers = new List<CustomerDefinition>()
                    {
                        new CustomerDefinition(){ ID="customer_1"}, //update more details here
                        new CustomerDefinition(){ ID="customer_2"}, //update more details here
                        new CustomerDefinition(){ ID="customer_3"}, //update more details here
                    };
                
                    result.Customers = customers;
                    result.TotalCustomers = customers.Count;
                }
                catch (Exception ex)
                {
                    throw new Exception("Users Get Customers List failed!");
                }
               

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Service/Get/List")]
        public override IHttpActionResult UsersGetUserServices(UserDefinition definition)
        {
            using (var tracer = new LogTracer(LogActionInput,
                      Logging,
                      ActionName,
                      ActionLogUUID,
                      new List<object>() { definition }))
            {
                var result = new UserServiceCollection();

                    try
                {
                    //example available services list
                    var services = new List<UserService>() {
                        new UserService("service_1","Service 1"),
                        new UserService("service_2","Service 2"),
                        new UserService("service_3","Service 3"),
                    };

                    result.Services = services;

                }catch(Exception ex)
                {
                    throw new Exception("Users Get User Services failed!");
                }

                return SuccessResult(ActionLogUUID, result);
            }
        }

        [Route("Users/Password/Reset")]
        public override IHttpActionResult UsersResetPassword(UserDefinition definition)
        {

            ResultDefinition result = new ResultDefinition();

            try
            {
                //...do something on the other side to reset user's password

                result.Code = 0;
                result.Result = definition.ID;
                result.Message = "User password reseted successfully";
            }
            catch (Exception ex)
            {
                result.Code = -1;
                result.Message = "Error while resetting user password.";
            }

            return SuccessResult(ActionLogUUID, result);
        }
    }
}