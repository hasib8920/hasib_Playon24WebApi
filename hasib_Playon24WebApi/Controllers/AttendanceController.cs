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
    public class AttendanceController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AttendanceController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeAttendanceDto>>> GetAttendance(
    [FromQuery] DateTime? start,
    [FromQuery] DateTime? end)
        {
            var fromDate = start ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var toDate = end ?? DateTime.Now; 

            using var conn = Connection;
            var parameters = new DynamicParameters();
            parameters.Add("@StartDate", fromDate);
            parameters.Add("@EndDate", toDate);

            var result = await conn.QueryAsync<EmployeeAttendanceDto>(
                "sp_GetEmployeeAttendance", parameters, commandType: CommandType.StoredProcedure);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddAttendance([FromBody] Attendance dto)
        {
            using var conn = Connection;
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", dto.EmployeeID);
            parameters.Add("@AttendanceDate", dto.AttendanceDate);
            parameters.Add("@Status", dto.Status);

            var newId = await conn.ExecuteScalarAsync<int>("sp_AddAttendance", parameters, commandType: CommandType.StoredProcedure);
            return Ok(new { NewAttendanceID = newId });
        }
    }
}
