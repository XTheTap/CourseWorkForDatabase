using AutoServiceGeniralsMotors.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AutoServiceGeniralsMotors.Pages
{
    [Authorize(Roles = "ADMIN,WORKER,PAYMASTER")]
    public class WorkerServicesModel : PageModel
    {
        public AutoServiceContext autoServiceContext {  get; set; }

        public WorkerServicesModel(AutoServiceContext serviceContext)
        {
            autoServiceContext = serviceContext;
        }

        public async Task<IActionResult> OnPostClose(int id)
        {
            autoServiceContext.ServiceMerges.Find(id).ServiceStatus = true;
            await autoServiceContext.SaveChangesAsync();
            return Page();
        }

        public void OnGet()
        {

        }
    }
}
