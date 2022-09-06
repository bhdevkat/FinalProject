using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using BusBoarding.Authorization;
using BusBoarding.Authorization.Users;
using BusBoardingSystem.BusAS;
using BusBoardingSystem.BusAS.Dto;
using BusBoardingSystem.Domain;
using BusBoardingSystem.LocationAS.Dto;
using BusBoardingSystem.PeopleAS.Dto;
using BusBoardingSystem.ScheduleAS.Dto;
using BusBoardingSystem.StaffAS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoardingSystem.ScheduleAS
{
    [AbpAuthorize(PermissionNames.Pages_Schedules)]
    public class ScheduleAppService : AsyncCrudAppService<Schedule, ScheduleDto, int, PagedScheduleResultRequestDto, CreateScheduleDto, ScheduleDto>, IScheduleAppService
    {
        private readonly IRepository<Bus> _busRepository;
        private readonly IRepository<Staff> _staffRepository;
        private readonly IRepository<Location> _locationRepository;
        private readonly IRepository<Person> _personRepository;

        public ScheduleAppService(IRepository<Schedule, int> repository,
            BusAppService busAppService, 
            IRepository<Bus> busRepository,
            IRepository<Staff> staffRepository,
            IRepository<Location> locationRepository,
            IRepository<Person> personRepository
            ) : base(repository)
        {           
            _busRepository = busRepository;
            _staffRepository = staffRepository;
            _locationRepository = locationRepository;
            _personRepository = personRepository;
        }

        public async override Task<ScheduleDto> GetAsync(EntityDto<int> input)
        {
            var schedule = ObjectMapper.Map<ScheduleDto>(await base.GetAsync(input));

            var bus = await _busRepository.GetAsync(schedule.BusId);
            var driver = await _staffRepository.GetAsync(schedule.DriverId);
            var departure = await _locationRepository.GetAsync(schedule.DepartureId);
            var destination = await _locationRepository.GetAsync(schedule.DestinationId);

            //schedule.BusId = bus.Id;
            schedule.BusReg = bus.RegistrationNumber;

            //schedule.DriverId = driver.Id;
            schedule.DriverName = driver.StaffNumber;

            //schedule.DepartureId = departure.Id;
            schedule.DestinationName = departure.Name;

            //schedule.DestinationId = destination.Id;
            schedule.DestinationName = destination.Name;

            return schedule;
        }

        public async override Task<PagedResultDto<ScheduleDto>> GetAllAsync(PagedScheduleResultRequestDto input)
        {
            var schedules = ObjectMapper.Map<List<ScheduleDto>>(await Repository.GetAllListAsync());

            for(int x = 0; x < schedules.Count; x++)
            {   
                var bus = await _busRepository.GetAsync(schedules[x].BusId);
                var driver = await _staffRepository.GetAsync(schedules[x].DriverId);
                var departure = await _locationRepository.GetAsync(schedules[x].DepartureId);
                var destination = await _locationRepository.GetAsync(schedules[x].DestinationId);

                //schedules[x].BusId = bus.Id;
                schedules[x].BusReg = bus.RegistrationNumber;
     
                //schedules[x].DriverId = driver.Id;
                schedules[x].DriverName = driver.StaffNumber;
      
                //schedules[x].DepartureId = departure.Id;
                schedules[x].DepartureName = departure.Name;
              
                //schedules[x].DestinationId = destination.Id;
                schedules[x].DestinationName = destination.Name;
            }

            return new PagedResultDto<ScheduleDto>
            {
                Items = schedules,
                TotalCount = schedules.Count()
            };
        }

        public async override Task<ScheduleDto> CreateAsync(CreateScheduleDto input)
        {
            //var schedule = ObjectMapper.Map<Schedule>(input);

            return await base.CreateAsync(input);
        }

        public override Task<ScheduleDto> UpdateAsync(ScheduleDto input)
        {
            return base.UpdateAsync(input);
        }

        public async Task<DropdownItemDto> GetDropdrownData()
        {
            DropdownItemDto DropdownItems = new DropdownItemDto();

            DropdownItems.Buses = ObjectMapper
                .Map<List<BusDto>>(await _busRepository.GetAllListAsync());

            DropdownItems.Locations = ObjectMapper
                .Map<List<LocationDto>>(await _locationRepository.GetAllListAsync());

            DropdownItems.Staff = ObjectMapper
                .Map<List<StaffDto>>(await _staffRepository.GetAllListAsync());


            for (int x = 0; x < DropdownItems.Staff.Count; x++)
            {
                DropdownItems.Staff[x].Person = ObjectMapper
               .Map<PersonDto>(await _personRepository.GetAsync(DropdownItems.Staff[x].PersonId));
            }               

            return DropdownItems;
        }

    }
}
