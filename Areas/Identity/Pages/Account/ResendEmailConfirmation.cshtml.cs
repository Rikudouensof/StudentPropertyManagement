using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using StudentPropertyManagement.Data;
using StudentPropertyManagement.Models;

namespace StudentPropertyManagement.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResendEmailConfirmationModel : PageModel
    {
        private readonly UserManager<User> _userManager;
    private readonly IEmailSender _emailSender;
    private ApplicationDbContext _db;

    public ResendEmailConfirmationModel(UserManager<User> userManager, IEmailSender emailSender, ApplicationDbContext db)
        {
            _userManager = userManager;
            _emailSender = emailSender;
      _db = db;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByEmailAsync(Input.Email);
      var userId = await _userManager.GetUserIdAsync(user);
      if (user == null)
            {
                ModelState.AddModelError(string.Empty, "No Email found.");
                return Page();
            }

           
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
      var callbackUrl = Url.Page(
          "/Account/ConfirmEmail",
          pageHandler: null,
          values: new { userId = userId, code = code },
          protocol: Request.Scheme);

      RenewRequest renewRequest = new RenewRequest()
      {
        DateRequested = DateTime.Now,
        isFulfiled = false,
        StudentId = userId
      };
      _db.RenewRequests.Add(renewRequest);
      _db.SaveChanges();
      await _emailSender.SendEmailAsync(
                Input.Email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            ModelState.AddModelError(string.Empty, "Request has been made, we will be with you soon.");
            return Page();
        }
    }
}
