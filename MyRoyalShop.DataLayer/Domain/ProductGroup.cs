using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRoyalShop.DataLayer.Domain
{
    public class ProductGroup
    {
        [Key]
        public int GroupId { get; set; }

        [Display(Name = "عنوان گروه")]
        [MaxLength(200)]
        [Required(ErrorMessage = "لطفا {0} را وارید کنید")]
        public string GroupTitle { get; set; }

        public List<Product> product { get; set; }
    }
}
