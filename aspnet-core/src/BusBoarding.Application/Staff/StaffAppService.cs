using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using BusBoarding.Authorization;
using BusBoardingSystem.Domain;
using BusBoardingSystem.StaffAS.Dto;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using BusBoardingSystem.PeopleAS.Dto;
using worxflow360.Global;
using System.Linq;

namespace BusBoardingSystem.StaffAS
{
    [AbpAuthorize(PermissionNames.Pages_Staff)]
    public class StaffAppService : AsyncCrudAppService<Staff, StaffDto, int, PagedStaffResultRequestDto, CreateStaffDto, StaffDto>, IStaffAppService
    {
        private readonly IRepository<Person> _personRepository;

        public StaffAppService(IRepository<Staff, int> repository,
                               IRepository<Person> personRepository) : base(repository)
        {
            _personRepository = personRepository;
        }

        public async override Task<StaffDto> CreateAsync(CreateStaffDto input)
        {
            // Create person
            var person = ObjectMapper.Map<Person>(input.Person);
            await _personRepository.InsertAsync(person);

            // To get new clients's id.
            await CurrentUnitOfWork.SaveChangesAsync();

            //Create student with person data
            input.PersonId = person.Id;
            return await base.CreateAsync(input);
        }

        public async override Task<PagedResultDto<StaffDto>> GetAllAsync(PagedStaffResultRequestDto input)
        {
            List<Staff> students = await Repository.GetAllListAsync();
            List<Person> people = await _personRepository.GetAllListAsync();

            List<StaffDto> studentDto = new List<StaffDto>();

            foreach (var student in students)
            {
                StaffDto newStudent = ObjectMapper.Map<StaffDto>(student);
                newStudent.Person = ObjectMapper.Map<PersonDto>(people.SingleOrDefault(x => x.Id == newStudent.PersonId));
                studentDto.Add(newStudent);
            }

            //var studentDto2 = students.Join(people, x => x.PersonId, a => a.Id, (x, a) => new Object());

            return Common.GetPagedResult<StaffDto>(studentDto);
        }

        public async override Task<StaffDto> GetAsync(EntityDto<int> input)
        {
            var studentDto = ObjectMapper.Map<StaffDto>(await Repository.GetAsync(input.Id));
            studentDto.Person = ObjectMapper.Map<PersonDto>(await _personRepository.GetAsync(studentDto.PersonId));

            return studentDto;
        }


        public async override Task<StaffDto> UpdateAsync(StaffDto input)
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
