using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoyalShop.DataLayer.Domain
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        public string Title { get; set; }

        [Display(Name = "توضیح")]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        [DataType(DataType.MultilineText)]
        public string? Text { get; set; }

        [Display(Name = "تصویر")]
        public string? ImageName { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        public int Price { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string?  Tags { get; set; }

        [ForeignKey("GroupId")]
        public ProductGroup? productGroup { get; set; }
    }
}
