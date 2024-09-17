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
    public class WorkingDayAssigmentsController : ODataController
    {
        private readonly HcmTimecheckContext _context;

        public WorkingDayAssigmentsController(HcmTimecheckContext context)
        {
            _context = context;
        }

        [EnableQuery(PageSize = 10)]
        public async Task<ActionResult<IEnumerable<WorkingDayAssigment>>> GetWorkingDayAssigments()
        {
            return await _context.WorkingDayAssigments.ToListAsync();
        }
    }
}
