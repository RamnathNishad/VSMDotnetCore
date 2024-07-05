using System.Text.Json;

namespace MVCEFCoreDBFirst.Models
{
    public class ApiConsumer
    {
        static string baseUrl = "http://localhost:5024/api/Employee/";
        public static List<Employee> GetEmps()
        {
            var list = new List<Employee>();
            //call the Web API GetAll 
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                //send the GET request to api
                var response = http.GetAsync("GetAllEmps");
                response.Wait();

                var responseResult = response.Result; //full respone 
                if (responseResult.IsSuccessStatusCode)
                {
                    var data = responseResult.Content.ReadAsStringAsync();
                    data.Wait();

                    var finalResult = data.Result; //string of json result

                    //convert the json string into object
                    list = JsonSerializer.Deserialize<List<Employee>>(finalResult);
                }
            }
            return list;
        }

        public static Employee GetEmpById(int id)
        {
            var emp = new Employee();
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var response = http.GetAsync("GetEmpById/" + id.ToString());
                response.Wait();
                var responseResult = response.Result;
                if (responseResult.IsSuccessStatusCode)
                {
                    var data = responseResult.Content.ReadAsStringAsync();
                    data.Wait();

                    var finalResult = data.Result; //json string
                    //deserialize to object
                    emp = JsonSerializer.Deserialize<Employee>(finalResult);
                }
                return emp;
            }
        }

        public static bool AddEmployee(Employee emp)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var response = http.PostAsJsonAsync("AddEmp", emp);
                response.Wait();
                var responseResult = response.Result;
                return responseResult.IsSuccessStatusCode;
            }
        }
        public static bool DeleteEmployee(int id)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var response = http.DeleteAsync("DeleteEmp/" + id.ToString());
                response.Wait();
                var responseResult = response.Result;

                return responseResult.IsSuccessStatusCode;
            }
        }
        public static bool UpdateEmployee(Employee emp)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var response = http.PutAsJsonAsync("UpdateEmpById/" + emp.Ecode.ToString(), emp);
                response.Wait();
                var responseResult = response.Result;

                return responseResult.IsSuccessStatusCode;
            }
        }
    }
}
