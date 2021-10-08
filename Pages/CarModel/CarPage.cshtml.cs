using AutoServiceGeniralsMotors.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AutoServiceGeniralsMotors.Pages.CarModel
{
    [Authorize]
    public class CarPageModel : PageModel
    {
        [BindProperty]
        public Automobile Automobile { get; set; }

        private readonly AutoServiceContext _serviceContext;
        private readonly UserManager<IdentityUser> _userManager;

        public CarPageModel(AutoServiceContext serviceContext, UserManager<IdentityUser> user)
        {
            _serviceContext = serviceContext;
            _userManager = user;
        }

        public IActionResult OnGet()
        {
            ViewData["Body"] = new SelectList(_serviceContext.BodyTypes, "Id", "BodyName");
            ViewData["Mark"] = new SelectList(_serviceContext.AutoMarks, "Id", "MarkName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Automobile.IdentityUser = _userManager.GetUserId(User); 
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _serviceContext.Automobiles.Add(Automobile);
            await _serviceContext.SaveChangesAsync();

            return RedirectToPage("../Appointment");
        }
    }
}
