using Abp.Domain.Repositories;
using Abp.Web.Models;
using BusBoardingSystem.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BusBoarding.Controllers
{
    [DontWrapResult(WrapOnSuccess = false, WrapOnError = false, LogError = true)]
    public class RegisterController : BusBoardingControllerBase
    {
        private readonly IRepository<Student> _studentTrpository;

        public RegisterController(IRepository<Student> studentTrpository)
        {
            _studentTrpository = studentTrpository;
        }

        [HttpGet(template:"/api/client/v1/student/{studentId}")]
        public async Task<Student> GetStudent(int studentId)
        {
            var student = await _studentTrpository.GetAsync(studentId);
            return student;
        }

        [HttpPost(template: "/api/client/v1/test")]
        public async Task<ActionResult<int>> CreateEmployee(int emp)
        {
            try
            {
                if (emp == null)
                    return BadRequest();

                return Ok(emp * 2);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }
    }
}
