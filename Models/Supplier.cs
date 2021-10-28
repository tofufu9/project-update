using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LoginandR.Models
{
    public class Supplier
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Supplier ID")]
        public int supID { get; set; }
        [Required]
        [Display(Name = "Suppler User Name")]
        public string supUsername { get; set; }
        [Required]
        [Display(Name = "Supplier Password")]
        public string supPwd { get; set; }
        [Display(Name = "Supplier Name")]
        public string supName { get; set; }
        [Required]
        [Display(Name = "Supplier Phone")]
        public string supPhone { get; set; }
        [Required]
        [Display(Name = "Supplier Address")]
        public string supAddress { get; set; }
        [Required]
        [Display(Name = "Supplier Email")]
        public string supEmail { get; set; }
        [Required]
        [Display(Name = "Supplier Description")]
        public string supDescription { get; set; }
        
    }
}