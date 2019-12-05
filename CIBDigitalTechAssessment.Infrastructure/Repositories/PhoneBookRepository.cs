using CIBDigitalTechAssessment.Core.Dtos;
using CIBDigitalTechAssessment.Core.Dtos.Response.GatewayResponses.Repositories;
using CIBDigitalTechAssessment.Core.Dtos.Responses.PhoneBook;
using CIBDigitalTechAssessment.Core.Entities;
using CIBDigitalTechAssessment.Core.Interfaces.Gateways.Repositories;
using CIBDigitalTechAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIBDigitalTechAssessment.Infrastructure.Repositories
{
    public class PhoneBookRepository : EfRepository<PhoneBook>, IPhoneBookRepository
    {
        public PhoneBookRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<Response> Create(string name)
        {
            try
            {
                var phoneBook = new PhoneBook(name);
                await Add(phoneBook);
                return new Response(Guid.NewGuid().ToString(), true, null);
            }
            catch (Exception ex)
            {
                List<Error> errors = new List<Error>();
                var error = new Error("500", ex.Message);
                errors.Add(error);
                return new Response(Guid.NewGuid().ToString(), true, errors.Select(e => new Error(e.Code, e.Description)));
            }
        }

        public async Task<IEnumerable<PhoneBookDto>> GetPhoneBooks()
        {
            var phoneBooks = from p in _appDbContext.PhoneBooks
                             select new PhoneBookDto
                             {
                                 Id = p.Id,
                                 PhoneBookName = p.Name,
                                 Entry = p.Entries.ToList()
                             };
            return await phoneBooks.ToListAsync();
        }

        public async Task<IEnumerable<PhoneBookDto>> GetPhoneBookEntryByName(int phoneBookId, string name)
        {
            var phoneBooks = from p in _appDbContext.PhoneBooks
                             where p.Id == phoneBookId
                             select new PhoneBookDto
                             {
                                 Id = p.Id,
                                 PhoneBookName = p.Name,
                                 Entry = p.Entries.Where(x => x.Name == name).ToList()
                             };
            return await phoneBooks.ToListAsync();
        }
    }
}
