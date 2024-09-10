using API_Net8_OData.DBContext;
using API_Net8_OData.Models.HcmTimecheck;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace API_Net8_OData.Controllers
{
    public class TimeChecksController : ODataController
    {
        private readonly HcmTimecheckContext _context;

        public TimeChecksController(HcmTimecheckContext context)
        {
            _context = context;
        }

        [EnableQuery(PageSize = 10)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeCheck>>> GetTimeChecks()
        {
            return await _context.TimeChecks.ToListAsync();
        }
    }
}
