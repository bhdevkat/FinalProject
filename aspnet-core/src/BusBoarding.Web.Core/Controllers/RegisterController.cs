using Abp.Domain.Repositories;
using Abp.Web.Models;
using BusBoardingSystem.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace BusBoarding.Controllers
{
    [DontWrapResult(WrapOnSuccess = false, WrapOnError = false, LogError = true)]
    public class RegisterController : BusBoardingControllerBase
    {
        private readonly IRepository<Student> _studentTrpository;
        private readonly IRepository<Tag> _tagRepository;

        public RegisterController(IRepository<Student> studentTrpository, 
            IRepository<Tag> tagRepository)
        {
            _studentTrpository = studentTrpository;
            _tagRepository = tagRepository;
        }

        [HttpGet(template:"/api/client/v1/student/{studentId}")]
        public async Task<Student> GetStudent(int studentId)
        {
            var student = await _studentTrpository.GetAsync(studentId);
            return student;
        }

        [HttpPost(template: "/api/client/v1/addTag")]
        public async Task<ActionResult<int>> AddTag(string uid)
        {
            try
            {
                var Tag = await _tagRepository.GetAllListAsync();

                if (Tag.SingleOrDefault(x => x.Uid == uid) != null)
                    return Conflict("Tag Already registered");

                Tag newTag = new Tag
                {
                    Uid = uid
                };

                await _tagRepository.InsertAsync(newTag);
                await CurrentUnitOfWork.SaveChangesAsync();

                return CreatedAtAction(nameof(AddTag),newTag);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new tag record");
            }
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
