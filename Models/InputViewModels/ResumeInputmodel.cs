using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Eskoy.Models.InputViewModels
{
    public class ResumeInputmodel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public string aboutYourSelf { get; set; }

        [Required]
        [Display(Name = "Attachment")]
        public IFormFile attachment { get; set; }
    }
}