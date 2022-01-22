using ASP6_SinAuth.Areas.Identity.Data;
using ASP6_SinAuth.Data;
using ASP6_SinAuth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASP6_SinAuth.Controllers
{
    public class LabWorkers : Controller
    {

        private readonly ctxDatos _context;
        private readonly UserManager<User> _userManager;
        private readonly IUserStore<User> _userStore;
        private readonly IUserEmailStore<User> _emailStore;

        public LabWorkers(
            ctxDatos context,
            UserManager<User> userManager,
            IUserStore<User> userStore)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
        }

        public class LabWorkerInput
        {
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "NationalId")]
            public string NationalId { get; set; }

            [Required]
            public string LabId { get; set; }
        }

        // GET: LabWorkers/[idlab]
        public async Task<IActionResult> Index(string Id)
        {
            IEnumerable<LaboratoryWorker> lw;

            if (!string.IsNullOrEmpty(Id))
            {
                ViewBag.labName = _context.Laboratory.Find(Id).Name;
                ViewBag.labId = Id;

                lw = await _context.LaboratoryWorker
               .Include(lw => lw.laboratory)
               .Where(lw => lw.laboratory.IdLab == Id)
               .ToListAsync();
            }
            else
            {
                lw = new List<LaboratoryWorker>();
            }

            return View(lw);
        }

        // GET: LabWorkers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LabWorkers/Create
        public ActionResult Create(string Id)
        {
            return View(new LabWorkerInput()
            {
                LabId = Id
            });
        }

        // POST: LabWorkers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LabWorkerInput Input)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            Laboratory lab = _context.Laboratory.Find(Input.LabId);

            LaboratoryWorker lw = new LaboratoryWorker();

            if (ModelState.IsValid)
            {
                LaboratoryWorker user = new LaboratoryWorker
                {
                    Name = Input.FirstName,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    NationalID = Input.NationalId,
                    laboratory = lab
                };

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    // Add role
                    User usr = await _userManager.FindByIdAsync(_userManager.GetUserId(User));
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, "Laboratory Worker");
                    }
                }

                return RedirectToAction(nameof(Index), new { Id = Input.LabId });
            }
            else
            {
                return View(Input);
            }
        }

        // GET: LabWorkers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LabWorkers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LabWorkers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LabWorkers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private IUserEmailStore<User> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<User>)_userStore;
        }
    }
}
