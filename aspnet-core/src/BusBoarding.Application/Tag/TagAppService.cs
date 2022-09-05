﻿using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using BusBoarding.Authorization;
using BusBoardingSystem.Domain;
using BusBoardingSystem.TagAS.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusBoardingSystem.TagAS
{
    [AbpAuthorize(PermissionNames.Pages_People)]
    public class TagAppService : ITagAppService
    {
        private readonly IRepository<Tag> _tagRepository;
        private readonly IObjectMapper _objectMapper;

        public TagAppService(IRepository<Tag> repository, IObjectMapper objectMapper)
        {
            _tagRepository = repository;
            _objectMapper = objectMapper;
        }

        public async Task<List<TagDto>> GetDropdrownData()
        {
            try
            {
                return _objectMapper
                    .Map<List<TagDto>>(await _tagRepository.GetAllListAsync());
            }
            catch (Exception ex)
            {
                var strin = ex.Message;
            }

            return null;
        }
    }
}
