
using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(ticketContext context)
        {
            if(!context.Companies.Any())
            {
                var companies= new List<Company>
                {
                    new Company
                    {
                        Name="Default",
                        Description="",
                        IsActive=true,
                        CreatedDate=DateTime.Today,
                        UpdatedDate=DateTime.Today,
                    }
                };
                context.Companies.AddRange(companies);
                context.SaveChanges();

            }
        }
    }
}