using Ganss.Xss;
using LawAlert.Core.Models.User;
using LawAlert.Core.Services.Interest;
using LawAlert.Core.Services.User;
using LawAlert.Infrastructure.Data.Entities.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WeVolunteer.Core.Constants;
using WeVolunteer.Extensions;

namespace LawAlert.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;
        private readonly IInterestService interestService;
        private readonly ILogger logger;
        private readonly IMemoryCache cache;

        public UserController(
               UserManager<User> _userManager,
               SignInManager<User> _signInManager,
               IUserService _userService,
               ILogger _logger,
               IMemoryCache _cache,
               IInterestService _interestService)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
            this.userService = _userService;
            this.interestService = _interestService;
            this.logger = _logger;
            this.cache = _cache;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                TempData[MessageConstant.WarningMessage] = "You have already registered!";
                this.logger.LogInformation("User {0} tried to register again!", this.User.Id());
                return RedirectToAction("Index", "Home");
            }
            var model = new UserRegisterViewModel();

            model.Interests = interestService.GetInterestViewModels();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            var sanitalizer = new HtmlSanitizer();

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid registration";
                model.Interests = interestService.GetInterestViewModels();
                return View(model);
            }

            if (userManager.Users.Any(u => u.Email == model.Email))
            {
                TempData[MessageConstant.ErrorMessage] = "Тhere is a user with this email";
                model.Interests = interestService.GetInterestViewModels();
                return View(model);
            }

            var user = new User()
            {
                UserName = sanitalizer.Sanitize(model.UserName),
                FirstName = sanitalizer.Sanitize(model.FirstName),
                LastName = sanitalizer.Sanitize(model.LastName),
                Email = sanitalizer.Sanitize(model.Email),
                PhoneNumber = sanitalizer.Sanitize(model.PhoneNumber),
                BirthDate = model.BirthDate
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                TempData[MessageConstant.SuccessMessage] = "Your account has been successfully registered";
                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                TempData[MessageConstant.ErrorMessage] = item.Description.ToString();
            }

            model.Interests = interestService.GetInterestViewModels();
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                TempData[MessageConstant.WarningMessage] = "You have already logged in";
                this.logger.LogInformation("User {0} tried to login again!", this.User.Id());
                return RedirectToAction("Index", "Home");
            }

            var model = new UserLoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                TempData[MessageConstant.WarningMessage] = "You have already logged in";
                this.logger.LogInformation("User {0} tried to login again!", this.User.Id());
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid login";
                return View(model);
            }

            var user = userManager.Users.Where(u => u.Email == model.Email).FirstOrDefault();

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    this.cache.Remove("UsersCacheKey");
                    TempData[MessageConstant.SuccessMessage] = "You have successfully logged in";
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");
            TempData[MessageConstant.ErrorMessage] = "Invalid login";

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            TempData[MessageConstant.SuccessMessage] = "You have successfully logged out";
            return RedirectToAction("Index", "Home");
        }
    }
}
