using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testMVC4.Models
{
    public class UserModel
    {
        public UserModel()
        {

        }

        public UserModel(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            SecondName = user.SecondName;
            LastName = user.LastName;
            Password = user.Password;
            PasswordSalt = user.PasswordSalt;
            Email = user.Email;
            Birthday = user.Birthday;
            Address = user.Address;
            PacientInfo = user.PacientInfo;
            DoctorInfo = user.DoctorInfo;
            IsAdmin = user.is_admin;
            IsDoctor = user.is_doctor;
        }

        public long? Id { get; set; }
        [Required]
        [Display(Name="Имя: ")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Отчество: ")]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "Фамилия: ")]
        public string LastName { get; set; }
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
        [Required]
        [Display(Name = "День рождения: ")]
        public DateTime Birthday { get; set; }
        [Required]
        [Display(Name = "Адресс: ")]
        public string Address { get; set; }
        //public int DoctorInfo { get; set; }
        //public int PacientInfo { get; set; }
        public string PasswordSalt { get; set; }
        public int? DoctorInfo { get; set; }
        public int? PacientInfo { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsDoctor { get; set; }
    }
}