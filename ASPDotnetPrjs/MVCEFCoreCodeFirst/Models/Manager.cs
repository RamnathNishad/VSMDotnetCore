using System.ComponentModel.DataAnnotations;

namespace MVCEFCoreCodeFirst.Models
{
    public class Manager
    {
        [Key]
        public int MgrId { get; set; }
        public string Ename { get; set; }        
    }
}
