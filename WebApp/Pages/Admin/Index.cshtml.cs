using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Data.Identity;
using WebApp.Models;

namespace WebApp.Pages.Admin
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationIdentityUser> userManager;

        public IndexModel(
            ILogger<IndexModel> logger,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationIdentityUser> userManager)
        {
            _logger = logger;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public void OnGet()
        {

        }

        public async Task OnPostNewRole(RoleModel model)
        {
            string roleName = model.RoleName.Trim();
            if (!string.IsNullOrEmpty(roleName))
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole
                    {
                        Name = roleName,
                        NormalizedName = roleName
                    });
                }
            }
        }

        public async Task OnPostAddRole(RoleModel model)
        {
            string roleName = model.RoleName.Trim();
            if (!string.IsNullOrEmpty(roleName))
            {
                var usr = await userManager.GetUserAsync(this.User);
                await userManager.AddToRoleAsync(usr, roleName);
            }
        }

        public async Task OnPostRemoveRole(RoleModel model)
        {
            string roleName = model.RoleName.Trim();
            if (!string.IsNullOrEmpty(roleName))
            {
                var usr = await userManager.GetUserAsync(this.User);
                await userManager.RemoveFromRoleAsync(usr, roleName);
            }
        }
    }
}