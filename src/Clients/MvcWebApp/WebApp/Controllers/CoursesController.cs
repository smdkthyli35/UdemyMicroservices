using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyMicroservices.Common.Services;
using WebApp.Models.Catalogs;
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

        public async Task<IActionResult> Create()
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateInput courseCreate)
        {
            var categories = await _catalogService.GetAllCategoryAsync();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            if (!ModelState.IsValid)
            {
                return View();
            }

            courseCreate.UserId = _commonIdentityService.GetUserId;

            await _catalogService.CreateCourseAsync(courseCreate);
            return RedirectToAction(nameof(Index));
        }
    }
}
