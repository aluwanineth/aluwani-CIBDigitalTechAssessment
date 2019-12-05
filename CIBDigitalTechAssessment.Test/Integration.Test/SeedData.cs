using CIBDigitalTechAssessment.Core.Entities;
using CIBDigitalTechAssessment.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIBDigitalTechAssessment.Test.Integration.Test
{
    public static class SeedData
    {        
        public static void PopulateTestData(AppDbContext dbContext)
        {
            var phoneBook = new PhoneBook("Aluwani Phone Book");
            dbContext.PhoneBooks.Add(phoneBook);
            dbContext.SaveChanges();

            var entry = new Entry("Aluwani Nethavhakone","0813675364",1);
            dbContext.Entries.Add(entry);
            dbContext.SaveChanges();
        }
    }
}
