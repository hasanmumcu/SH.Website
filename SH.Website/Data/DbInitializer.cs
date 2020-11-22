using NPoco.Expressions;
using OpenXmlPowerTools;
using SH.Website.Models;
using SH.Website.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SH.Website.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            Seed(context);
        }

        private static void Seed(ApplicationDbContext context)
        {
            if (!context.Index.Any(s => s.Active))  
            {
                context.Index.Add(new IndexModel
                {
                    Active = true,
                    Partials = new[]
                    {
                        new PartialModel
                        {
                            PartialName = "_FullWidthBanner",
                            Order = 0,
                            Active = true,
                            PartialCode = 100,
                            PartialCodeValue = "FullWidthBanner"

                        },
                        new PartialModel
                        {
                            PartialName = "_Navigation",
                            Order = 1,
                            Active = true,
                            PartialCode = 101,
                            PartialCodeValue = "Navigation"

                        },
                        new PartialModel
                        {
                            PartialName = "_About",
                            Order = 2,
                            Active = true,
                            PartialCode = 102,
                            PartialCodeValue = "About"

                        },
                        new PartialModel
                        {
                            PartialName = "_Banner",
                            Order = 3,
                            Active = true,
                            PartialCode = 103,
                            PartialCodeValue = "Banner"

                        },
                        new PartialModel
                        {
                            PartialName = "_Work",
                            Order = 4,
                            Active = true,
                            PartialCode = 104,
                            PartialCodeValue = "Work"

                        },
                        new PartialModel
                        {
                            PartialName = "_FunFacts",
                            Order = 5,
                            Active = true,
                            PartialCode = 105,
                            PartialCodeValue = "FunFacts"

                        },
                        new PartialModel
                        {
                            PartialName = "_OurTeam",
                            Order = 6,
                            Active = true,
                            PartialCode = 106,
                            PartialCodeValue = "OurTeam"

                        },
                        new PartialModel
                        {
                            PartialName = "_Pricing",
                            Order = 7,
                            Active = true,
                            PartialCode = 107,
                            PartialCodeValue = "Pricing"

                        },
                        new PartialModel
                        {
                            PartialName = "_ClientsCarousel",
                            Order = 8,
                            Active = true,
                            PartialCode = 108,
                            PartialCodeValue = "ClientsCarousel"

                        },
                        new PartialModel
                        {
                            PartialName = "_Banner2",
                            Order = 9,
                            Active = true,
                            PartialCode = 109,
                            PartialCodeValue = "Banner2"

                        },
                        new PartialModel
                        {
                            PartialName = "_Contact",
                            Order = 10,
                            Active = true,
                            PartialCode = 110,
                            PartialCodeValue = "Contact"
                        }

                        //},
                        //new PartialModel
                        //{
                        //    PartialName = "_Login",
                        //    Order =11,
                        //    Active = true,
                        //    PartialCode = 111,
                        //    PartialCodeValue = "Login"

                        //},
                        //new PartialModel
                        //{
                        //    PartialName = "_Register",
                        //    Order = 12,
                        //    Active = true,
                        //    PartialCode = 112,
                        //    PartialCodeValue = "Register"

                        //}

                    }

                });

                context.SaveChanges();

            }


        }
    }
}
