using Interworks.Extensions.Models.CustomFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServiceManagerSDK.Example.RecurringServices.Code
{
    public static class AccountsHelper
    {
        private static string _syncOptUsername = "username";
        private static string _syncOptRole = "role";

        public static CustomFieldCollection GetSyncOptions()
        {
            return new CustomFieldCollection()
            {
                Fields = new List<CustomField>()
                    {
                        new CustomField(_syncOptUsername)
                        {
                            Definition = new CustomFieldDefinition
                            {
                                ID = _syncOptUsername,
                                Name = "Username",
                                Kind = CustomFieldKind.SimpleValue,
                                DataType = CustomFieldDataType.Text,
                                IsRequired = true
                            }
                        },
                        new CustomField(_syncOptRole)
                        {
                            Definition = new CustomFieldDefinition(new Dictionary<string, string>{
                                { "1", "User" },
                                { "2", "Reseller" }
                            })
                            {
                                ID = _syncOptRole,
                                Name = "Role",
                                Kind = CustomFieldKind.List,
                                DataType = CustomFieldDataType.Text,
                                IsRequired = true
                            }
                        }
                    }
            };
        }
    }
}
