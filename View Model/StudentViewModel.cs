using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View_Model
{
    public class StudentViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
    }
    public static  class StudentViewModelExtention
    {
        public static StudentViewModel ToViewModel(this Student std)
        {
            return new StudentViewModel()
            {
                Name = std.Name,
                Age = std.Age,
                Grade = std.Grade,
            };
        }
    }
}
