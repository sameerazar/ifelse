using CustomIdentity.Data;
using CustomIdentity.Models;
using CustomIdentity.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace CustomIdentity.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        //private readonly AppDbContext context;


        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser>userManager)

        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        //    this.context = context;

        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe,false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Login attempt");
                return View(model);

            }
            return View(model);
        }

        public IActionResult Register()
            {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {

            if(ModelState.IsValid)
            {
                AppUser user = new()
               
                {
                    Name = model.FirstName + model.LastName ,                   
                    UserName = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Address=model.Address


                };
              /*  if (model.Password.Length < 8 || model.Password.Length > 16)
                {
                    ModelState.AddModelError("Password", "Password must be between 8 to 16 characters.");
                    return View(model);
                }*/
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    ViewBag.message = $"Registration successful!, {model.Email}.";
                    // Set success message with the username
                    //  TempData["SuccessMessage"] = $"Registration successful! Welcome, {model.Email}.";

                    return RedirectToAction("Index", "Home");

                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
            return View();
        }
        public IActionResult Reset()
        {
            ModelState.Clear();
            return View();
        }

       /* public async Task<IActionResult > Index()
        {
            return View(await context.AppUsers.ToListAsync ());
        }

        //Create
        //Edit
        //Delete

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

         public async Task<IActionResult> Create([Bind("Name,Email,Address")]AppUserList appUserList)
        {
            if (ModelState.IsValid)
            {
                context.Add(appUserList);
                await context.SaveChangesAsync();
                return RedirectToAction (nameof(Index));
            }
            return View(appUserList);

        }
        //Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var appUser = await context.AppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        //post Edit
        public async Task<IActionResult> Edit(int id, [Bind("Name,Email,Address")] AppUserList appUserList)
        {
           // int intAppUserId = Convert.ToInt32(appUser .Id);
            if (id != appUserList.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {

                    context.Update(appUserList);
                    await context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppUserExists(appUserList.Id))
                    {
                        throw;
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appUserList);
        }
        //Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();

            } 
            var appuser = await context.AppUsers.FirstOrDefaultAsync(m => m.Id == id);
            if (appuser == null)
            {
                return NotFound();
            }
            return View(appuser);
        }
        [HttpPost,ActionName ("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int id)
        {
            var appsuser = await context.AppUsers.FindAsync(id);
            if (appsuser == null)
            {
                return NotFound();
            }
            context.AppUsers .Remove (appsuser);
            await context .SaveChangesAsync();

            return RedirectToAction(nameof(Index)); 
        }

        private bool AppUserExists(int id)
        {
            return context.AppUsers.Any(e => e.Id  == id);
        }*/

    }
}
