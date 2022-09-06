using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using BusBoarding.Authorization;
using BusBoardingSystem.Domain;
using BusBoardingSystem.HomeAS.Dto;
using BusBoardingSystem.ScheduleAS.Dto;
using BusBoardingSystem.TagAS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBoardingSystem.HomeAS
{
    [AbpAuthorize(PermissionNames.Pages_People)]
    public class HomeAppService : IHomeAppService
    {        
        private readonly IRepository<Bus> _busRepository;
        private readonly IRepository<Staff> _staffRepository;
        private readonly IRepository<Location> _locationRepository;
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Trip> _tripRepository;
        private readonly IRepository<Schedule> _scheduleRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IObjectMapper _objectMapper;

        public HomeAppService(IRepository<Bus> busRepository,
            IRepository<Staff> staffRepository,
            IRepository<Location> locationRepository,
            IRepository<Person> personRepository,
            IRepository<Trip> tripRepository,
            IRepository<Schedule> scheduleRepository,
            IRepository<Student> studentRepository,
            IObjectMapper objectMapper
            )
        {
            _busRepository = busRepository;
            _staffRepository = staffRepository;
            _locationRepository = locationRepository;
            _personRepository = personRepository;
            _tripRepository = tripRepository;
            _scheduleRepository = scheduleRepository;
            _studentRepository = studentRepository;
            _objectMapper = objectMapper;
        }

        public async Task<HomeDto> GetStatisticalData()
        {
            HomeDto statistic = new HomeDto();

            statistic.StaffCount =  _staffRepository.GetAllList().Count;

            statistic.StudentCount = _studentRepository.GetAllList().Count;

            statistic.RoleCount = 50; //_roleRepository.GetAllList().Count;

            statistic.UserCount = 35;

            statistic.BusCount = _busRepository.GetAllList().Count;

            statistic.DestinationCount = _locationRepository.GetAllList().Count;

            statistic.ScheduleCount = _scheduleRepository.GetAllList().Count;

            statistic.TripCount = _tripRepository.GetAllList().Count;

            statistic.Schedules = _objectMapper.Map<List<ScheduleDto>>(_scheduleRepository.GetAllListAsync().Result.Take(5));

            for (int x = 0; x < statistic.Schedules.Count; x++)
            {
                var bus = await _busRepository.GetAsync(statistic.Schedules[x].BusId);
                var driver = await _staffRepository.GetAsync(statistic.Schedules[x].DriverId);
                var departure = await _locationRepository.GetAsync(statistic.Schedules[x].DepartureId);
                var destination = await _locationRepository.GetAsync(statistic.Schedules[x].DestinationId);

                //schedules[x].BusId = bus.Id;
                statistic.Schedules[x].BusReg = bus.RegistrationNumber;

                //schedules[x].DriverId = driver.Id;
                statistic.Schedules[x].DriverName = driver.StaffNumber;

                //schedules[x].DepartureId = departure.Id;
                statistic.Schedules[x].DepartureName = departure.Name;

                //schedules[x].DestinationId = destination.Id;
                statistic.Schedules[x].DestinationName = destination.Name;
            }

            //statistic.Trips = await _tripRepository.GetAllListAsync();

            return statistic;
        }
    }
}
