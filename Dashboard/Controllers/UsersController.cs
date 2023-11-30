using Dashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Extensions.Logging;

namespace Dashboard.Controllers
{
    public class UsersController : Controller
    {
        UserManager<AppUser> userManager;
        RoleManager<IdentityRole> roleManager;

        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }


        public IActionResult Create()
        {
            return View(new AppUser());
        }
        // Create new user 
        [HttpPost]
        public async Task<IActionResult> Create(AppUser user)        
        {
            var Role = await roleManager.FindByIdAsync(user.RoleId);

            string Password = "P@55word";
            user.UserName = user.Email;
            
            await userManager.CreateAsync(user, Password);
            await userManager.AddToRoleAsync(user, "Root");

            return RedirectToAction("Index");
        }

        //remove User
        [HttpPost]
        public async Task<IActionResult> Delete(AppUser user)
        {
            var User = await userManager.FindByIdAsync(user.Id);
            var Role = await roleManager.FindByIdAsync(user.RoleId);


            if (ModelState.IsValid)
            {
                await userManager.DeleteAsync(User);
                await userManager.RemoveFromRoleAsync(User, Role.Name);
            }

            return RedirectToAction("Index");
        }

        //edit User
        [HttpPost]
        public async Task<IActionResult> Update(AppUser user)
        {

            var User = await userManager.FindByIdAsync(user.Id);
            var Role = await roleManager.FindByIdAsync(user.RoleId);

            if (ModelState.IsValid)
            {
                User.FirstName = user.FirstName;
                User.LastName = user.LastName;
                User.Email = user.Email;
                User.UserName = user.Email;
                User.LastSeen = DateTime.Now;
                User.Gender = user.Gender;
                User.PhoneNumber = user.PhoneNumber;

                
                await userManager.UpdateAsync(User);
                await userManager.AddToRoleAsync(User, Role.Id);
            }

            return RedirectToAction("Index");
        }
    }
}
