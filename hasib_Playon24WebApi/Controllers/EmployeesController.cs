using Dapper;
using hasib_Playon24WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace hasib_Playon24WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            using var conn = Connection;
            var result = await conn.QueryAsync<EmployeeDto>("sp_GetEmployees", commandType: CommandType.StoredProcedure);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddEmployee([FromBody] EmployeeDto dto)
        {
            using var conn = Connection;
            var parameters = new DynamicParameters();
            parameters.Add("@Name", dto.Name);
            parameters.Add("@DepartmentID", dto.DepartmentID);
            parameters.Add("@JoinDate", dto.JoinDate);
            parameters.Add("@Salary", dto.Salary);
            parameters.Add("@NewEmployeeID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await conn.ExecuteAsync("sp_AddEmployee", parameters, commandType: CommandType.StoredProcedure);

            int newId = parameters.Get<int>("@NewEmployeeID");
            return Ok(new { NewEmployeeID = newId });
        }
    }
}
