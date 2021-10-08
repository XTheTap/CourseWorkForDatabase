using AutoServiceGeniralsMotors.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace AutoServiceGeniralsMotors.Pages
{
    [Authorize]
    public class AppointmentModel : PageModel
    {

        private readonly AutoServiceContext _serviceContext;
        private readonly UserManager<IdentityUser> _userManager;

        public AppointmentModel(AutoServiceContext serviceContext, UserManager<IdentityUser> user)
        {
            _serviceContext = serviceContext;
            _userManager = user;   
        }

        public IActionResult OnGet()
        {
            ViewData["Automobile"] = new SelectList(_serviceContext.Automobiles, "Id", "NumberAuto", _userManager.GetUserId(User));
            ViewData["Service"] = new SelectList(_serviceContext.TypeServices, "Id", "ServiceName");
            return Page();
        }

        [BindProperty]
        public ServiceMerge service { get; set; }

        public IActionResult OnPostAddAuto()
        {
            return RedirectToPage("./CarModel/CarPage");
        }

        public async Task<IActionResult> OnPostAddService()
        {
            service.ServiceStatus = false;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _serviceContext.ServiceMerges.Add(service);
            await _serviceContext.SaveChangesAsync();

            return RedirectToPage("./Index"); 
        }
    }
}
