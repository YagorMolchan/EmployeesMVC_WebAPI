using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Имя должно быть заполнено!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Должность должна быть заполнено!")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Зарплата должна быть заполнено!")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Возраст должен быть заполнено!")]
        public int Age { get; set; }
         
    }
}