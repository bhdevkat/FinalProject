using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using BusBoarding.Authorization;
using BusBoardingSystem.Domain;
using BusBoardingSystem.PeopleAS.Dto;
using BusBoardingSystem.StudentAS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using worxflow360.Global;

namespace BusBoardingSystem.StudentAS
{
    [AbpAuthorize(PermissionNames.Pages_People)]
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>, IStudentAppService
    {
        private readonly IRepository<Student,int> _repository;
        private readonly IRepository<Person> _personRepository;
        public StudentAppService(IRepository<Student, int> repository,
                                 IRepository<Person> personRepository) : base(repository)
        {
            _repository = repository;
            _personRepository = personRepository;
        }

        public async override Task<StudentDto> CreateAsync(CreateStudentDto input)
        {
            // Create person
            var person = ObjectMapper.Map<Person>(input.Person);           
            var test = await _personRepository.InsertAsync(person);

            // To get new clients's id.
            await CurrentUnitOfWork.SaveChangesAsync(); 
           
            //Create student with person data
            input.PersonId = person.Id;
            return await base.CreateAsync(input);
        }

        public async override Task<StudentDto> GetAsync(EntityDto<int> input)
        {

            try
            {
                var studentDto = ObjectMapper.Map<StudentDto>(await _repository.GetAsync(input.Id));
                studentDto.Person = ObjectMapper.Map<PersonDto>(await _personRepository.GetAsync(studentDto.PersonId));

                return studentDto;


            } catch (Exception ex)
            {
                var e = ex.Message;
             }


            return null;
        }

        public async override Task<PagedResultDto<StudentDto>> GetAllAsync(PagedStudentResultRequestDto input)
        {
            List<Student> students = await _repository.GetAllListAsync();
            List<Person> people = await _personRepository.GetAllListAsync();

            List<StudentDto> studentDto = new List<StudentDto>();

            foreach (var student in students)
            {
                StudentDto newStudent = ObjectMapper.Map<StudentDto>(student);
                newStudent.Person = ObjectMapper.Map<PersonDto>(people.SingleOrDefault(x => x.Id == newStudent.PersonId));
                studentDto.Add(newStudent);
            }

            //var studentDto2 = students.Join(people, x => x.PersonId, a => a.Id, (x, a) => new Object());

            return Common.GetPagedResult<StudentDto>(studentDto);
        }

        public async override Task<StudentDto> UpdateAsync(StudentDto input)
        {
            var students = await base.UpdateAsync(input);

            var sa = ObjectMapper.Map<Person>(input.Person);

            students.Person = ObjectMapper.Map<PersonDto>(await _personRepository.UpdateAsync(sa));   

            return students;
        }

        public async override Task DeleteAsync(EntityDto<int> input)
        {
            await base.DeleteAsync(input);
            await _personRepository.DeleteAsync(await _personRepository.GetAsync(input.Id));
        }
    }
}
