using CIBDigitalTechAssessment.Core.Shared;
using System.Collections.Generic;

namespace CIBDigitalTechAssessment.Core.Entities
{
    public class PhoneBook : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Entry> Entries { get; set; }
        internal PhoneBook() { }
        internal PhoneBook(string name)
        {
            Name = name;
        }
    }
}
