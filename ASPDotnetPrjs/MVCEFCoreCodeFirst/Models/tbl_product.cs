using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEFCoreCodeFirst.Models
{
    public class tbl_product
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Description { get; set; }
        public double Price {  get; set; }
    }
}
