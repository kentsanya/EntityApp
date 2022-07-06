using EntityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EntityApp.Context;
using Microsoft.EntityFrameworkCore;


namespace EntityApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public ActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> List()
        {
            return View(await context.Courses.ToListAsync());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (course != null)
            {
                context.Courses.Add(course);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else NotFound();
            return NotFound("Other");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id) 
        {
            if (id != null)
            {
                Course? course = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);
                if (course != null) return View(course);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course course) 
        {
            context.Courses.Update(course);
            await context.SaveChangesAsync();
            return View("List", await context.Courses.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}