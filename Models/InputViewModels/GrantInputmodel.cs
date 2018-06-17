using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Eskoy.Models.InputViewModels
{
    public class GrantInputmodel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        public string ammount{ get; set; }
        public string aboutYourSelf { get; set; }

       // public IFormFile attachment { get; set; }
    }
}