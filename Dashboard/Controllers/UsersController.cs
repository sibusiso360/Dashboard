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
        SignInManager<AppUser> signInManager;

        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;           
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
            AppUser User = new AppUser();
            
            User.UserName = user.UserName;
            User.FirstName = user.FirstName;
            User.LastName = user.LastName;
            User.Email = user.Email;
            User.UserName = user.Email; 
            User.Gender = user.Gender;
            User.PhoneNumber = user.PhoneNumber;
            User.DateCreated = DateTime.Now; 

            string Password = "P@55word";           
            
            await userManager.CreateAsync(User, Password);
            await userManager.AddToRoleAsync(User, "Root");

            return RedirectToAction("Index");
        }

        //remove User
        [HttpPost]
        public async Task<IActionResult> Delete(AppUser user)
        {
            var User = await userManager.FindByIdAsync(user.Id);
            //var Role = await roleManager.FindByIdAsync(user.RoleId);            

            await userManager.DeleteAsync(User);
           // await userManager.RemoveFromRoleAsync(User, Role.Name);
           

            return RedirectToAction("Index");
        }

        //edit User
        [HttpPost]
        public async Task<IActionResult> Update(AppUser user)
        {
            //Handle Null Users! 
            //Update User role. 

            var User = await userManager.FindByIdAsync(user.Id);
            //var Role = await roleManager.

            if (ModelState.IsValid)
            {
                User.FirstName = user.FirstName;
                User.LastName = user.LastName;
                //User.Email = user.Email;
                User.UserName = user.Email;
                User.Gender = user.Gender;
                User.PhoneNumber = user.PhoneNumber;
                
                await userManager.UpdateAsync(User);
                //await userManager.AddToRoleAsync(User, user.RoleId);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(AppUser user, string? newPassword)
        {
            //var User = userManager.FindByIdAsync(user.Id);
            var resetToken = userManager.GeneratePasswordResetTokenAsync(user).ToString();          
            await userManager.ResetPasswordAsync(user, resetToken, newPassword);            
           
            return RedirectToAction("Index");
        }
    }
}
