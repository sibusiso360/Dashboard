using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Controllers
{
    public class RolesController : Controller
    {
        RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();          
            return View(roles);
        }

        public IActionResult Create()
        {
            return View(new IdentityRole());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            if(ModelState.IsValid)
            {
                await roleManager.CreateAsync(role);
            }                
            return RedirectToAction("Index");
        }

        //remove role
        [HttpPost]
        public async Task<IActionResult> Delete(IdentityRole role)
        {
            var Role = await roleManager.FindByIdAsync(role.Id);

           
            if (ModelState.IsValid)
            {
               
                await roleManager.DeleteAsync(Role);
            }            

            return RedirectToAction("Index"); 
        }

        //edit role
        [HttpPost]
        public async Task<IActionResult> Update(IdentityRole role)
        {

            var Role = await roleManager.FindByIdAsync(role.Id);            
           
            if (ModelState.IsValid)
            {
                Role.Name = role.Name;
                await roleManager.UpdateAsync(Role);
            }

            return RedirectToAction("Index");
        }
    }
}
