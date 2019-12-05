using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIBDigitalTechAssessment.Core.Dtos.Requests.PhoneBook;
using CIBDigitalTechAssessment.Core.Interfaces.PhoneBook;
using CIBDigitalTechAssessment.WebApi.Presenters.PhoneBook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CIBDigitalTechAssessment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBooksController : Controller
    {
        private readonly ICreatePhoneBook _createPhoneBook;
        private readonly IGetPhoneBooks _getPhoneBooks;
        private readonly IGetPhoneBookEntryByName _getPhoneBookEntryByName;
        private readonly PhoneBookPresenter _phoneBookPresenter;

        public PhoneBooksController(ICreatePhoneBook createPhoneBook,
                                     IGetPhoneBooks getPhoneBooks,
                                     IGetPhoneBookEntryByName getPhoneBookEntryByName,
                                     PhoneBookPresenter phoneBookPresenter)
        {
            _createPhoneBook = createPhoneBook;
            _getPhoneBooks = getPhoneBooks;
            _getPhoneBookEntryByName = getPhoneBookEntryByName;
            _phoneBookPresenter = phoneBookPresenter;
        }
            
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await _getPhoneBooks.Handle(new GetPhoneBookRequest(), _phoneBookPresenter);
            return _phoneBookPresenter.ContentResult;
        }

        [HttpGet]
        [Route("GetPhoneBookByName")]
        public async Task<ActionResult> Get(int phoneBookId, string name)
        {
            await _getPhoneBookEntryByName.Handle(new GetPhoneBookEntryByNameRequest(phoneBookId,name), _phoneBookPresenter);
            return _phoneBookPresenter.ContentResult;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Requests.PhoneBook.CreatePhoneBookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _createPhoneBook.Handle(new CreatePhoneBookRequest(request.Name), _phoneBookPresenter);
            return _phoneBookPresenter.ContentResult;
        }
    }
}