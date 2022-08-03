using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyMicroservices.Common.Services;
using WebApp.Services.Interfaces;

namespace WebApp.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly ICommonIdentityService _commonIdentityService;

        public CoursesController(ICatalogService catalogService, ICommonIdentityService commonIdentityService)
        {
            _catalogService = catalogService;
            _commonIdentityService = commonIdentityService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _catalogService.GetAllCourseByUserIdAsync(_commonIdentityService.GetUserId));
        }
    }
}
