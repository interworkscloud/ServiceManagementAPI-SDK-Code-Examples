using Interworks.Extensions.Models.CustomFields;
using Interworks.Extensions.Models.Fields;
using Interworks.Extensions.Models.ProductTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServiceManagerExample.Code
{
    public static class FieldsHelper
    {
        public static FieldCollection GetFieldsCollection(Guid ActionLogUUID)
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
                    IsRequired = true,
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
                    IsRequired = true,
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
            ProductsCollection pCollection = new ProductsCollection();

            pCollection.Products = new List<Product>()
            {
                        new Product()
                        {
                            ID = "VndorXStandard",
                            Code = "VendorXStandard",
                            Name = "Vendor X - Standard Edition",
                            Derivative = Derivative.SUBSCRIPTION,
                            IsActivated = true,
                            UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.Prices },
                            UnitBillingCycles = new List<ProductUnitBillingCycle>(){ ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually},
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
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Monthly, Cost = 33.5M, Price=40M},
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Annually, Cost = 350M, Price=360M}
                                    }
                                }
                            }
                        },
                        new Product()
                        {
                            ID = "VndorXProfessional",
                            Code = "VendorXProfessional",
                            Name = "Vendor X - Professional Edition",
                            Derivative = Derivative.SUBSCRIPTION,
                            IsActivated = true,
                            UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.Prices },
                            UnitBillingCycles = new List<ProductUnitBillingCycle>(){ ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually},
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
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Monthly, Cost = 33.5M, Price=40M},
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Annually, Cost = 350M, Price=360M}
                                    }
                                }
                            }
                        },
                        new Product()
                        {
                            ID = "VndorXEnterprise",
                            Code = "VendorXEnterprise",
                            Name = "Vendor X - Enterprise Edition",
                            Derivative = Derivative.SUBSCRIPTION,
                            IsActivated = true,
                            UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.Prices },
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
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Monthly, Cost = 33.5M, Price=40M},
                                        new UnitDefinition(){ BillingCycle = ProductUnitBillingCycle.Annually, Cost = 350M, Price=360M}
                                    }
                                }
                            }
                        }
            };

            //    pCollection.Addons = GetAddons(pCollection.Products);

            return pCollection;
        }

            //private List<Addon> GetAddons(IList<Product> productsCollection)
            //{
            //    var addons = new List<Addon>();

            //    var curProductId = "FastPrivateNetworkInThessaloniki";
            //    var curProductItem = GetFirstOrDefaultProductById(productsCollection, curProductId);
            //    var curProductAttribute = GetFirstOrDefaultAttributeByProductId(curProductItem);

            //    addons.Add(new Addon()
            //    {
            //        ID = "AddonFastPrivateNetworkInThessaloniki",
            //        Code = "AddonFastPrivateNetworkInThessaloniki",
            //        Name = "Fast Private Network in Thessaloniki Addon",
            //        Description = "Fast Private Network in Thessaloniki Addon",
            //        ChargeType = ProductChargeType.RecurringPayPerUse,
            //        UnitBillingCycles = new List<ProductUnitBillingCycle>() { ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually },
            //        UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.UnitBillingCycles, UpdateOptions.Prices },
            //        UsageType = AddonUsageType.Allocated,
            //        ChargeRule = AddonChargeRule.Full,
            //        Products = new List<string>() { curProductItem == null ? curProductId : curProductItem.ID },
            //        Attributes = new List<Attribute>()
            //        {
            //            curProductItem == null || curProductAttribute == null
            //            ? new Attribute()
            //                {
            //                    ID = "DummyProductAttrCloudID",
            //                    Values = new List<object>() { "Thessaloniki" }
            //                }
            //            : curProductAttribute
            //        },
            //        Prices = new List<PriceDefinition>()
            //        {
            //            GetPriceEntity(_euroCurrency, 8.5M, 10M),
            //            GetPriceEntity(_usdCurrency, 9.5M, 11M)
            //        }
            //    });

            //    curProductId = "FastPrivateNetworkInAthens";
            //    curProductItem = GetFirstOrDefaultProductById(productsCollection, curProductId);
            //    curProductAttribute = GetFirstOrDefaultAttributeByProductId(curProductItem);

            //    addons.Add(new Addon()
            //    {
            //        ID = "AddonFastPrivateNetworkInAthens",
            //        Code = "AddonFastPrivateNetworkInAthens",
            //        Name = "Fast Private Network in Athens Addon",
            //        Description = "Fast Private Network in Athens Addon",
            //        ChargeType = ProductChargeType.RecurringPayPerUse,
            //        UnitBillingCycles = new List<ProductUnitBillingCycle>() { ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually },
            //        UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.UnitBillingCycles, UpdateOptions.Prices },
            //        UsageType = AddonUsageType.Metered,
            //        ChargeRule = AddonChargeRule.Partial,
            //        Products = new List<string>() { curProductItem == null ? curProductId : curProductItem.ID },
            //        Attributes = new List<Attribute>()
            //        {
            //            curProductItem == null || curProductAttribute == null
            //            ? new Attribute()
            //                {
            //                    ID = "DummyProductAttrNetworkID",
            //                    Values = new List<object>() { "Private" }
            //                }
            //            : curProductAttribute
            //        },
            //        Prices = new List<PriceDefinition>()
            //        {
            //            GetPriceEntity(_euroCurrency, 6.5M, 8M),
            //            GetPriceEntity(_usdCurrency, 7.5M, 9M)
            //        }
            //    });

            //    curProductId = "FastSharedNetworkInThessaloniki";
            //    curProductItem = GetFirstOrDefaultProductById(productsCollection, curProductId);
            //    curProductAttribute = GetFirstOrDefaultAttributeByProductId(curProductItem);

            //    addons.Add(new Addon()
            //    {
            //        ID = "AddonFastSharedNetworkInThessaloniki",
            //        Code = "AddonFastSharedNetworkInThessaloniki",
            //        Name = "Fast Shared Network in Thessaloniki Addon",
            //        Description = "Fast Shared Network in Thessaloniki Addon",
            //        ChargeType = ProductChargeType.RecurringPayPerUse,
            //        UnitBillingCycles = new List<ProductUnitBillingCycle>() { ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually },
            //        UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.UnitBillingCycles, UpdateOptions.Prices },
            //        UsageType = AddonUsageType.Allocated,
            //        ChargeRule = AddonChargeRule.Partial,
            //        Products = new List<string>() { curProductItem == null ? curProductId : curProductItem.ID },
            //        Attributes = new List<Attribute>()
            //        {
            //            curProductItem == null || curProductAttribute == null
            //            ? new Attribute()
            //                {
            //                    ID = "DummyProductAttrCloudID",
            //                    Values = new List<object>() { "Thessaloniki" }
            //                }
            //            : curProductAttribute
            //        },
            //        Prices = new List<PriceDefinition>()
            //        {
            //            GetPriceEntity(_euroCurrency, 11.5M, 13M),
            //            GetPriceEntity(_usdCurrency, 13.5M, 17M)
            //        }
            //    });

            //    curProductId = "FastSharedNetworkInAthens";
            //    curProductItem = GetFirstOrDefaultProductById(productsCollection, curProductId);
            //    curProductAttribute = GetFirstOrDefaultAttributeByProductId(curProductItem);

            //    addons.Add(new Addon()
            //    {
            //        ID = "AddonFastSharedNetworkInAthens",
            //        Code = "AddonFastSharedNetworkInAthens",
            //        Name = "Fast Shared Network in Athens Addon",
            //        Description = "Fast Shared Network in Athens Addon",
            //        ChargeType = ProductChargeType.RecurringPayPerUse,
            //        UnitBillingCycles = new List<ProductUnitBillingCycle>() { ProductUnitBillingCycle.Monthly, ProductUnitBillingCycle.Annually },
            //        UpdateOptions = new List<UpdateOptions>() { UpdateOptions.Name, UpdateOptions.UnitBillingCycles, UpdateOptions.Prices },
            //        UsageType = AddonUsageType.Metered,
            //        ChargeRule = AddonChargeRule.Partial,
            //        Products = new List<string>() { curProductItem == null ? curProductId : curProductItem.ID },
            //        Attributes = new List<Attribute>()
            //        {
            //            curProductItem == null || curProductAttribute == null
            //            ? new Attribute()
            //                {
            //                    ID = "DummyProductAttrNetworkID",
            //                    Values = new List<object>() { "Shared" }
            //                }
            //            : curProductAttribute
            //        },
            //        Prices = new List<PriceDefinition>()
            //        {
            //            GetPriceEntity(_euroCurrency, 5.5M, 7M),
            //            GetPriceEntity(_usdCurrency, 6.5M, 8M)
            //        }
            //    });

            //    return addons;
            //}

            //private Product GetFirstOrDefaultProductById(IList<Product> productsCollection, string productId)
            //    => productsCollection?.FirstOrDefault(p => p.ID.Equals(productId));

            //private Attribute GetFirstOrDefaultAttributeByProductId(Product productItem)
            //    => productItem?.Attributes?.FirstOrDefault();



            //private PriceDefinition GetPriceEntity(string currencyMnemonic, decimal cost, decimal price)
            //=> new PriceDefinition()
            //{
            //    Currency = currencyMnemonic,
            //    Units = new List<UnitDefinition>()
            //    {
            //        new UnitDefinition()
            //        {
            //            BillingCycle = ProductUnitBillingCycle.Monthly,
            //            Cost = cost,
            //            Price = price
            //        },
            //        new UnitDefinition()
            //        {
            //            BillingCycle = ProductUnitBillingCycle.Annually,
            //            Cost = cost * 12M,
            //            Price = price * 12M
            //        }
            //    }
            //};


            #endregion
        }
}
