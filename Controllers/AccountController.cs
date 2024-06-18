using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DHL_LOGIN_FINAL.Controllers
{
    public class AccountController : Controller
    {
        // Dummy data
        private const string HardcodedUserName = "Sondos Moustafa";
        private const string HardcodedEmail = "sondostmoustafa@gmail.com";
        private const string HardcodedPassword = "password123";

        [HttpPost]

        //validation
        public IActionResult Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData["ErrorMessage"] = "Email is required.";
                return RedirectToPage("/Index");
            }
            else if (!new EmailAddressAttribute().IsValid(email))
            {
                TempData["ErrorMessage"] = "Email format is invalid.";
                return RedirectToPage("/Index");
            }
            else if (email != HardcodedEmail)
            {
                TempData["ErrorMessage"] = "User does not exist. Please register first. ";
                return RedirectToPage("/Index");
            }
            else if (string.IsNullOrEmpty(password))
            {
                TempData["ErrorMessage"] = "Password is required.";
                return RedirectToPage("/Index");
            }
            else if (password != HardcodedPassword)
            {
                TempData["ErrorMessage"] = "Password is incorrect.";
                return RedirectToPage("/Index");
            }
            else
            {
                TempData["SuccessMessage"] = "You have successfully logged in.";
                HttpContext.Session.SetString("IsLoggedIn", "true");
                HttpContext.Session.SetString("Username", HardcodedUserName);
                return RedirectToPage("/Home");
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            TempData["SuccessMessage"] = "You have successfully logged out!";
            return RedirectToPage("/Index");
        }
    }
}
