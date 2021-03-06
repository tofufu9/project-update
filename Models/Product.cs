using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginandR.Models
{
    public class Product
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Product ID")]
        public int proID { get; set; }
        [Required]
        [Display(Name = "Type ID")]
        public int tID { get; set; }
        [Required]
        [Display(Name = "Supplier ID")]
        public int supID { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string proName { get; set; }
        [Required]
        [Display(Name = "Price (VNĐ)")]
        public double proPrice { get; set; }
        [Required]
        [Display(Name = "Image")]
        public string proImg { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string proDescription { get; set; }
        [Required]
        [Display(Name = "Discount (%)")]
        public double discount { get; set; }
        public bool proStatus { get; set; }
        [Display(Name = "Type Name")]
        public string tName { get; set; }
        [Display(Name = "Supplier Name")]
        public string supName { get; set; }

        [ForeignKey("tID")]
        public virtual Type Type { get; set; }

        [ForeignKey("supID")]
        public virtual Supplier Supplier { get; set; }

    }
}