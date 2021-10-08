using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AutoServiceGeniralsMotors.Pages
{
    [Authorize(Roles = "ADMIN")]
    public class AdminpanelModel : PageModel
    {
        public UserManager<IdentityUser> UserManager { get; set; } 

        public AdminpanelModel(UserManager<IdentityUser> users)
        {
            UserManager = users;
        }

        public IActionResult OnPostEditUser(string id)
        {
            return RedirectToPage("./EditUser", new {id = id});
        }

        public async Task<IActionResult> OnPostDeleteUserAsync(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            await UserManager.DeleteAsync(user);
            return Page();
        }

        public void OnGet()
        {
            
        }
    }
}
