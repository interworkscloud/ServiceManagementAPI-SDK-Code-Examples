using Interworks.Extensions.Models.CustomFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServiceManagerSDK.Example.RecurringServices.Code
{
    public static class AccountsHelper
    {
        private static string _syncOptionName = "PrimaryIDName";
        private static string _syncOptionAdminName = "PrimaryIDAdminName";
        private static string _syncOptionExternalId = "PrimaryIDExternalID";

        public static CustomFieldCollection GetSyncOptions()
        {
            return new CustomFieldCollection()
            {
                Fields = new List<CustomField>()
                    {
                        new CustomField(_syncOptionName)
                        {
                            Definition = new CustomFieldDefinition
                            {
                                ID = _syncOptionName,
                                Name = "Primary ID Name",
                                Kind = CustomFieldKind.SimpleValue,
                                DataType = CustomFieldDataType.Text,
                                AvailableToStorefront=true,
                                IsRequired = false
                            }
                        },
                        new CustomField(_syncOptionAdminName)
                        {
                            Definition = new CustomFieldDefinition
                            {
                                ID = _syncOptionAdminName,
                                Name = "Primary ID Admin Name",
                                Kind = CustomFieldKind.SimpleValue,
                                DataType = CustomFieldDataType.Text,
                                AvailableToStorefront=true,
                                IsRequired = false
                            }
                        },
                        new CustomField(_syncOptionExternalId)
                        {
                            Definition = new CustomFieldDefinition
                            {
                                ID = _syncOptionExternalId,
                                Name = "Primary ID External ID",
                                Kind = CustomFieldKind.SimpleValue,
                                DataType = CustomFieldDataType.Text,
                                AvailableToStorefront=true,
                                IsRequired = false
                            }
                        }
                    }
            };
        }
    }
}
