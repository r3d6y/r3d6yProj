using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testMVC4.Models
{
    public class LoginModel
    {
        public LoginModel()
        {

        }

        public LoginModel(User user)
        {
            Email = user.Email;
            Password = user.Password;
        }

        public long? Id { get; set; }
        [Required]
        [Display(Name = "Пароль: ")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; }
        //public string PasswordSalt { get; set; }
        [Required]
        [Display(Name = "Эмейл: ")]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
    }
}