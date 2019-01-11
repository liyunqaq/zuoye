using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Display(Name ="姓名")]

        public String Name { get; set; }
        [Display(Name = "注册日期")]

        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<EndEventHandler> Enrollments { get; set; }
    }
}