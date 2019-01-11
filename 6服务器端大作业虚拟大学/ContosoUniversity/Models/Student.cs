using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    public class Student
    {
        
            public int ID { get; set; }
            [Display(Name="学生名字")]
            public string Name { get; set; }
            [Display(Name="登记日期")]
            
            public DateTime EnrollmentDate { get; set; }
            public string Image { get; set; }

            public virtual ICollection<Enrollment> Enrollments { get; set; }
        
    }
}