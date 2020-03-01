using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebStore.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required, MaxLength(255)]
        public string UserName { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string Password { get; set; }
        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
