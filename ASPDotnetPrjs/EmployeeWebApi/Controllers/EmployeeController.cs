using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly EmployeeDbContext _dbCtx;
        public EmployeeController(EmployeeDbContext dbCtx)
        {
            this._dbCtx = dbCtx;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("GetAllEmps")]
        public IActionResult Get()
        {
            try
            {
                var records = _dbCtx.tbl_employee.ToList();

                if (records.Count == 0)
                {
                    return NotFound("No records found");
                }
                else
                {
                    return Ok(records);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetEmpsByDid/{id}")]
        public IEnumerable<Employee> GetByDeptid(int id)
        {
            return _dbCtx.tbl_employee
                         .Where(e=>e.Deptid== id)
                         .ToList();
        }

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("GetEmpById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var record = _dbCtx.tbl_employee.Find(id);
                if (record == null)
                {
                    return NotFound("Ecode not present:" + id.ToString());
                }
                else
                {
                    return Ok(record);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("some server error, contact admin:"+ex.Message);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route("AddEmp")]
        public IActionResult Post([FromBody] Employee emp)
        {
            try
            {
                _dbCtx.tbl_employee.Add(emp);
                _dbCtx.SaveChanges();
                return Ok("Record inserted");
            }
            catch (Exception ex)
            {
                return BadRequest("could not insert the record");
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        [Route("UpdateEmpById/{id}")]
        public IActionResult Put(int id, [FromBody] Employee emp)
        {
            try
            {
                var record = _dbCtx.tbl_employee.Find(id);
                if (record != null)
                {
                    //update the record
                    record.Ename = emp.Ename;
                    record.Salary = emp.Salary;
                    record.Deptid = emp.Deptid;
                    _dbCtx.SaveChanges();
                    return Ok("Record updated");
                }
                else
                {
                    return NotFound("Record not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("could not update the record");
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete]
        [Route("DeleteEmp/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var record = _dbCtx.tbl_employee.Find(id);
                if (record != null)
                {
                    //delete the record
                    _dbCtx.tbl_employee.Remove(record);
                    _dbCtx.SaveChanges();
                    return Ok("Record deleted for ecode:" + record.Ecode);
                }
                else
                {
                    return NotFound("Record not found:" + id.ToString());
                }
            }
            catch (Exception ex) 
            {
             return BadRequest(ex.Message);
            }
        }

        //[HttpGet]
        //[Route("AddNumbers/{a}/{b}")]
        //public int AddNumbers(int a,int b)
        //{
        //    return a + b;
        //}
    }
}
