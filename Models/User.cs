using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginandR.Models
{
    public class User
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int uID { get; set; }
        [Required]
        [Display (Name = "Username")]
        [StringLength(15, MinimumLength = 3)]
        public string uUsername { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*\d).{8,32}$", ErrorMessage = "Use more than 7 characters include letters and numbers")]
        [Display(Name = "Password")]
        public string uPwd { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("uPwd", ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 2)]
        public string uFirstname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 2)]
        public string uLastname { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(11, MinimumLength = 10)]
        public string uPhone { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string uAddress { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime uBirthday { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Invalid email, Please Re-Enter")]
        public string uEmail { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string uGender { get; set; }
        [Required]
        [Display(Name = "Credit Card Number")]
        [StringLength(18, MinimumLength = 14)]
        public string uCreditCard { get; set; }
        public string FullName()
        {
            return this.uFirstname + " " + this.uLastname;
        }

    }
}