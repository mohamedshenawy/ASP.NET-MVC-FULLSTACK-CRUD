using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student : BaseModel
    {
        [Required]
        public int Age { get; set; }
        public int Grade { get; set; }
    }
}
