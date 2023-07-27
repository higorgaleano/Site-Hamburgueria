using Microsoft.AspNetCore.Identity;

namespace BiteMeBurgers.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(UserManager<IdentityUser> userManager,
                                   RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public void SeedRoles()
        {
            //verifica se perfil não existe e realiza a criação
            if(!_roleManager.RoleExistsAsync("Membro").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Membro";
                role.NormalizedName = "MEMBRO";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if(!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.Name = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            //antes de criar usuário, tenta localizar
            if(_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult userResult = _userManager.CreateAsync(user, "Numsei#2023").Result;

                if(userResult.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Membro").Wait();
                }
            }
            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult userResult = _userManager.CreateAsync(user, "Admin@2023").Result;

                if (userResult.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

        }
    }
}
