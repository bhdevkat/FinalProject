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
            // Create client
            var person = ObjectMapper.Map<Person>(input.Person);
                        
            await _personRepository.InsertAsync(person);
            await CurrentUnitOfWork.SaveChangesAsync(); // To get new clients's id.

            // We are working entities of new tenant, so changing tenant filter
            using (CurrentUnitOfWork.SetTenantId(person.TenantId))
            {
                // Add staff for the newly created tenant               
                var staff = ObjectMapper.Map<Staff>(input);
                staff.PersonId = person.Id;

                await Repository.InsertAsync(staff); 
                await CurrentUnitOfWork.SaveChangesAsync();

                var staffDto = MapToEntityDto(staff);
                staffDto.Person = person;

                return staffDto;
            }
        }

        public async override Task<PagedResultDto<StaffDto>> GetAllAsync(PagedStaffResultRequestDto input)
        {
            List<Staff> staff = await Repository.GetAllListAsync();
            List<Person> people = await _personRepository.GetAllListAsync();

            List<StaffDto> staffDto = new List<StaffDto>();

            foreach (var member in staff)
            {
                StaffDto newStaff = ObjectMapper.Map<StaffDto>(member);
                newStaff.Person = people.SingleOrDefault(x => x.Id == newStaff.PersonId);
                staffDto.Add(newStaff);
            }

            return Common.GetPagedResult<StaffDto>(staffDto);
        }

        public async override Task<StaffDto> GetAsync(EntityDto<int> input)
        {
            Staff staff = await Repository.GetAsync(input.Id);

            Person people = await _personRepository
                .GetAsync(staff.PersonId);

            StaffDto staffDto = ObjectMapper.Map<StaffDto>(staff);
            staffDto.Person = people;

            return staffDto;
        }


        public async override Task<StaffDto> UpdateAsync(StaffDto input)
        {
            Person person = await _personRepository.UpdateAsync(input.Person);

            var StaffDto = await base.UpdateAsync(input);
            StaffDto.Person = person;

            return StaffDto;
        }

        public async override Task DeleteAsync(EntityDto<int> input)
        {
            Staff staff = await Repository.GetAsync(input.Id);

            Person people = await _personRepository
                .FirstOrDefaultAsync(x => x.Id == staff.PersonId);

            await _personRepository.DeleteAsync(people);
            await base.DeleteAsync(input);;
        }
    }
}
