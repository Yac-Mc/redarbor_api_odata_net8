using API_Net8_OData.DBContext;
using API_Net8_OData.Models.HCMSSO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace API_Net8_OData.Controllers
{
    public class ActionUrlsController : ODataController
    {
        private readonly HcmSsoContext _context;

        public ActionUrlsController(HcmSsoContext context)
        {
            _context = context;
        }

        [EnableQuery(PageSize = 10)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActionUrl>>> GetActionUrls()
        {
            return await _context.ActionUrls.ToListAsync();
        }
    }
}
