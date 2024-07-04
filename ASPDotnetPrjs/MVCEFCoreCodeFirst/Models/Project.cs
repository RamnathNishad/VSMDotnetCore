using System.ComponentModel.DataAnnotations.Schema;

namespace MVCEFCoreCodeFirst.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }

        [ForeignKey("FK_Mgr_Prj")]
        public int MgrId { get; set; }

        //navigation
        public Manager manager { get; set; }
    }
}
