using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEFCoreCodeFirst.Models
{
    //[Table("Customers")]
    public class tbl_customer
    {        
        public int Id { get; set; }        
        public string CustName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
