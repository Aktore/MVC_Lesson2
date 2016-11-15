using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace lesson2_HomeWork.Models.Default
{
    public class Employee
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле объязательно  для заполнения")]
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Неверный формат почты")]
        [DisplayName("Почта")]
        public string Email { get; set; }

        [DataType(DataType.Password, ErrorMessage = "Неверный пароль")]
        [DisplayName("Пароль")]
        public string Password { get; set; }
 

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле объязательно  для заполнения")]
        [MinLength(2, ErrorMessage = "Необходимо ввести хотя бы 2 символа" )]
        [MaxLength(20, ErrorMessage ="Имя ограничено 20 символами")]
        [DisplayName("Имя")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле объязательно  для заполнения")]
        [Range(18, 75, ErrorMessage = "Недопустимый возраст")]
        [DisplayName("Возраст")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле объязательно  для заполнения")]
        [MaxLength(50, ErrorMessage = "Превышена максимальна допустимая величчина")]
        [DisplayName("Департамент")]
        public string Department { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле объязательно  для заполнения")]
        [MaxLength(50, ErrorMessage = "Превышена максимальна допустимая величчина")]
        [DisplayName("Роль")]
        public string Role { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле объязательно  для заполнения")]
        [MaxLength(50, ErrorMessage = "Превышена максимальна допустимая величчина")]
        [DisplayName("Название должности")]
        public string JobTitle { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле объязательно  для заполнения")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Зарплата может состоять только из рублей")]
        [DisplayName("Зарплата")]
        public int Salary { get; set; }
    }
}