using EntityApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EntityApp.Context;
using Microsoft.EntityFrameworkCore;
using EntityApp.Other;


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
       

        public async Task<IActionResult> List(string? name, SortState sortOrder=SortState.NameAsc)
        {
            
            IQueryable<Course> courses = context.Courses.Include(s => s.Students);
            if (!string.IsNullOrEmpty(name)) 
            {
                courses = courses.Where(c => c.Name!.Contains(name));
            }

            courses = sortOrder switch
            {
                SortState.NameAsc=>courses.OrderBy(c=>c.Name),
                SortState.NameDesc => courses.OrderByDescending(c => c.Name),
                SortState.DurationDaysAsc => courses.OrderBy(c => c.DurationDays),
                SortState.DurationDaysDesc => courses.OrderByDescending(c => c.DurationDays)
            };
            FilteringSortingViewModel viewModel = new FilteringSortingViewModel
                (await courses.AsNoTracking().ToListAsync(), new SortViewModel(sortOrder), new FilterViewModel(context.Courses.ToList(), name));
            return View(viewModel);
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