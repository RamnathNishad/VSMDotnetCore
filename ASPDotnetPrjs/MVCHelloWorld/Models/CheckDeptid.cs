using System.ComponentModel.DataAnnotations;

namespace MVCHelloWorld.Models
{
    public class CheckDeptid : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var did=(int)value;
            if(did==201 || did==202 ||did==203)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
