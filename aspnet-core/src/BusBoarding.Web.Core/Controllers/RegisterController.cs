using Abp.Domain.Repositories;
using Abp.Web.Models;
using BusBoardingSystem.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using BusBoarding.Domain;
using BusBoardingSystem.StudentAS.Dto;
using System.Collections.Generic;
using BusBoardingSystem.PeopleAS.Dto;

namespace BusBoarding.Controllers
{
    [DontWrapResult(WrapOnSuccess = false, WrapOnError = false, LogError = true)]
    public class RegisterController : BusBoardingControllerBase
    {
        private readonly IRepository<Student> _studentTrpository;
        private readonly IRepository<Person> _personTrpository;
        private readonly IRepository<Tag> _tagRepository;
        private readonly IRepository<TapActivity> _tapActivityRepository;

        public RegisterController(IRepository<Student> studentTrpository, 
            IRepository<Tag> tagRepository,
            IRepository<TapActivity> tapActivityRepository,
            IRepository<Person> personTrpository)
        {
            _studentTrpository = studentTrpository;
            _tagRepository = tagRepository;
            _tapActivityRepository  = tapActivityRepository;
            _personTrpository = personTrpository;
        }

        [HttpGet(template:"/api/client/v1/getTag")]
        public ActionResult GetTag()
        {
            var tag = _tapActivityRepository.GetAllList();

            if (tag.Count > 0)
                return Ok(tag[0].Uid);

            return Conflict("No tag found");
        }

        [HttpPost(template: "/api/client/v1/createTagActivity")]
        public ActionResult CreateTagActivity(string uid)
        {
            uid = uid.Trim();

            try
            {
                var activity = _tapActivityRepository.GetAllList();

                if (activity.Count > 0)
                {
                    activity[0].Uid = uid;
                    CurrentUnitOfWork.SaveChanges();
                    return Ok("Updated Successfully.");
                }    

                TapActivity newActivity = new TapActivity
                {
                    Uid = uid
                };

                _tapActivityRepository.InsertAsync(newActivity);
                CurrentUnitOfWork.SaveChanges();

                return CreatedAtAction(nameof(AddTag), newActivity);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new activity record. " + ex.Message);
            }
        }


        [HttpPost(template: "/api/client/v1/removeTagActivity")]
        public ActionResult RemoveTagActivity(string uid)
        {
            uid = uid.Trim();

            try
            {
                var activity = _tapActivityRepository.GetAllList();

                if (activity.Count > 0)
                {
                    _tapActivityRepository.Delete(activity[0].Id);
                    CurrentUnitOfWork.SaveChanges();
                    return Ok("Deleted Successfully.");
                }

                return Conflict("No record found");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new activity record. " + ex.Message);
            }
        }


        [HttpPost(template: "/api/client/v1/getTagActivity")]
        public ActionResult GetTagActivity(string uid)
        {
            uid = uid.Trim();

            try
            {
                var activity = _tapActivityRepository.GetAllList();

                if (activity.Count > 0)
                {
                    var tag = _tagRepository.Single(x => x.Uid == activity[0].Uid);

                    var students = _studentTrpository.GetAllList(x => x.TagId == tag.Id);

                    var people = _personTrpository.GetAllList();

                    List<StudentDto> studentDto = new List<StudentDto>();

                    foreach (var student in students)
                    {
                        StudentDto newStudent = ObjectMapper.Map<StudentDto>(student);
                        newStudent.Person = ObjectMapper.Map<PersonDto>(people.SingleOrDefault(x => x.Id == newStudent.PersonId));
                        studentDto.Add(newStudent);
                    }

                    if (studentDto.Count > 0)
                    {
                        return Ok(studentDto);
                    }                    
                }

                return Conflict("No tag activity");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new activity record. " + ex.Message);
            }
        }


        [HttpPost(template: "/api/client/v1/addTag")]
        public ActionResult AddTag(string uid)
        {
            uid = uid.Trim();

            try
            {
                var Tag =  _tagRepository.GetAllList();

                if (Tag.SingleOrDefault(x => x.Uid == uid) != null)
                    return Conflict("Tag Already registered");

                Tag newTag = new Tag
                {
                    Uid = uid
                };

                 _tagRepository.InsertAsync(newTag);
                 CurrentUnitOfWork.SaveChanges();

                return CreatedAtAction(nameof(AddTag),newTag);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new tag record");
            }
        }
    }
}
