using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoServiceGeniralsMotors.Pages
{
    public class RoleModel
    {
        public string RoleId {  get; set; }
        public string RoleName {  get; set; }
        public bool IsSelected { get; set; }
    }

    [Authorize(Roles = "ADMIN")]
    public class EditUserModel : PageModel
    {
        [BindProperty]
        public IdentityUser User { get; set; }

        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;


        public EditUserModel(UserManager<IdentityUser> manager, RoleManager<IdentityRole> roleManager)
        {
            userManager = manager;
            this.roleManager = roleManager;
        }

        public async void OnGet(string id)
        {
            User = await userManager.FindByIdAsync(id);
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            
            return RedirectToPage("./Adminpanel");
        }

        public async Task<IActionResult> OnPostCancelAsync()
        {
            return RedirectToPage("./Adminpanel");
        }
    }
}
