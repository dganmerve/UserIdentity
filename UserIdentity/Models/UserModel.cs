//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Web;
//using UserIdentity.Identity;

//namespace UserIdentity.Models 
//{
//    public class LoginModel
//    {
//        [Required]
//        public String Username { get; set; }
//        [Required]
//        public String Password { get; set; }

//    }
//    public class Register
//    {
//        [Required]
//        public String Username { get; set; }
//        [Required]
//        public String Email { get; set; }
//        [Required]
//        public String Password { get; set; }
//    }
//    public class RoleEditModel
//    {
//        public IdentityRole Role { get; set; }
//        public IEnumerable<ApplicationUser> Members { get; set; }
//        public IEnumerable<ApplicationUser> NonMembers { get; set; }
//    }
//    public class RoleUpdateModel
//    {
//        [Required]
//        public string RoleName { get; set; }
//        public string RoleId { get; set; }
//        public string[] IdsToAdd { get; set; }
//        public string[] IdsToDelete{ get; set; }
//    }
//}
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UserIdentity.Identity;

namespace UserIdentity.Models
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
    public class Register
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }

    }
    public class RoleUpdateModel
    {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }

    public class Basvuru
    {        
        [Key]
        public int Id { get; set; }
        public string Adi { get; set; }
        public string SoyAdi { get; set; } 
        public bool Cinsiyet { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string ProjeAdi { get; set; }
        public string ProjeAciklamasi { get; set; }
        public bool ProjeninNiteligi { get; set; }
        //public string UserId { get; set; }
    }

    public class Deneme
    {
        public int Id { get; set; }
        public string Ad { get; set; }
    }

} 
