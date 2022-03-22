using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User : BaseModel
    {
        [DataType(DataType.Password), MinLength(8, ErrorMessage = "length shoud be equal or greater than 8")]
        [Required]
        public string Password { get; set; }
    }
}
