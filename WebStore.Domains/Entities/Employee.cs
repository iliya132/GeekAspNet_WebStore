using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Имя не может быть пустым")]
        [Display(Name="Имя")]
        [StringLength(maximumLength:100, MinimumLength = 2, ErrorMessage = "Имя не может быть короче 2 и длиннее 100 символов")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия не может быть пустым")]
        [Display(Name = "Фамилия")]
        [StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Фамилия не может быть короче 2 и длиннее 100 символов")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
    }
}
