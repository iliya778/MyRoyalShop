using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoyalShop.DataLayer.Domain
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        public string UserName { get; set; }


        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Display(Name = "رمز عبور")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        public string UserPassword { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }

        [Display(Name = "مدیر سیستم")]
        public bool IsAdmin { get; set; }
        public string? ActiveCode { get; set; }
        public bool IsActive { get; set; }

        



    }
}
