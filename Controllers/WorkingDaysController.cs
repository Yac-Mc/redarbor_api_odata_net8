using API_Net8_OData.DBContext;
using API_Net8_OData.Models.HcmTimecheck;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace API_Net8_OData.Controllers
{
    public class WorkingDaysController : ODataController
    {
        private readonly HcmTimecheckContext _context;

        public WorkingDaysController(HcmTimecheckContext context)
        {
            _context = context;
        }

        [EnableQuery(PageSize = 10)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkingDay>>> GetWorkingDays()
        {
            return await _context.WorkingDays.Include(x => x.WorkingDayAssigment).ToListAsync();
        }
    }
}
