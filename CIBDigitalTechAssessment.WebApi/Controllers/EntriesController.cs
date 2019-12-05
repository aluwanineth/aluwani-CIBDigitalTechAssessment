using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIBDigitalTechAssessment.Core.Dtos.Requests.Entry;
using CIBDigitalTechAssessment.Core.Interfaces.Entry;
using CIBDigitalTechAssessment.WebApi.Presenters.Entry;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CIBDigitalTechAssessment.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EntriesController : ControllerBase
    {
        private readonly ICreateEntry _createEntry;
        private readonly EntryPresenter _entryPresenter;

        public EntriesController(ICreateEntry createEntry,
                                     EntryPresenter entryPresenter)
        {
            _createEntry = createEntry;
            _entryPresenter = entryPresenter;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Models.Requests.Entry.CreateEntryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _createEntry.Handle(new CreateEntryRequest(request.Name,request.PhoneNumber,request.PhoneBookId), _entryPresenter);
            return _entryPresenter.ContentResult;
        }
    }
}
