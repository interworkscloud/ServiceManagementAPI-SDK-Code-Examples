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
                        ID = "FieldUsername",
                        Definition = new FieldDefinition()
                        {
                            ID = "FieldUsername",
                            Name = "Username",
                            Description = "Username info",
                            Kind = FieldKind.Text,
                            MaxLength = 50,
                            IsRequired = true,
                            SortOrder = 1
                        }
                    },
                    new Field()
                    {
                        ID = "FieldPassword",
                        Definition = new FieldDefinition()
                        {
                            ID = "FieldPassword",
                            Name = "Password",
                            Description = "Password info",
                            Kind = FieldKind.PasswordText,
                            MaxLength = 50,
                            IsRequired = true,
                            SortOrder = 2
                        }
                    }
                }
            };
        }
        public static bool ValidateCredentials(string username, string password)
        {
            bool success = false;

            // Validate the given credentials and return true if success or false on failure
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
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
                            Description = "Subcription based services provided by Vendor X",
                            Derivative = Derivative.SUBSCRIPTION,
                            PortalUrl = "https://vendorx.portal.com"
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
                            }
                        },
                        new Product()
                        {
                            ID = "VendorXProfessional",
                            Code = "VendorXProfessional",
                            Name = "Vendor X - Professional Edition",
                            UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.Prices, UpdateOptions.UnitBillingCycles, UpdateOptions.RelatedProducts },
                            UnitBillingCycles = new List<ProductUnitBillingCycle>(){ ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually},
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
                            }
                        },
                        new Product()
                        {
                            ID = "VendorXEnterprise",
                            Code = "VendorXEnterprise",
                            Name = "Vendor X - Enterprise Edition",
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
                        UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.UnitBillingCycles, UpdateOptions.Prices },
                        UnitBillingCycles = new List<ProductUnitBillingCycle>() { ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually },
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
                        UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.UnitBillingCycles, UpdateOptions.Prices },
                        UnitBillingCycles = new List<ProductUnitBillingCycle>() { ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually },
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
                        UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.UnitBillingCycles, UpdateOptions.Prices },
                        UnitBillingCycles = new List<ProductUnitBillingCycle>() { ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually },
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
