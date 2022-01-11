using Interworks.Extensions.Models.CustomFields;
using Interworks.Extensions.Models.Fields;
using Interworks.Extensions.Models.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServiceManager.VendorX.RecurringService.Code
{
    public static class FieldsHelper
    {
        public static FieldCollection GetFieldsCollection()
        {
            return new FieldCollection()
            {
                Fields = new List<Field>()
                {
                    new Field()
                    {
                        ID = "Country",
                        Definition = new FieldDefinition()
                        {
                            ID = "Country",
                            Name = "Country",
                            Description = "The country the services will be delivered",
                            Kind = FieldKind.Text,
                            MaxLength = 2,
                            IsRequired = true,
                            SortOrder = 1
                        }
                    },
                    new Field()
                    {
                        ID = "password",
                        Definition = new FieldDefinition()
                        {
                            ID = "password",
                            Name = "Password",
                            Description = "The password",
                            Kind = FieldKind.PasswordText,
                            MaxLength = 100,
                            IsRequired = true,
                            SortOrder = 2
                        }
                    },
                    new Field()
                    {
                        ID = "certificatefile",
                        Definition = new FieldDefinition()
                        {
                            ID = "certificatefile",
                            Name = "Certificate File",
                            Description = "The country the services will be delivered",
                            Kind = FieldKind.CertificateFile,
                            MaxLength = 3,
                            IsRequired = true,
                            SortOrder = 2
                        }
                    },
                    new Field()
                    {
                        ID = "excelfile",
                        Definition = new FieldDefinition()
                        {
                            ID = "excelfile",
                            Name = "Pricing File",
                            Description = "The country the services will be delivered",
                            Kind = FieldKind.File,
                            MaxLength = 4,
                            IsRequired = true,
                            SortOrder = 3
                        }
                    }
                    //new Field()
                    //{
                    //    ID="attestation",
                    //    Definition = new FieldDefinition()
                    //    {
                    //        ID="attestation",
                    //        Name="Partner Attestation",
                    //        Description="Partner Attestations approval is required to enable provisioning of services",
                    //        Kind = FieldKind.TermsOfUse,
                    //        IsRequired = true,
                    //        SortOrder=4,
                    //        TermOfUseMessages = new TermOfUseMessagesDefinition()
                    //        {
                    //            Accept= "The Partner Attestation affects all purchases<script>alert('ok')</script> of products from this instance on both BSS and Storefront.<br/>By accepting the Partner Attestation:<br/><b>For every purchase, I confirm that my organization is acting as an Indirect Partner when choosing a Reseller and as a Direct Partner in the absence of selecting a reseller.</b>",
                    //            Accepted= "For every purchase of products from this instance, I confirm that my organization is acting as an Indirect Partner when choosing a Reseller and as a Direct Partner in the absence of selecting a reseller.",
                    //            Revoke= "Revoking the Partner Attestation for this instance will block new purchases of products from this instance on both BSS and Storefront.<br/>Are you sure?"
                    //        }
                    //    }
                    //}                    
                }
            };
        }
        public static bool ValidateCredentials(string country)
        {
            bool success = false;

            // Validate the given credentials and return true if success or false on failure
            if (!string.IsNullOrEmpty(country) && country.Equals("GR"))
                success = true;

            return success;
        }

        #region Get Service Definition

        public static ICollection<ProductTypeDefinition> GetProductTypes()
        {
            return new List<ProductTypeDefinition>() {
                        new ProductTypeDefinition("VenderXSubscriptionBased", GetAttributes(), GetProducts())
                        {
                            ID = "VenderXSubscriptionBased",
                            Name = "Vendor X - Subscription-based Service",
                            AutoExecuteAddonCancelRequest = true,
                            Description = "Subcription based services provided by Vendor X",
                            Derivative = Derivative.SUBSCRIPTION,
                            PortalUrl = "https://vendorx.portal.com",
                            CustomFieldCollection = new CustomFieldCollection(){
                                        Fields = new List<CustomField>(){
                                            new CustomField(){
                                                ID = "VendorXOfferId",
                                                Definition = new CustomFieldDefinition(){
                                                                    ID = "VendorXOfferId",
                                                                    Name = "Vendor X Offer Id",
                                                                    DataType = CustomFieldDataType.Text,
                                                                    IsRequired = false,
                                                                    IsReadOnly = true,
                                                                    Kind = CustomFieldKind.SimpleValue,
                                                                    AvailableToStorefront = false,
                                                                    SortOrder = 1
                                                }
                                            }
                                        }
                            }
                        }
                };
        }

        private static IList<AttributeDefinition> GetAttributes()
        {
            var plans = new Dictionary<string, string>(){
                                            { "VenderXSubscriptionBasedPlan_StandardEdition", "Vendor X - Standard Plan" },
                                            { "VenderXSubscriptionBasedPlan_ProfessionalEdition", "Vendor X - Professional Plan" },
                                            { "VenderXSubscriptionBasedPlan_EnterpriseEdition", "Vendor X - Enterprise Plan" }
                                        };

            var addonplans = new Dictionary<string, string>(){
                                            { "VenderXSubscriptionBasedAddonPlan_CustomDomain", "Vendor X - Custom Domain" },
                                            { "VenderXSubscriptionBasedAddonPlan_PremiumSupport", "Vendor X - Premium Support" },
                                            { "VenderXSubscriptionBasedAddonPlan_AdvancedReports", "Vendor X - Advanced Reports" }
                                        };


            return new List<AttributeDefinition>()
            {
                new AttributeDefinition(plans)
                {
                    ID = "VenderXSubscriptionBasedPlan",
                    Name = "Vendor X - Plan",
                    IsRequired = false,
                    Kind = AttributeKind.PredefinedChooseOne,
                    KindSpecified = true,
                    Description = "Enables selection of target plan for a product",
                    Usage = AttributeUsage.ProductCharacteristic,
                    UsageSpecified = true
                },
                new AttributeDefinition(addonplans)
                {
                    ID = "VenderXSubscriptionBasedAddonPlan",
                    Name = "Vendor X - Addon Plan",
                    IsRequired = false,
                    Kind = AttributeKind.PredefinedChooseOne,
                    KindSpecified = true,
                    Description = "Enables selection of target addon plan for an addon product",
                    Usage = AttributeUsage.ProductCharacteristic,
                    UsageSpecified = true
                }
            };
        }

        private static ProductsCollection GetProducts()
        {
            return new ProductsCollection()
            {
                Products = new List<Product>()
                {
                        new Product()
                        {
                            ID = "VendorXStandard",
                            Code = "VendorXStandard",
                            Name = "Vendor X - Standard Edition",
                            Derivative = Derivative.SUBSCRIPTION,
                            IsActivated = true,
                            UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.Prices, UpdateOptions.UnitBillingCycles, UpdateOptions.RelatedProducts },
                            UnitBillingCycles = new List<ProductUnitBillingCycle>(){ ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually},
                            RelatedProducts = new List<ProductRelationDefinition>()
                            {
                                new ProductRelationDefinition()
                                {
                                    ProductID = "VendorXProfessional",
                                    Relation = ProductRelation.Upgrade
                                }
                            },
                            Attributes = new List<Interworks.Extensions.Models.ProductTypes.Attribute>()
                            {
                                new Interworks.Extensions.Models.ProductTypes.Attribute()
                                {
                                    ID = "VenderXSubscriptionBasedPlan",
                                    Values = new List<object>() { "VenderXSubscriptionBasedPlan_StandardEdition" }
                                }
                            },
                            UnitType = "My Unit",
                            TrialEnabled=true,
                            TrialDuration =60,
                            TrialDurationType= TrialDurationType.Days,
                            TrialQuantity = 20,
                            Prices = new List<PriceDefinition>()
                            {
                                new PriceDefinition()
                                {
                                    Currency = "EUR",
                                    Units = new List<UnitDefinition>()
                                    {
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Monthly, Cost = 6.5M, Price=10M},
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Annually, Cost = 65M, Price=100M}
                                    }
                                }
                            },
                            BillingOptionRecurringChargePrepaid = new ProductBillingOptionRecurringChargePrepaid()
                            {
                                NoOfDecimals = 2,
                                UpFrontBilling = true,
                                ChargeRule = UsageChargeRuleValues.PARTIAL,
                                BillingDate=BillingDateValues.SpecificBillingDate,
                                SpecificBillingDate = 1,
                                Term = 1,
                                FreePeriod = true
                            }
                        },
                        new Product()
                        {
                            ID = "VendorXProfessional",
                            Code = "VendorXProfessional",
                            Name = "Vendor X - Professional Edition",
                            Derivative = Derivative.SUBSCRIPTION,
                            IsActivated = true,
                            UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.Prices, UpdateOptions.UnitBillingCycles, UpdateOptions.RelatedProducts, UpdateOptions.TrialOffer },
                            UnitBillingCycles = new List<ProductUnitBillingCycle>(){ ProductUnitBillingCycle.Annually, ProductUnitBillingCycle.Monthly},
                            RelatedProducts = new List<ProductRelationDefinition>()
                            {
                                new ProductRelationDefinition()
                                {
                                    ProductID = "VendorXEnterprise",
                                    Relation = ProductRelation.Upgrade
                                }
                            },
                            Attributes = new List<Interworks.Extensions.Models.ProductTypes.Attribute>()
                            {
                                new Interworks.Extensions.Models.ProductTypes.Attribute()
                                {
                                    ID = "VenderXSubscriptionBasedPlan",
                                    Values = new List<object>() { "VenderXSubscriptionBasedPlan_ProfessionalEdition" }
                                }
                            },
                            TrialEnabled=true,
                            TrialDuration =30,
                            TrialDurationType= TrialDurationType.Days,
                            TrialQuantity = 15,
                            Prices = new List<PriceDefinition>()
                            {
                                new PriceDefinition()
                                {
                                    Currency = "EUR",
                                    Units = new List<UnitDefinition>()
                                    {
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Monthly, Cost = 12.5M, Price=15M},
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Annually, Cost = 125.455676948M, Price=150M}
                                    }
                                }
                            },
                            BillingOptionRecurringChargePrepaid = new ProductBillingOptionRecurringChargePrepaid()
                            {
                                UpFrontBilling = true,
                                FreePeriod = true,
                                ChargeRule = UsageChargeRuleValues.PARTIAL,
                                BillingDate=BillingDateValues.SpecificBillingDate,
                                SpecificBillingDate = 1,
                                //LockOptions = new List<RecurringChargePrepaidProductLockOptionItem>()
                                //{
                                //    RecurringChargePrepaidProductLockOptionItem.FreePeriod,
                                //    RecurringChargePrepaidProductLockOptionItem.NoOfDecimals,
                                //    RecurringChargePrepaidProductLockOptionItem.SpecificBillingDate                                    
                                //}
                            }
                        },
                        new Product()
                        {
                            ID = "VendorXEnterprise",
                            Code = "VendorXEnterprise",
                            Name = "Vendor X - Enterprise Edition",
                            Derivative = Derivative.SUBSCRIPTION,
                            IsActivated = true,
                            UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.Prices, UpdateOptions.UnitBillingCycles, UpdateOptions.RelatedProducts },
                            UnitBillingCycles = new List<ProductUnitBillingCycle>(){ ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually},
                            Attributes = new List<Interworks.Extensions.Models.ProductTypes.Attribute>()
                            {
                                new Interworks.Extensions.Models.ProductTypes.Attribute()
                                {
                                    ID = "VenderXSubscriptionBasedPlan",
                                    Values = new List<object>() { "VenderXSubscriptionBasedPlan_EnterpriseEdition" }
                                }
                            },
                            TrialEnabled=true,
                            TrialDuration =60,
                            TrialDurationType= TrialDurationType.Days,
                            Prices = new List<PriceDefinition>()
                            {
                                new PriceDefinition()
                                {
                                    Currency = "EUR",
                                    Units = new List<UnitDefinition>()
                                    {
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Monthly, Cost = 16.5M, Price=20M},
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Annually, Cost = 165M, Price=200M}
                                    }
                                }
                            },
                            BillingOptionRecurringChargePrepaid = new ProductBillingOptionRecurringChargePrepaid()
                            {
                                UpFrontBilling = true,
                                FreePeriod = true,
                                ChargeRule = UsageChargeRuleValues.PARTIAL,
                                BillingDate=BillingDateValues.SpecificBillingDate,
                                SpecificBillingDate = 1,
                                //LockOptions = new List<RecurringChargePrepaidProductLockOptionItem>()
                                //{
                                //    RecurringChargePrepaidProductLockOptionItem.ChargeRule,
                                //    RecurringChargePrepaidProductLockOptionItem.FreePeriod,
                                //    RecurringChargePrepaidProductLockOptionItem.NoOfDecimals,
                                //    RecurringChargePrepaidProductLockOptionItem.SpecificBillingDate,
                                //    RecurringChargePrepaidProductLockOptionItem.Term,
                                //    RecurringChargePrepaidProductLockOptionItem.UpFrontBilling
                                //}
                            }
                        }
                },
                Addons = new List<Addon>()
                {
                    new Addon()
                    {
                        ID = "VendorXCustomDomainAddon",
                        Code = "VendorXCustomDomainAddon",
                        Name = "Vendor X - Custom Domain",
                        Description = "Custom domain addon for Vendor X service",
                        UnitBillingCycles = new List<ProductUnitBillingCycle>() { ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually },
                        UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.UnitBillingCycles, UpdateOptions.Prices },
                        Products = new List<string>() { "VendorXStandard","VendorXProfessional", "VendorXEnterprise" },
                        Attributes = new List<Interworks.Extensions.Models.ProductTypes.Attribute>()
                            {
                                new Interworks.Extensions.Models.ProductTypes.Attribute()
                                {
                                    ID = "VenderXSubscriptionBasedAddonPlan",
                                    Values = new List<object>() { "VenderXSubscriptionBasedAddonPlan_CustomDomain" }
                                }
                            },
                            Prices = new List<PriceDefinition>()
                            {
                                new PriceDefinition()
                                {
                                    Currency = "EUR",
                                    Units = new List<UnitDefinition>()
                                    {
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Monthly, Cost = 1.5M, Price=2M},
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Annually, Cost = 15M, Price=20M}
                                    }
                                }
                            }
                    },
                    new Addon()
                    {
                        ID = "VendorXPremiumSupportAddon",
                        Code = "VendorXPremiumSupportAddon",
                        Name = "Vendor X - Premium Support",
                        Description = "Premium support addon for Vendor X service",
                        UnitBillingCycles = new List<ProductUnitBillingCycle>() { ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually },
                        UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.UnitBillingCycles, UpdateOptions.Prices },
                        Products = new List<string>() { "VendorXProfessional", "VendorXEnterprise" },
                        Attributes = new List<Interworks.Extensions.Models.ProductTypes.Attribute>()
                            {
                                new Interworks.Extensions.Models.ProductTypes.Attribute()
                                {
                                    ID = "VenderXSubscriptionBasedAddonPlan",
                                    Values = new List<object>() { "VenderXSubscriptionBasedAddonPlan_PremiumSupport" }
                                }
                            },
                            Prices = new List<PriceDefinition>()
                            {
                                new PriceDefinition()
                                {
                                    Currency = "EUR",
                                    Units = new List<UnitDefinition>()
                                    {
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Monthly, Cost = 5.5M, Price=6M},
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Annually, Cost = 55M, Price=60M}
                                    }
                                }
                            }
                    },
                    new Addon()
                    {
                        ID = "VendorXAdvancedReportsAddon",
                        Code = "VendorXAdvancedReportsAddon",
                        Name = "Vendor X - Advanced Reports",
                        Description = "Advanced reports addon for Vendor X service",
                        UnitBillingCycles = new List<ProductUnitBillingCycle>() { ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually },
                        UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.UnitBillingCycles, UpdateOptions.Prices },
                        Products = new List<string>() { "VendorXEnterprise" },
                        Attributes = new List<Interworks.Extensions.Models.ProductTypes.Attribute>()
                            {
                                new Interworks.Extensions.Models.ProductTypes.Attribute()
                                {
                                    ID = "VenderXSubscriptionBasedAddonPlan",
                                    Values = new List<object>() { "VenderXSubscriptionBasedAddonPlan_AdvancedReports" }
                                }
                            },
                            Prices = new List<PriceDefinition>()
                            {
                                new PriceDefinition()
                                {
                                    Currency = "EUR",
                                    Units = new List<UnitDefinition>()
                                    {
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Monthly, Cost = 7.5M, Price=10M},
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Annually, Cost = 75M, Price=100M}
                                    }
                                }
                            }
                    }
                }
            };
        }

        #endregion
    }
}
