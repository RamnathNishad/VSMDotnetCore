using EmployeeWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {
        readonly EmployeeDbContext _dbCtx;
        readonly IConfiguration config;

        readonly ILogger logger;
        public EmployeeController(EmployeeDbContext dbCtx,IConfiguration config/*, ILogger logger*/)
        {
            this._dbCtx = dbCtx;
            this.config = config;
            //this.logger = logger;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("GetAllEmps")]
        public IActionResult Get()
        {
            int a = 100;
            int b = 0;
            int result = a / b;

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
                logger.LogError(ex.Message);

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
        public IActionResult GetEmpById(int id)
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


        [HttpPost]
        [Route("authenticate")]
        [AllowAnonymous]
        public string Authenticate(Users user)
        {
            //validate user from Database i.e. DAL
            if(user.username=="ramnath" && user.password=="abc")
            {
                //generate token
                var key = Encoding.UTF8.GetBytes(config["JWT:Key"]);
                var issuer = config["JWT:Issuer"];
                var audience= config["JWT:Audience"];
                var expires = DateTime.UtcNow.AddMinutes(10);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer=issuer,
                    Audience=audience,
                    Expires=expires,
                    SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)                
                };

                //create the token and write the token into the response
                var tokenHandler=new JwtSecurityTokenHandler();
                var token=tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }
            else
            {
                return "invalid userid/password!!!";
            }
        }
    }
}
