using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCHelloWorld.Models
{
    public class Customer
    {
        public int CustId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; } //radio
        public List<SelectListItem> Cities { get; set; } //dropdown
        public string SelectedCity {  get; set; }
        public List<string> Hobbies { get; set; } //checkbox
        public List<string> SelectedHobbies { get; set; }
    }
}
