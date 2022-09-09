using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using BusBoarding.Authorization;
using BusBoarding.StudentAS.Dto;
using BusBoardingSystem.Domain;
using BusBoardingSystem.PeopleAS.Dto;
using BusBoardingSystem.StudentAS.Dto;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using worxflow360.Global;

namespace BusBoardingSystem.StudentAS
{
    [AbpAuthorize(PermissionNames.Pages_People)]
    public class StudentAppService : AsyncCrudAppService<Student, StudentDto, int, PagedStudentResultRequestDto, CreateStudentDto, StudentDto>, IStudentAppService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Tag> _tagRepository;

        private static readonly HttpClient client = new HttpClient();

        public StudentAppService(IRepository<Student, int> repository,
                                 IRepository<Person> personRepository,
                                 IRepository<Tag> tagRepository) : base(repository)
        {
            _personRepository = personRepository;
            _tagRepository = tagRepository;
        }

        public async override Task<StudentDto> CreateAsync(CreateStudentDto input)
        {
            // Create person
            var person = ObjectMapper.Map<Person>(input.Person);           
            await _personRepository.InsertAsync(person);

            var tag = await _tagRepository.GetAsync(input.TagId);
            tag.IsAssigned = true;

            // To get new clients's id.
            await CurrentUnitOfWork.SaveChangesAsync(); 
           
            //Create student with person data
            input.PersonId = person.Id;
                       

            return await base.CreateAsync(input);
        }

        public async override Task<StudentDto> GetAsync(EntityDto<int> input)
        {
            var studentDto = ObjectMapper.Map<StudentDto>(await Repository.GetAsync(input.Id));
            studentDto.Person = ObjectMapper.Map<PersonDto>(await _personRepository.GetAsync(studentDto.PersonId));

            return studentDto;
        }

        public async override Task<PagedResultDto<StudentDto>> GetAllAsync(PagedStudentResultRequestDto input)
        {
            List<Student> students = await Repository.GetAllListAsync();
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
            var tag = await _tagRepository.GetAsync(Repository.Get(input.Id).TagId);
            tag.IsAssigned = false;
            await base.DeleteAsync(input);
            await _personRepository.DeleteAsync(await _personRepository.GetAsync(input.Id));
            await CurrentUnitOfWork.SaveChangesAsync();
        }

        public async Task<int> TestAPI(CreatePersonDto person)
        {            
            string json = JsonConvert.SerializeObject(person);

            //var content = new FormUrlEncodedContent(values);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://196.9.23.90:5001/saveImage", content);

            var responseString = await response.Content.ReadAsStringAsync();

            return 0;
        }
    }
}
