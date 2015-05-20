using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testMVC4.Models
{
    public class PacientModel
    {
        public PacientModel()
        {

        }

        public long? Id { get; set; }
        [Display(Name="Номер карты: ")]
        public int? CardNumber { get; set; }
        [Display(Name = "Номер страховки: ")]
        public int? SocialNumber { get; set; }
        [Required]
        [Display(Name = "Номер телефона: ")]
        public int Phone { get; set; }
        public int UserId { get; set; }
    }
}