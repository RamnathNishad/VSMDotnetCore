using System.ComponentModel.DataAnnotations;

namespace MVCHelloWorld.Models
{
    public class Login
    {
        [Required(ErrorMessage ="user name must be entered")]
        [StringLength(10,MinimumLength =5,ErrorMessage ="user name must be minumum 5 characters and max 10")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("[aA-zZ]*",ErrorMessage ="password must be only alphabets")]
        public string Password { get; set; }

        [Required]
        [CheckDeptid(ErrorMessage ="invalid deptid")]
        public int Deptid {  get; set; }
    }
}
