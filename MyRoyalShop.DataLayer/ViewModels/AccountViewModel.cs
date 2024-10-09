using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoyalShop.DataLayer.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        public string UserName { get; set; }


        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [EmailAddress(ErrorMessage ="لطفا ایمیل را به درستی وارد کنید")]
        public string UserEmail { get; set; }

        [Display(Name = "رمز عبور")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Display(Name = " تکرار رمز عبور")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [DataType(DataType.Password)]
        [Compare("UserPassword",ErrorMessage ="کلمه های عبور مغایرت دارند")]
        public string UserRePassword { get; set; }
    }

    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل را به درستی وارد کنید")]
        public string UserEmail { get; set; }

        [Display(Name = "رمز عبور")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Display(Name = "رمز عبور فعلی")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [DataType(DataType.Password)]
        public string OldUserPassword { get; set; }

        [Display(Name = " رمز عبور جدید")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [DataType(DataType.Password)]
        public string NewUserPassword { get; set; }

        [Display(Name = " تکرار رمز عبور جدید")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [DataType(DataType.Password)]
        [Compare("NewUserPassword", ErrorMessage = "کلمه های عبور مغایرت دارند")]
        public string NewUserRePassword { get; set; }
    }
}
